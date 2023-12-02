using FilmChallengeApp;

Console.WriteLine("Welcome in Rating Movie Program!\n");


Console.Write("\tInsert title of movie: ");
var title = Console.ReadLine();
Console.Write("\tInsert year of movie: ");
var year = Console.ReadLine();

var film = new Film(title, int.Parse(year));

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