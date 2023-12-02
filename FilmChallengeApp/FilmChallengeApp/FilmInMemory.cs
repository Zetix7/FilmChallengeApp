namespace FilmChallengeApp;

public class FilmInMemory : FilmBase
{
    private readonly List<int> _grades = new();

    public FilmInMemory(string title, int year) : base(title, year)
    {
    }

    public override void AddGrade(int grade)
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

    public override Statistics GetStatistics()
    {
        var statistics = new Statistics();

        foreach (var grade in _grades)
        {
            statistics.AddGrade(grade);
        }

        return statistics;
    }
}
