using Microsoft.EntityFrameworkCore;

namespace WinWinCinema.Api.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Apply any pending migrations

            // Seed the database
            await SeedUsersAsync(context);
        }
    }

    private static async Task SeedUsersAsync(ApplicationDbContext context)
    {
        if (!await context.Users.AnyAsync())
        {
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    FName = "John",
                    LName = "Doe",
                    Email = "johndoe@example.com",
                    Password = "hashedpassword123", // Hash before use
                    MobileNumber = "09123456789",
                    Birthday = new DateOnly(1995, 5, 15),
                    CardHolder = "John Doe",
                    CardNumber = "4111111111111111",
                    Expiry = "12/26",
                    CVV = "123",
                    CityId = Guid.NewGuid(),
                    BarangayId = Guid.NewGuid(),
                    IsDeleted = false,
                    FavoriteMovies = new List<Guid>()
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    FName = "Jane",
                    LName = "Smith",
                    Email = "janesmith@example.com",
                    Password = "hashedpassword456",
                    MobileNumber = "09987654321",
                    Birthday = new DateOnly(1998, 8, 20),
                    CardHolder = "Jane Smith",
                    CardNumber = "5500000000000004",
                    Expiry = "07/25",
                    CVV = "456",
                    CityId = Guid.NewGuid(),
                    BarangayId = Guid.NewGuid(),
                    IsDeleted = false,
                    FavoriteMovies = new List<Guid>()
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    FName = "Alice",
                    LName = "Johnson",
                    Email = "alicejohnson@example.com",
                    Password = "hashedpassword789",
                    MobileNumber = "09223334455",
                    Birthday = new DateOnly(2000, 12, 5),
                    CardHolder = "Alice Johnson",
                    CardNumber = "340000000000009",
                    Expiry = "09/27",
                    CVV = "789",
                    CityId = Guid.NewGuid(),
                    BarangayId = Guid.NewGuid(),
                    IsDeleted = false,
                    FavoriteMovies = new List<Guid>()
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
