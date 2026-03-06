namespace FoodCampus.Infrastructure.Logging;

public interface IAppLogger<T>
{
    void LogInfo(string message);
    void LogError(string message, Exception? ex = null);
}

public class AppLogger<T> : IAppLogger<T>
{
    public void LogInfo(string message) => Console.WriteLine($"[INFO][{typeof(T).Name}]: {message}");
    public void LogError(string message, Exception? ex = null)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR][{typeof(T).Name}]: {message}");
        if (ex != null) Console.WriteLine($"Detalle: {ex.Message}");
        Console.ForegroundColor = originalColor;
    }
}
