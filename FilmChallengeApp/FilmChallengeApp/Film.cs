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
        if (grade >=1 && grade <= 100)
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
}
