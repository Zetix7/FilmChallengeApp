namespace FilmChallengeApp;

public abstract class BaseFilm
{
    public BaseFilm(string title, int year)
    {
        Title = title;
        Year = year;
    }

    public string Title {  get; set; }
    public int Year { get; set; }

    public abstract void AddGrade(int grade);
    public abstract void AddGrade(string grade);
    public abstract void AddGrade(float grade);
    public abstract void AddGrade(char grade);
    public abstract Statistics GetStatistics();
}
