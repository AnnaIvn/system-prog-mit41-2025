using System;
using System.Net;

// Lab4.1
// Showcasing how BLOCKING METHOD works compared to asynchronous (in Lab4.2):
// Blocking method(synchronous) – the main thread is stopped until the web page loads.
class Program
{
    static void Main()
    {
        Console.WriteLine("Loading page...");
        DumpWebPage("https://www.example.com");
        Console.WriteLine("This line will only be executed after the page loads.");
    }

    private static void DumpWebPage(string uri)
    {
        WebClient webClient = new WebClient();
        string page = webClient.DownloadString(uri);
        Console.WriteLine("The page is loaded:");
        Console.WriteLine(page.Substring(0, 200));      // displaying first 200 symbols
    }
}

