using System;
using System.IO;

namespace Generic;

interface ILogger
{
    public void LogInfo(string message);
    public void LogWarning(string message);
    public void LogError(string message, Exception ex);
}

public class LocalFileLogger<T> : ILogger
{
    private string FilePath;

    public LocalFileLogger(string fileLocation)
    {
        this.FilePath = fileLocation;
    }

    public void LogInfo(string message)
    {
        File.AppendAllText(FilePath, $"[Info]: [{typeof(T).Name}] : {message}" + '\n');
    }

    public void LogWarning(string message)
    {
        File.AppendAllText(FilePath, $"[Warning] : [{typeof(T).Name}] : {message}" + '\n');
    }

    public void LogError(string message, Exception ex)
    {
        File.AppendAllText(FilePath, $"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}" + '\n');
    }
}

public class People
{
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

class Program
{
   
    public static void Main(string[] args)
    {
        string Test = ".\\test.txt";

        var intLogger = new LocalFileLogger<int>(Test);
        intLogger.LogInfo("LogInfo int!");
        intLogger.LogWarning("LogWarning int!");
        intLogger.LogError("LogError int!",
            new Exception("Exception int!"));

        var stringLogger = new LocalFileLogger<string>(Test);
        stringLogger.LogInfo("LogInfo string!");
        stringLogger.LogWarning("LogWarning string!");
        stringLogger.LogError("LogError string!",
            new Exception("Exception string test text"));

        var studentLogger = new LocalFileLogger<People>(Test);
        studentLogger.LogInfo("LogInfo People!");
        studentLogger.LogWarning("LogWarning People!");
        studentLogger.LogError("LogError People!",
            new Exception("Exception People test text"));
    }
}