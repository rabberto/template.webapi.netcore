using Newtonsoft.Json;
using Template.Webapi.Netcore.CrossCutting.AppSettings.Models;

namespace Template.Webapi.Netcore.CrossCutting.AppSettings
{
    public sealed class LoggingSettings
    {
        [JsonProperty("console")]
        public LoggingConsoleSettings? Console { get; set; }
    }
}