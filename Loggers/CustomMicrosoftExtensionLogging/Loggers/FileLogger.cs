
using CustomMicrosoftExtensionLogging.Settings;
using System.Globalization;

namespace CustomMicrosoftExtensionLogging.Loggers;

public class FileLogger : ILogger
{
    private readonly FileLoggerConfiguration _configuration;
    private object _lock = new object();
    private readonly CultureInfo _ci = CultureInfo.InvariantCulture;
    public FileLogger(FileLoggerConfiguration loggerConfiguration)
    {
        _configuration = loggerConfiguration;
    }
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    // Check minimum log levels
    public bool IsEnabled(LogLevel logLevel) => logLevel >= _configuration.LogLevel;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        ArgumentNullException.ThrowIfNull(nameof(formatter));
        
        if (!IsEnabled(logLevel)) return;

        var message = formatter(state,exception);
        var logMessage = $"{DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss.ff", _ci)}: [{logLevel.ToString()} : {message}]";
        lock (_lock)
        {
            File.AppendAllText(_configuration.FileName!, logMessage);
        }

    }
}
