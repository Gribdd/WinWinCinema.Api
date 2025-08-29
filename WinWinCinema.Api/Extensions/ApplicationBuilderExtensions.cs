using System.Threading.Tasks;

namespace WinWinCinema.Api.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static void SeedFakeData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();
        var fakeDataGenerator = new FakeDataGenerator();

        // Only seed if empty (avoid duplicate records on each run)
        if (!context.Locations.Any())
        {
            var locations = fakeDataGenerator.GenerateLocations(10);
            context.Locations.AddRange(locations);
            context.SaveChanges();

            var users = fakeDataGenerator.GenerateUsers(50, locations);
            context.Users.AddRange(users);
            context.SaveChanges();

            var cinemas = fakeDataGenerator.GenerateCinemas(locations, 5);
            context.Cinemas.AddRange(cinemas);
            context.SaveChanges();

            var movies = fakeDataGenerator.GenerateMovies(cinemas, 20);
            context.Movies.AddRange(movies);
            context.SaveChanges();

            var supportTickets = fakeDataGenerator.GenerateSupportTickets(users, 30);
            context.SupportTickets.AddRange(supportTickets);
            context.SaveChanges();

            var movieSchedules = fakeDataGenerator.GenerateMovieSchedules(cinemas, movies, 50);
            context.MovieSchedules.AddRange(movieSchedules);
            context.SaveChanges();

            var seats = fakeDataGenerator.GenerateSeats(100);
            context.Seats.AddRange(seats);
            context.SaveChanges();

            var snacks = fakeDataGenerator.GenerateSnacks(15);
            context.Snacks.AddRange(snacks);
            context.SaveChanges();

            var snackOrders = fakeDataGenerator.GenerateSnackOrders(snacks, 40);
            context.SnackOrders.AddRange(snackOrders);
            context.SaveChanges();

            var snackStamps = fakeDataGenerator.GenerateSnackStamps(users, snacks, movies, cinemas, movieSchedules, 30);
            context.SnackStamps.AddRange(snackStamps);
            context.SaveChanges();

            var tickets = fakeDataGenerator.GenerateTickets(users, movies, cinemas, movieSchedules, seats, 50);
            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            var transactions = fakeDataGenerator.GenerateTransactions(users, movies, cinemas, snackStamps, tickets, 50);
            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }
    }

    public static async Task<IApplicationBuilder> InitializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating or initializing the database.");
        }
        return app;
    }

}
