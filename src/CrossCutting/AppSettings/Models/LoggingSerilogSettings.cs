namespace Template.Webapi.Netcore.CrossCutting.AppSettings.Models
{
    public class LoggingSerilogSettings
    {
        public bool Enabled { get; set; }
        public string? MinimumLevel { get; set; }
    }

    public class LoggingSerilogWritToSettings
    {
        public string? Name { get; set; }
        public IDictionary<string,string>? Args { get; set; }
    }
}