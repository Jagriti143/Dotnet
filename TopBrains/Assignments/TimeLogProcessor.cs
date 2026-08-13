using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class LogEntry
{
    public DateTime Timestamp;
    public string Level;
    public string Message;
    public Exception Error;

    public LogEntry(string level, string message, Exception error = null)
    {
        Timestamp = DateTime.Now;
        Level = level;
        Message = message;
        Error = error;
    }
}

class LogProcessor
{
    private List<string> buffer = new List<string>();
    private List<LogEntry> errors = new List<LogEntry>();

    private int capacity = 3;

    public void Process(LogEntry log)
    {
        // Create log message using StringBuilder
        StringBuilder sb = new StringBuilder();

        sb.Append(log.Timestamp);
        sb.Append(" | ");
        sb.Append(log.Level);
        sb.Append(" | ");
        sb.Append(log.Message);

        if (log.Error != null)
        {
            sb.Append(" | ");
            sb.Append(log.Error.Message);
        }

        // Add to buffer
        buffer.Add(sb.ToString());

        // Store errors separately
        if (log.Level == "ERROR")
        {
            errors.Add(log);
        }

        // Flush when buffer is full
        if (buffer.Count == capacity)
        {
            Flush();
        }
    }

    void Flush()
    {
        foreach (string log in buffer)
        {
            File.AppendAllText("logs.txt", log + "\n");
        }

        Console.WriteLine("Buffer flushed.");

        buffer.Clear();
    }

    public void ShowErrors()
    {
        Console.WriteLine("\nError Summary:");

        foreach (LogEntry error in errors)
        {
            Console.WriteLine(error.Message);
        }
    }
}

class Program
{
    static void Main()
    {
        LogProcessor processor = new LogProcessor();

        processor.Process(
            new LogEntry("INFO", "Application started"));

        processor.Process(
            new LogEntry("INFO", "User logged in"));

        processor.Process(
            new LogEntry("ERROR", "Database connection failed",
                new Exception("Connection timeout")));

        processor.Process(
            new LogEntry("WARNING", "Memory is high"));

        processor.Process(
            new LogEntry("ERROR", "File not found",
                new Exception("File does not exist")));

        // Flush remaining logs
        processor.ShowErrors();

        Console.WriteLine("\nLogs saved in logs.txt");
    }
}