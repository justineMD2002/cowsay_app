using CowsayApp;

bool keepRunning = true;

Cowsay cowsay = new("");

while (keepRunning) {   
    Console.Write("Tell me what you want to say: ");
    string userInput = Console.ReadLine() ?? "";

    cowsay.Message = userInput;
    Console.WriteLine(cowsay.GetCowsayOutput());

    Console.Write("Do you want to try again? (yes/no): ");
    string response = Console.ReadLine()?.Trim().ToLower() ?? "no";

    keepRunning = response == "yes" || response == "y";
}   

Console.WriteLine("Goodbye! 🐄");
