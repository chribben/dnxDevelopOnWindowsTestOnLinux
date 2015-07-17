using System;
using System.IO;
using System.Net.Http;
public class Program
{
    public static void Main(string[] args)
    {
        var watcher = new System.IO.FileSystemWatcher();
        watcher.Path = @"..\dnxApplication\Application";
        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;

        // Code updated event handlers.
        watcher.Changed += new FileSystemEventHandler(RunTests);
        watcher.Created += new FileSystemEventHandler(RunTests);
        watcher.Deleted += new FileSystemEventHandler(RunTests);

        // Begin watching.
        watcher.EnableRaisingEvents = true;        
        System.Console.Read();        
    }
    private static void RunTests(object source, FileSystemEventArgs e)
    {
       Console.WriteLine("File event occured, requesting test run at http://localhost:5004/api/TestRunner");
       HttpClient client = new HttpClient();
       client.GetAsync("http://localhost:5004/api/TestRunner");
    }
}
