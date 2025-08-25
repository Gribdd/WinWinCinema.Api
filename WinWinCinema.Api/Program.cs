using Microsoft.Extensions.Hosting;
using WinWinCinema.Api.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<ApplicationDbContext>( x => {
    var connectionString = builder.Configuration.GetConnectionString("DbConnection");
    x.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Call the FakeDataGenerator to generate fake data in development mode
    using (var scope = app.Services.CreateScope())
    {
        var fakeDataGenerator = new FakeDataGenerator();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Ensure the database is deleted
        //dbContext.Database.EnsureDeleted();

        // Ensure the database is created
        dbContext.Database.EnsureCreated();

        // Generate fake data for each entity and save it to the database

        // Locations
        var locations = fakeDataGenerator.GenerateLocations(10); // Generate 10 locations
        dbContext.Locations.AddRange(locations);
        dbContext.SaveChanges();

        // Users
        var users = fakeDataGenerator.GenerateUsers(50, locations); // Generate 50 users with location data
        dbContext.Users.AddRange(users);
        dbContext.SaveChanges();

        // Cinemas
        var cinemas = fakeDataGenerator.GenerateCinemas(locations, 5); // Generate 5 cinemas
        dbContext.Cinemas.AddRange(cinemas);
        dbContext.SaveChanges();

        // Movies
        var movies = fakeDataGenerator.GenerateMovies(cinemas, 20); // Generate 20 movies
        dbContext.Movies.AddRange(movies);
        dbContext.SaveChanges();

        // Support Tickets
        var supportTickets = fakeDataGenerator.GenerateSupportTickets(users, 30); // Generate 30 support tickets
        dbContext.SupportTickets.AddRange(supportTickets);
        dbContext.SaveChanges();

        // Movie Schedules
        var movieSchedules = fakeDataGenerator.GenerateMovieSchedules(cinemas, 50); // Generate 50 movie schedules
        dbContext.MovieSchedules.AddRange(movieSchedules);
        dbContext.SaveChanges();

        // Seats
        var seats = fakeDataGenerator.GenerateSeats(100); // Generate 100 seats
        dbContext.Seats.AddRange(seats);
        dbContext.SaveChanges();

        // Snacks
        var snacks = fakeDataGenerator.GenerateSnacks(15); // Generate 15 snacks
        dbContext.Snacks.AddRange(snacks);
        dbContext.SaveChanges();

        // Snack Orders
        var snackOrders = fakeDataGenerator.GenerateSnackOrders(snacks, 40); // Generate 40 snack orders
        dbContext.SnackOrders.AddRange(snackOrders);
        dbContext.SaveChanges();

        // Snack Stamps
        var snackStamps = fakeDataGenerator.GenerateSnackStamps(
            users,
            snacks,
            movies,
            cinemas,
            movieSchedules,
            30); // Generate 30 snack stamps
        dbContext.SnackStamps.AddRange(snackStamps);
        dbContext.SaveChanges();

        // Tickets
        var tickets = fakeDataGenerator.GenerateTickets(
            users,
            movies,
            cinemas,
            movieSchedules,
            seats,
            50); // Generate 50 tickets
        dbContext.Tickets.AddRange(tickets);
        dbContext.SaveChanges();

        // Transactions
        var transactions = fakeDataGenerator.GenerateTransactions(
            users,
            movies,
            cinemas,
            snackStamps,
            tickets,
            50); // Generate 50 transactions
        dbContext.Transactions.AddRange(transactions);
        dbContext.SaveChanges();
    }

}



app.MapControllers();
app.Run();

