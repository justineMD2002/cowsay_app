using System;
using System.Diagnostics;

namespace CowsayApp;

class Cowsay {
    public string Message { get; set;}

    public Cowsay(string? message) {  
        Message = string.IsNullOrWhiteSpace(message) ? "Moo! (You said nothing)" : message;
    }

    public string GetCowsayOutput() {
        var psi = new ProcessStartInfo("cowsay") {
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        };

        try {
            using var process = Process.Start(psi);
            if (process == null) {
                throw new InvalidOperationException("Error: Failed to start cowsay process.");
            }

            using (var writer = process.StandardInput) {
                if (!writer.BaseStream.CanWrite) {
                    throw new InvalidOperationException("Error: Unable to write to cowsay process.");
                }
                writer.WriteLine(Message);
            }

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        } catch (Exception ex) {
            return $"Error: {ex.Message}\nMake sure 'cowsay' is installed and available in PATH.";
        }
    }
}
