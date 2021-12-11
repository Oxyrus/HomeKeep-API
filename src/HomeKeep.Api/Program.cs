using HomeKeep.Application;
using HomeKeep.Infrastructure;
using Serilog;

var builder = WebApplication
    .CreateBuilder(args);

// Setup dependency injection across projects
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure logger
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// Build the web application, all configurations must be done prior to this
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Starting the application...");
    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "There was an issue during start up");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }
