namespace FilmChallengeApp;

public interface IFilm
{
    string Title { get; set; }
    int Year { get; set; }

    void AddGrade(int grade);
    void AddGrade(string grade);
    void AddGrade(float grade);
    void AddGrade(char grade);
    void AddGrade(double grade);
    void AddGrade(decimal grade);
    void AddGrade(long grade);
    Statistics GetStatistics();
}
