namespace FilmChallengeApp;

public class FilmInFile : FilmBase
{
    private const string FILENAME="_grades.txt";
    private string fullFileName;

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
        throw new NotImplementedException();
    }
}
