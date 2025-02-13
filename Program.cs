using CowsayApp;

Console.Write("Tell me what you want to say: ");
string userInput = Console.ReadLine() ?? "";

Console.WriteLine(Cowsay.GetCowsayOutput(userInput));