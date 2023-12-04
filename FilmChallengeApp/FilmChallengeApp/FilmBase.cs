namespace FilmChallengeApp;

public abstract class FilmBase : IFilm
{
    public FilmBase(string title, int year)
    {
        Title = title;
        Year = year;
    }

    public string Title {  get; set; }
    public int Year { get; set; }

    public abstract void AddGrade(int grade);
    
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
        else if (grade.Length == 1)
        {
            AddGrade(grade[0]);
        }
        else
        {
            throw new FormatException($"Invalid value: '{grade}'! Value is not int.");
        }
    }

    public void AddGrade(float grade)
    {
        var result = (int)Math.Round(grade);
        AddGrade(result);
    }

    public void AddGrade(char grade)
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

    public void AddGrade(double grade)
    {
        var result = (int)Math.Round(grade);
        AddGrade(result);
    }

    public void AddGrade(decimal grade)
    {
        var result = (int)Math.Round(grade);
        AddGrade(result);
    }

    public void AddGrade(long grade)
    {
        var result = (int)grade;
        AddGrade(result);
    }

    public abstract Statistics GetStatistics();
}
