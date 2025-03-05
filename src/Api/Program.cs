using Elastic.CommonSchema;
using Template.Webapi.Netcore.CrossCutting.AppSettings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Adds data from appsettings.json to Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Configura o Serilog a partir do appsettings.json
Serilog.Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Api", Version = "v1" });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

// Loads all the contents of appsettings.json into the AppSettings class
var appSettings = builder.Configuration.Get<AppSettings>() ?? throw new Exception("AppSettings not found");

AppSettings.Initialize(appSettings);

app.Run();