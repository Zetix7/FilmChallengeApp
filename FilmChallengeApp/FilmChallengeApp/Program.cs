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
