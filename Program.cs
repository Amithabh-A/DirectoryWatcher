using System;
using System.IO;

class Program
{
    private static FileSystemWatcher _watcher;

    static void Main(string[] args)
    {
        // Check if the directory path is provided
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a directory path to watch.");
            return;
        }

        string directoryPath = args[0];

        // Check if the provided path is a valid directory
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine($"The directory '{directoryPath}' does not exist.");
            return;
        }

        _watcher = new FileSystemWatcher
        {
            Path = directoryPath,
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
            Filter = "*.*",
            EnableRaisingEvents = true
        };

        // Add event handlers
        _watcher.Changed += OnChanged;
        _watcher.Created += OnChanged;

        // Handle Ctrl+C to quit
        Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);

        Console.WriteLine($"Watching directory: {directoryPath}");
        Console.WriteLine("Press Ctrl+C to quit.");

        // Keep the console application running
        while (true) ;
    }

    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        // Call the notification function when a file is created or modified
        f();
    }

    private static void f()
    {
        Console.WriteLine("This is a notification");
    }

    private static void OnExit(object sender, ConsoleCancelEventArgs e)
    {
        // Cleanup when exiting
        _watcher.Dispose();
        Console.WriteLine("\nExiting. Thank you for using the Directory Watcher.");
    }
}

