using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();

builder.Services.Configure<PostgresSettings>(
                builder.Configuration.GetSection("PostgresSettings"));

builder.Services.AddApplication(configuration);

// Add health check flows
builder.Services.AddHealthChecks();

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ServiceExtensions.RunDBMigration(builder.Services);

app.UseRouting();
app.MapControllers();

app.Run();