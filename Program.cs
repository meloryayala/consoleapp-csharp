// Screen Sound

//Pattern Camel Case

using System.Diagnostics;

string welcomeMsg = "Welcome to Music Box!";
// List<string> bandsList = new List<string> {"Oasis", "Shakira", "Nirvana"};
Dictionary<string, List<int>> registeredBands = new Dictionary<string, List<int>>();
registeredBands.Add("Oasis", new List<int> { 10, 8, 6 });
registeredBands.Add("Mana", new List<int>());

//Pattern Pascal Case
void DisplayLogo()
{
    Console.WriteLine(@"
█▀▄▀█ █░█ █▀ █ █▀▀   █▄▄ █▀█ ▀▄▀
█░▀░█ █▄█ ▄█ █ █▄▄   █▄█ █▄█ █░█
");
}
//@"" => Verbatim Literal - display the string exactly how it will be

void DisplayMenuOptions()
{
    DisplayLogo();
    Console.WriteLine(welcomeMsg);
    Console.WriteLine("\nWrite 1 to register a band");
    Console.WriteLine("Write 2 to display all bands");
    Console.WriteLine("Write 3 to rate a band");
    Console.WriteLine("Write 4 to display the band average rate");
    Console.WriteLine("Write -1 to leave the application");

    Console.Write("\nWhat is your choice? ");
    string choseOption = Console.ReadLine()!;
    int choseOptionNumber = int.Parse(choseOption);

    switch (choseOptionNumber)
    {
        case 1:
            RegisterBand();
            break;
        case 2:
            DisplayBandsList();
            break;
        case 3:
            RateBand();
            break;
        case 4:
            DisplayBandAverage();
            break;
        case -1:
            Console.WriteLine("Bye bye :)");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

void RegisterBand()
{
    Console.Clear();
    DisplayLogo();
    DisplayTitle("Register a band");
    Console.Write("\nWrite the band name: ");
    string bandName = Console.ReadLine()!;
    registeredBands.Add(bandName, new List<int>());
    Console.WriteLine($"The band {bandName} was successfully registered!");
    Thread.Sleep(2000);
    Console.Clear();
    DisplayMenuOptions();
}

void DisplayBandsList()
{
    Console.Clear();
    DisplayLogo();
    DisplayTitle("Check all bands");
    //for with integer
    // for (int i = 0; i < bandsList.Count(); i++)
    // {
    //     Console.WriteLine($"Band => {bandsList[i]}");
    // }
    foreach (string band in registeredBands.Keys)
    {
        Console.WriteLine($"Band => {band}");
    }

    Console.WriteLine("\nWrite a key to return to the menu");
    Console.ReadKey();
    Console.Clear();
    DisplayMenuOptions();
}

void DisplayTitle(string title)
    {
        int lettersQuantity = title.Length;
        string asterisks = string.Empty.PadLeft(lettersQuantity, '*');
        Console.WriteLine(asterisks);
        Console.WriteLine(title);
        Console.WriteLine(asterisks + "\n");
    }

void RateBand()
{
    //which band?
    //if band exist -> add rate
    //otherwise return menu
    
    Console.Clear();
    DisplayLogo();
    DisplayTitle("Rate a band");
    Console.Write("Write the band name you want to rate: ");
    string bandName = Console.ReadLine()!;
    
    if (registeredBands.ContainsKey(bandName))
    {
        Console.Write($"\nWhich rate the band #{bandName} deserve? ");
        int rate = int.Parse(Console.ReadLine()!);
        registeredBands[bandName].Add(rate);
        Console.WriteLine($"\nThe rate => {rate} was successfully registered to #{bandName}!");
        Thread.Sleep(4000);
        Console.Clear();
        DisplayMenuOptions();
    }
    else
    {
        Console.WriteLine($"\nThe band => {bandName} was not found");
        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey();
        Console.Clear();
        DisplayMenuOptions();
    }

}

void DisplayBandAverage()
{
    Console.Clear();
    DisplayLogo();
    DisplayTitle("Check the bands average rate");
    Console.Write("\nWhich band average do you want to know? ");
    string bandName = Console.ReadLine()!;

    if (registeredBands.ContainsKey(bandName))
    {
        double bandAverage = registeredBands["Oasis"].Average();
        Console.WriteLine($"\nThe band #{bandName} average is => {bandAverage}!");
        Thread.Sleep(4000);
        Console.Clear();
        DisplayMenuOptions();
    }
    else
    {
        Console.WriteLine($"The band #{bandName} was not found");
        Console.WriteLine("\nPress any key to return to menu");
        Console.ReadKey();
        Console.Clear();
        DisplayMenuOptions();
    }
}

DisplayMenuOptions();