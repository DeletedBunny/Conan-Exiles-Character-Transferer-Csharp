using System;

#if DEBUG
namespace ConanExilesCharacterTransfererCsharp;

public static class Debug
{
    public static void LogInfo(string message)
    {
        Log("INFO", message);
    }
    
    public static void LogError(string message)
    {
        Log("ERROR", message);
    }
    
    public static void LogWarning(string message)
    {
        Log("WARNING", message);
    }

    private static void Log(string logType, string message)
    {
        Console.WriteLine($"{DateTime.Now} | {logType} | {message}");
    }
}
#endif