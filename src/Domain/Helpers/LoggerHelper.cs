using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Template.Webapi.Netcore.Domain.Helpers;

public static class LoggerFactoryHelper
{
    private readonly static string _enableLog = AppSettings.Settings.Log.Console.Enabled;
    private readonly static string _minimumLevel = AppSettings.Settings.Log.Console.MinimumLevel;
    private readonly static string _directoryPath = AppSettings.Settings.Log.Console.GetDirectoryPath();

    public static void StartOperationLog(this ILogger logger, string methodName, Guid correlationId)
    {
        var logMessage = BuildLogMessage($"Start: {methodName} | CorrelationId: {correlationId}");

        logger.LogInformation(logMessage);
    }

    public static void EndOperationLog(this ILogger logger, string methodName, Guid correlationId)
    {
        var logMessage = BuildLogMessage($"End: {methodName} | CorrelationId: {correlationId}");

        logger.LogInformation(logMessage);
    }

    public static void InformationOperationLog(this ILogger logger, string methodName, Guid correlationId, string message)
    {
        var logMessage = BuildLogMessage($"Information: {methodName} | CorrelationId: {correlationId} | {message}");

        logger.LogInformation(logMessage);
    }

    public static void ErrorOperationLog(this ILogger logger, string methodName, Guid correlationId, string message)
    {
        var logMessage = BuildLogMessage($"Error: {methodName} | CorrelationId: {correlationId} | {message}");

        logger.LogError(logMessage);
    }

    public static void DebugOperationLog(this ILogger logger, string methodName, Guid correlationId, string message)
    {
        var logMessage = BuildLogMessage($"Debug: {methodName} | CorrelationId: {correlationId} | {message}");

        logger.LogDebug(logMessage);
    }

    public static void WarningOperationLog(this ILogger logger, string methodName, Guid correlationId, string message)
    {
        var logMessage = BuildLogMessage($"Warning: {methodName} | CorrelationId: {correlationId} | {message}");

        logger.LogWarning(logMessage);
    }

    private static string BuildLogMessage(string prefix)
    {
        var logMessage = new StringBuilder();
        logMessage.Append($"{DateTimeHelper.GetDateTimeToString()} | ");
        logMessage.Append(prefix);
        logMessage.Append(" [{methodName}{correlationId}]");
        return logMessage.ToString();
    }

    public static void LogConfiguration(this IServiceCollection services)
    {
        ValidateLogFilePath();

        services.AddLogging(builder =>
        {
            LogLevel logLevel = (LogLevel)Enum.Parse(typeof(LogLevel), _minimumLevel);
            builder.SetMinimumLevel(logLevel);
            builder.AddProvider(new LoggerExtension($"{_directoryPath}/client.log"));

            if (bool.Parse(_enableLog))
                builder.AddConsole();
        });
    }

    private static void ValidateLogFilePath()
    {
        if (!Directory.Exists(_directoryPath))
            Directory.CreateDirectory(_directoryPath);
    }
}
