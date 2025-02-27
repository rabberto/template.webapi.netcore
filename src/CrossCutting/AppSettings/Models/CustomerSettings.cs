using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Template.Webapi.Netcore.CrossCutting.AppSettings.Models;

public sealed class CustomerSettings
{
    [JsonProperty("id")]
    public string? Id { get; set; }
    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("subscriptionKey")]
    public string? SubscriptionKey { get; set; }
    [JsonProperty("connectionString")]
    public string? ConnectionString { get; set; }
}