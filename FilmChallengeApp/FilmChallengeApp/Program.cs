using FilmChallengeApp;

Console.WriteLine("Welcome in Rating Movie Program!\n");

var film = new Film("Iron Man", 2008);

do
{
    Console.WriteLine($"Add grade to {film.Title} ({film.Year}):");
    var choise = Console.ReadLine();

    if(choise.Trim() == "q" || choise.Trim() == "Q")
    {
        break;
    }
    try
    {
        film.AddGrade(choise);
    }
    catch (FormatException fe)
    {
        Console.WriteLine(fe.Message);
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(ae.Message);
    }
} while (true);

var statistics = film.GetStatistics();
Console.WriteLine($"Statistics for {film.Title} ({film.Year}):");
Console.WriteLine($"\tMin added grade: {statistics.Min}");
Console.WriteLine($"\tMax added grade: {statistics.Max}");
Console.WriteLine($"\tAverage of all grades: {statistics.Average}");
Console.WriteLine($"\tAverage Letter shows quality of movie: {statistics.AverageLetter}");