using System;
using System.Net;
using System.Threading.Tasks;

// Lab4.2
// Showcasing how ASYNCHRONOUS METHOD works compared to blocking method (in Lab4.1):
// Asynchronous method – does not block the main thread, allowing the program to perform other tasks while the page loads.
class Program
{
    static async Task Main()
    {
        Console.WriteLine("Loading page...");
        await DumpWebPageAsync("https://www.example.com");  // here we added await
        Console.WriteLine("This line will only be executed after the page loads.");
    }

    private static async Task DumpWebPageAsync(string uri)
    {
        WebClient webClient = new WebClient();
        string page = await webClient.DownloadStringTaskAsync(uri);   // here line is different
        Console.WriteLine("The page is loaded:");
        Console.WriteLine(page.Substring(0, 200));      // displaying first 200 symbols
    }
}
