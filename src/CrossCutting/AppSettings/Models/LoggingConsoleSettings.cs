using Newtonsoft.Json;

namespace Template.Webapi.Netcore.CrossCutting.AppSettings.Models;

public sealed class LoggingConsoleSettings()
{

    [JsonProperty("enable")]
    public bool Enable { get; set; }
    [JsonProperty("minimumLevel")]
    public string? MinimumLevel { get; set; }

    [JsonProperty("directoryPath")]
    private string? DirectoryPath { get; set; }
    
    public string GetDirectoryPath()
    {
        if (string.IsNullOrWhiteSpace(DirectoryPath))
            return string.Empty;

        if (DirectoryPath.Contains("{enviroment}"))
            return string.Format(DirectoryPath, AppSettings.Settings.Enviroment);

        return DirectoryPath;
    }    
}