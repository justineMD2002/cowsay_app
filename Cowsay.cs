using System.Diagnostics;

namespace CowsayApp;

class Cowsay
{
    public static string GetCowsayOutput(string userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
        {
            return "Error: No input provided.";
        }
        
        var psi = new ProcessStartInfo("cowsay")
        {
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        };

        try
        {
            using var process = Process.Start(psi) ?? throw new InvalidOperationException("Error: Failed to start cowsay process.");
            using (var writer = process.StandardInput)
            {
                if (!writer.BaseStream.CanWrite)
                {
                    throw new InvalidOperationException("Error: Unable to write to cowsay process.");
                }
                writer.WriteLine(userInput);
            }

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}\nMake sure 'cowsay' is installed and available in PATH.";
        }
    }
}