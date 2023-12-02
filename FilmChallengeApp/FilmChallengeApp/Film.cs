namespace FilmChallengeApp;

public class Film : BaseFilm
{
    private readonly List<int> _grades = new();

    public Film(string title, int year) : base(title, year)
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

    public override void AddGrade(string grade)
    {
        if (int.TryParse(grade, out int intResult))
        {
            AddGrade(intResult);
        }
        else if (float.TryParse(grade, out float floatResult))
        {
            AddGrade(floatResult);
        }
        else if (grade.Length == 1)
        {
            AddGrade(grade[0]);
        }
        else
        {
            throw new FormatException($"Invalid value: '{grade}'! Value is not int.");
        }
    }

    public override void AddGrade(float grade)
    {
        var intResult = (int)Math.Round(grade);
        AddGrade(intResult);
    }

    public override void AddGrade(char grade)
    {
        switch (grade)
        {
            case 'A' or 'a':
                AddGrade(100);
                break;
            case 'B' or 'b':
                AddGrade(80);
                break;
            case 'C' or 'c':
                AddGrade(60);
                break;
            case 'D' or 'd':
                AddGrade(40);
                break;
            case 'E' or 'e':
                AddGrade(20);
                break;
            default:
                throw new FormatException($"Invalid value: '{grade}'! Correct range of values 'a' - 'e' or 'A' - 'E'.");
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
