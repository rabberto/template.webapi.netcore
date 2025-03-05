using Newtonsoft.Json;
using Template.Webapi.Netcore.CrossCutting.AppSettings.Models;

namespace Template.Webapi.Netcore.CrossCutting.AppSettings;

public sealed class AppSettings()
{
    private static AppSettings? _instance;

    public static AppSettings Settings => _instance ?? throw new InvalidOperationException("AppSettings is not initialized.");

    public static void Initialize(AppSettings settings)
    {
        if (_instance != null)
            throw new InvalidOperationException("AppSettings is already initialized.");

        _instance = settings;
    }

    [JsonProperty("enviroment")]
    public string? Enviroment { get; set; }
    [JsonProperty("logging")]
    public LoggingSettings? Logging { get; set; }
    [JsonProperty("customers")]
    public IEnumerable<CustomerSettings>? Customers { get; set; }

    public bool ValidateSubscriptionKey(string subscriptionKey)
        => Customers != null && Customers.Any(x => x.SubscriptionKey != null && x.SubscriptionKey.Equals(subscriptionKey));
}