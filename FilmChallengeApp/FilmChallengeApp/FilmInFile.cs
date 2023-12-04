namespace FilmChallengeApp;

public class FilmInFile : FilmBase
{
    private const string FILENAME="_grades.txt";
    private readonly string fullFileName;

    public FilmInFile(string title, int year) : base(title, year)
    {
        fullFileName = $"{title}_{year}{FILENAME}";
    }

    public override void AddGrade(int grade)
    {
        if(grade>=1 && grade <= 100)
        {
            using(var writer = File.AppendText(fullFileName))
            {
                writer.WriteLine(grade);
            }
        }
        else
        {
            throw new ArgumentException($"Invalid value '{grade}'! Correct range is 1 - 100.");
        }
    }

    public override Statistics GetStatistics()
    {
        var statistics = new Statistics();

        if(File.Exists(fullFileName))
        {
            using(var reader = File.OpenText(fullFileName))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    statistics.AddGrade(int.Parse(line));
                    line = reader.ReadLine();
                }
            }
        }
        else
        {
            throw new FileNotFoundException($"File '{fullFileName}' not found!");
        }

        return statistics;
    }
}
