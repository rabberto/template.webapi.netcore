namespace Template.Webapi.Netcore.Domain.Extensions;

using Microsoft.Extensions.Logging;

public sealed class LoggerExtension : ILoggerProvider
{
    private readonly string _filePath;

    public LoggerExtension(string filePath)
    {
        _filePath = filePath;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(_filePath);
    }

    public void Dispose()
    {
    }
}

public class FileLogger : ILogger
{
    private readonly string _filePath;
    private readonly object _lockObject = new object();

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        string logMessage = formatter(state, exception);

        lock (_lockObject)
        {
            File.AppendAllText(_filePath, logMessage + Environment.NewLine);
        }
    }
}