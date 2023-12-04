namespace FilmChallengeApp.Tests
{
    public class StatisticsTests
    {
        [Test]
        public void Add3ValuesReturnMaxValue()
        {
            var film = new FilmInMemory("Avengers", 2012);
            film.AddGrade("10,567687879");
            film.AddGrade('e');
            film.AddGrade("80,5555555555");

            var statistics = film.GetStatistics();

            Assert.AreEqual(81, statistics.Max);
        }

        [Test]
        public void Add3ValuesReturnMinValue()
        {
            var film = new FilmInMemory("Avengers", 2012);
            film.AddGrade(10.567687879d);
            film.AddGrade(7l);
            film.AddGrade("81,5555555555");

            var statistics = film.GetStatistics();

            Assert.AreEqual(7, statistics.Min);
        }

        [Test]
        public void Add3ValuesReturnAverageValue()
        {
            var film = new FilmInMemory("Avengers", 2012);
            film.AddGrade(15.43245677m);
            film.AddGrade("7");
            film.AddGrade("77,875555648455");

            var statistics = film.GetStatistics();

            Assert.AreEqual(Math.Round(33.33, 2), Math.Round(statistics.Average, 2));
        }

        [Test]
        public void Add3ValuesReturnSumOfThem()
        {
            var film = new FilmInMemory("Avengers", 2012);
            film.AddGrade(15.43245677f);
            film.AddGrade(7);
            film.AddGrade("77,848455");

            var statistics = film.GetStatistics();

            Assert.AreEqual(100, statistics.Sum);
        }

        [Test]
        public void Add3ValuesReturnAverageLeterValue()
        {
            var film = new FilmInMemory("Avengers", 2012);
            film.AddGrade("15,43245677");
            film.AddGrade(34.56f);
            film.AddGrade("56");

            var statistics = film.GetStatistics();

            Assert.AreEqual('D', statistics.AverageLetter);
        }
    }
}