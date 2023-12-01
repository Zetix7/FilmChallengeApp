namespace FilmChallengeApp;

public class Film
{
    private List<int> _grades = new();

    public Film(string title, int year)
    {
        Title = title;
        Year = year;
    }

    public string Title { get; set; }
    public int Year { get; set; }

    public void AddGrade(int grade)
    {
        if (grade >= 1 && grade <= 100)
        {
            _grades.Add(grade);
        }
        else
        {
            throw new ArgumentException($"Invalid value: '{grade}'! Correct value range is from 1 to 100.");
        }
    }

    public void AddGrade(string grade)
    {
        if (int.TryParse(grade, out int intResult))
        {
            AddGrade(intResult);
        }
        else if (float.TryParse(grade, out float floatResult))
        {
            AddGrade(floatResult);
        }
        else
        {
            throw new FormatException($"Invalid value: '{grade}'! Value is not int.");
        }
    }

    public void AddGrade(float grade)
    {
        var intResult = (int)Math.Round(grade);
        AddGrade(intResult);
    }

    public Statistics GetStatistics()
    {
        var statistics = new Statistics();

        foreach (var grade in _grades)
        {
            statistics.Min = Math.Min(statistics.Min, grade);
            statistics.Max = Math.Max(statistics.Max, grade);
            statistics.Sum += grade;
            statistics.Count++;
        }

        statistics.Average = (float)Math.Round((float)statistics.Sum / statistics.Count, 2);

        switch (statistics.Average)
        {
            case var average when average > 80:
                statistics.AverageLetter = 'A';
                break;
            case var average when average > 60:
                statistics.AverageLetter = 'B';
                break;
            case var average when average > 40:
                statistics.AverageLetter = 'C';
                break;
            case var average when average > 20:
                statistics.AverageLetter = 'D';
                break;
            default:
                statistics.AverageLetter = 'E';
                break;
        }

        return statistics;
    }
}
