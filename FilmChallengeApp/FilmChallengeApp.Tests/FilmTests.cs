namespace FilmChallengeApp.Tests;

public class FilmTests
{
    [Test]
    public void CreateFilmInMemoryObjectReturnTitle()
    {
        var film = new FilmInMemory("Avengers", 2012);

        Assert.AreEqual("Avengers", film.Title);
    }

    [Test]
    public void CreateFilmInMemoryObjectReturnYear()
    {
        var film = new FilmInMemory("Avengers", 2012);

        Assert.AreEqual(2012, film.Year);
    }

    [Test]
    public void CreateFilmInFileObjectReturnTitle()
    {
        var film = new FilmInFile("Avengers", 2012);

        Assert.AreEqual("Avengers", film.Title);
    }

    [Test]
    public void CreateFilmInFileObjectReturnYear()
    {
        var film = new FilmInFile("Avengers", 2012);

        Assert.AreEqual(2012, film.Year);
    }

    [Test]
    public void AddGradeToFilmInMemoryReturnAddedValue()
    {
        var film = new FilmInMemory("Avengers", 2012);
        film.AddGrade('B');

        Assert.AreEqual(80, film.GetStatistics().Sum);
    }
}