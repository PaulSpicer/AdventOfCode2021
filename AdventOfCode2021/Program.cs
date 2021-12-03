using AdventOfCode2021.Solutions;
while(true)
{
    Console.WriteLine("Welcome to Advent of Code 2021 - Select a solution to run: ");
    var userInput = Console.ReadLine();

    if (userInput == "q" || userInput == "Q") { Environment.Exit(0); }

    try
    {
        var type = Type.GetType($"AdventOfCode2021.Solutions.Day{userInput.Substring(0, userInput.Length - 1)}");
        var method = type.GetMethod($"{userInput.Last()}");
        method.Invoke(null, null);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Invalid choice");
    }
}










