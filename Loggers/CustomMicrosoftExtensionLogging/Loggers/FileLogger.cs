
using CustomMicrosoftExtensionLogging.Settings;

namespace CustomMicrosoftExtensionLogging.Loggers;

public class FileLogger : ILogger
{
    private readonly FileLoggerConfiguration _configuration;
    public FileLogger(FileLoggerConfiguration loggerConfiguration)
    {
        _configuration = loggerConfiguration;
    }
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    // Check minimum log levels
    public bool IsEnabled(LogLevel logLevel) => logLevel >= _configuration.LogLevel;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        throw new NotImplementedException();
    }
}
