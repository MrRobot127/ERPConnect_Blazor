using ERPConnect.Api.Extensions;
using log4net.Config;

var builder = WebApplication.CreateBuilder(args);

// Load app settings from appsettings.json or other configuration sources.
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

//Configure Log4net.
XmlConfigurator.Configure(new FileInfo("log4net.config"));

//Injecting services.
builder.Services.RegisterServices(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
