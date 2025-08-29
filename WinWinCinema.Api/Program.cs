using WinWinCinema.Api.Extensions;
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplicationServices()
    .AddDatabaseService(builder.Configuration)
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddConsole();
        loggingBuilder.AddDebug();
    })
    .AddSwaggerGen()
    .AddControllers();


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.WithSwagger();
        await app.InitializeDatabase(); // reset db
        app.SeedFakeData();            // insert bogus data
    }

    app.MapControllers();
    await app.RunAsync();
}