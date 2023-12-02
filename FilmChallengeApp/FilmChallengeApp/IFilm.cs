namespace FilmChallengeApp;

public interface IFilm
{
    string Title { get; set; }
    int Year { get; set; }

    void AddGrade(int grade);
    void AddGrade(string grade);
    void AddGrade(float grade);
    void AddGrade(char grade);
    Statistics GetStatistics();
}
