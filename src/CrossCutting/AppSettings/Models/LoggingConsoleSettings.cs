using Newtonsoft.Json;

namespace Template.Webapi.Netcore.CrossCutting.AppSettings.Models;

public sealed class LoggingConsoleSettings
{
    [JsonProperty("enable")]
    public bool Enable { get; set; }
    [JsonProperty("logLevel")]
    public string? LogLevel { get; set; }
}