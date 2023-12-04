using FilmChallengeApp;

Console.WriteLine("Welcome in Rating Movie Program!\n");
do
{
    var choise = "";
    try
    {
        choise = ChooseMemoryOrFile();
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine($"Exception catched: {ae.Message}");
    }

    if (choise == "1" || choise == "2")
    {
        break;
    }
} while (true);

static FilmInMemory AddFilmToMemory()
{
    Console.Write("\tInsert title of movie: ");
    var title = Console.ReadLine();
    Console.Write("\tInsert year of movie: ");
    var year = Console.ReadLine();
    do
    {
        if (int.TryParse(year, out int intYear))
        {
            return new FilmInMemory(title, int.Parse(year));
        }
        Console.WriteLine("\t\tWrong year! Try again...");
        Console.Write("\tInsert year of movie again: ");
        year = Console.ReadLine();
    } while (true);
}

static FilmInFile AddFilmToFile()
{
    Console.Write("\tInsert title of movie: ");
    var title = Console.ReadLine();
    Console.Write("\tInsert year of movie: ");
    var year = Console.ReadLine();
    do
    {
        if (int.TryParse(year, out int intYear))
        {
            return new FilmInFile(title, int.Parse(year));
        }
        Console.WriteLine("\t\tWrong year! Try again...");
        Console.Write("\tInsert year of movie again: ");
        year = Console.ReadLine();
    } while (true);
}

static void AddGradeInMemory(FilmInMemory film)
{
    do
    {
        Console.WriteLine($"Add grade to {film.Title} ({film.Year}):");
        var choise = Console.ReadLine();

        if (choise.Trim() == "q" || choise.Trim() == "Q")
        {
            break;
        }
        try
        {
            film.AddGrade(choise);
        }
        catch (FormatException fe)
        {
            Console.WriteLine($"Exception catched: {fe.Message}");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine($"Exception catched: {ae.Message}");
        }
    } while (true);
}

static void AddGradeInFile(FilmInFile filmInFile)
{
    do
    {
        Console.WriteLine($"Add grade to {filmInFile.Title} ({filmInFile.Year}):");
        var choise = Console.ReadLine();

        if (choise.Trim() == "q" || choise.Trim() == "Q")
        {
            break;
        }
        try
        {
            filmInFile.AddGrade(choise);
        }
        catch (FormatException fe)
        {
            Console.WriteLine($"Exception catched: {fe.Message}");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine($"Exception catched: {ae.Message}");
        }
        catch (FileNotFoundException fe)
        {
            Console.WriteLine($"Exception catched: {fe.Message}");
        }
    } while (true);
}

static string ChooseMemoryOrFile()
{
    Console.WriteLine("Where do you want save grade?");
    Console.WriteLine("\t1 - Save in memory");
    Console.WriteLine("\t2 - Save in file");
    Console.Write("Your choise is: ");
    var choise = Console.ReadLine();

    switch (choise)
    {
        case "1":
            Console.WriteLine("\tNow you are saveing in memory");
            var filmInMemory = AddFilmToMemory();

            AddGradeInMemory(filmInMemory);

            var statistics = filmInMemory.GetStatistics();
            Console.WriteLine($"Statistics for {filmInMemory.Title} ({filmInMemory.Year}):");
            Console.WriteLine($"\tMin added grade: {statistics.Min}");
            Console.WriteLine($"\tMax added grade: {statistics.Max}");
            Console.WriteLine($"\tAverage of all grades: {statistics.Average}");
            Console.WriteLine($"\tAverage Letter shows quality of movie: {statistics.AverageLetter}");
            return "1";
        case "2":
            Console.WriteLine("\tNow you are saveing in file");
            var filmInFile = AddFilmToFile();

            AddGradeInFile(filmInFile);

            try
            {
                statistics = filmInFile.GetStatistics();
                Console.WriteLine($"Statistics for {filmInFile.Title} ({filmInFile.Year}):");
                Console.WriteLine($"\tMin added grade: {statistics.Min}");
                Console.WriteLine($"\tMax added grade: {statistics.Max}");
                Console.WriteLine($"\tAverage of all grades: {statistics.Average}");
                Console.WriteLine($"\tAverage Letter shows quality of movie: {statistics.AverageLetter}");
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message);
            }
            return "2";
        default:
            throw new ArgumentException($"Invalid value: '{choise}'! Try again. It's simple, choose 1 or 2.");
    }
}