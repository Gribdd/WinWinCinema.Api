using Bogus;

namespace WinWinCinema.Api.Data;

internal class FakeDataGenerator
{
    public List<User> GenerateUsers(int count, List<Location> locations)
    {
        var userFaker = new Faker<User>()
            .RuleFor(u => u.FName, f => f.Name.FirstName())
            .RuleFor(u => u.LName, f => f.Name.LastName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => f.Internet.Password())
            .RuleFor(u => u.MobileNumber, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Birthday, f => DateOnly.FromDateTime(f.Date.Past(30, DateTime.Now.AddYears(-18)))) // Generate DateOnly
            .RuleFor(u => u.CardHolder, f => f.Name.FullName()) // Generating a random cardholder name
            .RuleFor(u => u.CardNumber, f => f.Finance.CreditCardNumber())
            .RuleFor(u => u.Expiry, f => $"{f.Random.Int(1, 12):00}/{f.Random.Int(23, 30)}") // Manually generating expiry in MM/YY format
            .RuleFor(u => u.CVV, f => f.Finance.CreditCardCvv())
            .RuleFor(u => u.CityId, f => locations[f.Random.Int(0, locations.Count - 1)].Id)
            .RuleFor(u => u.BarangayId, f => locations[f.Random.Int(0, locations.Count - 1)].Id);

        return userFaker.Generate(count);
    }

    public List<Location> GenerateLocations(int count)
    {
        var locationFaker = new Faker<Location>()
            .RuleFor(l => l.Name, f => f.Address.City())
            .RuleFor(l => l.XAxis, f => f.Random.Double(-180, 180))
            .RuleFor(l => l.YAxis, f => f.Random.Double(-90, 90));

        return locationFaker.Generate(count);
    }

    public List<Cinema> GenerateCinemas(List<Location> locations, int count)
    {
        var cinemaFaker = new Faker<Cinema>()
            .RuleFor(c => c.CityId, f => locations[f.Random.Int(0, locations.Count - 1)].Id)
            .RuleFor(c => c.BarangayId, f => locations[f.Random.Int(0, locations.Count - 1)].Id);

        return cinemaFaker.Generate(count);
    }
    public List<Movie> GenerateMovies(List<Cinema> cinemas, int count)
    {
        var movieFaker = new Faker<Movie>()
            .RuleFor(m => m.Title, f => f.Lorem.Sentence(3, 2)) // e.g. "The Lost Horizon"
            .RuleFor(m => m.Description, f => f.Lorem.Paragraph())
            .RuleFor(m => m.Distributor, f => f.Company.CompanyName())
            .RuleFor(m => m.FeaturedImage, f => f.Image.PicsumUrl(640, 480)) // Placeholder image URLs
            .RuleFor(m => m.BannerImage, f => f.Image.PicsumUrl(1280, 720));
        return movieFaker.Generate(count);
    }

    public List<SupportTicket> GenerateSupportTickets(List<User> users, int count)
    {
        var supportTicketFaker = new Faker<SupportTicket>()
            .RuleFor(s => s.Subject, f => f.Lorem.Sentence())
            .RuleFor(s => s.UserId, f => users[f.Random.Int(0, users.Count - 1)].Id);

        return supportTicketFaker.Generate(count);
    }

    public List<MovieSchedule> GenerateMovieSchedules(List<Cinema> cinemas, List<Movie> movies, int count)
    {
        var movieScheduleFaker = new Faker<MovieSchedule>()
            .RuleFor(m => m.ShowTime, f => f.Date.Future()) // Generate a future showtime
            .RuleFor(m => m.EndTime, (f, m) => m.ShowTime.AddMinutes(f.Random.Int(90, 180))) // EndTime is ShowTime + a random duration (90 to 180 minutes)
            .RuleFor(m => m.Price, f => f.Finance.Amount(100, 500)) // Random price between 100 and 500
            .RuleFor(m => m.CinemaId, f => cinemas[f.Random.Int(0, cinemas.Count - 1)].Id) // Randomly assign a CinemaId
            .RuleFor(m => m.MovieId, f => movies[f.Random.Int(0, movies.Count - 1)].Id);
        return movieScheduleFaker.Generate(count);
    }

    public List<Seat> GenerateSeats(int count)
    {
        var seatFaker = new Faker<Seat>()
            .RuleFor(s => s.Row, f => f.Random.Int(1, 20))               // Example: Row numbers 1–20
            .RuleFor(s => s.Column, f => f.Random.Int(1, 30))            // Example: Columns 1–30
            .RuleFor(s => s.IsOccupied, f => f.Random.Bool());                   // Randomly true/false

        return seatFaker.Generate(count);
    }

    public List<Snack> GenerateSnacks(int count)
    {
        var snackFaker = new Faker<Snack>()
            .RuleFor(s => s.Price, f => f.Random.Decimal(50, 300)) 
            .RuleFor(s => s.Name, f => f.Commerce.ProductName())
            .RuleFor(s => s.Description, f => f.Commerce.ProductDescription())
            .RuleFor(s => s.Image, f => f.Image.PicsumUrl(width: 640, height: 480)); 

        return snackFaker.Generate(count);
    }

    public List<SnackOrder> GenerateSnackOrders(List<Snack> snacks, int count)
    {
        var snackOrderFaker = new Faker<SnackOrder>()
            .RuleFor(o => o.Snack, f => f.PickRandom(snacks))
            .RuleFor(o => o.SnackId, (f, o) => o.Snack.Id)
            .RuleFor(o => o.Quantity, f => f.Random.Int(1, 5))
            .RuleFor(o => o.TotalPrice, (f, o) => o.Snack.Price * o.Quantity);

        return snackOrderFaker.Generate(count);
    }

    public List<SnackStamp> GenerateSnackStamps(
        List<User> users,
        List<Snack> snacks,
        List<Movie> movies,
        List<Cinema> cinemas,
        List<MovieSchedule> schedules,
        int count)
    {
        var faker = new Faker<SnackStamp>()
            .RuleFor(s => s.UserId, f => f.PickRandom(users).Id)
            .RuleFor(s => s.SnackId, f => f.PickRandom(snacks).Id)
            .RuleFor(s => s.MovieId, f => f.PickRandom(movies).Id)
            .RuleFor(s => s.CinemaId, f => f.PickRandom(cinemas).Id)
            .RuleFor(s => s.MovieScheduledId, f => f.PickRandom(schedules).Id);

        return faker.Generate(count);
    }

    public List<Ticket> GenerateTickets(
        List<User> users,
        List<Movie> movies,
        List<Cinema> cinemas,
        List<MovieSchedule> schedules,
        List<Seat> seats,
        int count)
    {
        var faker = new Faker<Ticket>()
            .RuleFor(t => t.UserId, f => f.PickRandom(users).Id)
            .RuleFor(t => t.MovieId, f => f.PickRandom(movies).Id)
            .RuleFor(t => t.CinemaId, f => f.PickRandom(cinemas).Id)
            .RuleFor(t => t.MovieScheduleId, f => f.PickRandom(schedules).Id)
            .RuleFor(t => t.SeatId, f => f.PickRandom(seats).Id)
            .RuleFor(t => t.CreatedAt, f => f.Date.Past())
            .RuleFor(t => t.UpdatedAt, f => null)
            .RuleFor(t => t.IsDeleted, f => false);

        return faker.Generate(count);
    }

    public List<Transaction> GenerateTransactions(
        List<User> users,
        List<Movie> movies,
        List<Cinema> cinemas,
        List<SnackStamp> snackStamps,
        List<Ticket> tickets,
        int count)
    {

        var faker = new Faker<Transaction>()
            .RuleFor(t => t.UserId, f => f.PickRandom(users).Id)
            .RuleFor(t => t.MovieId, f => f.PickRandom(movies).Id)
            .RuleFor(t => t.CinemaId, f => f.PickRandom(cinemas).Id)
            .RuleFor(t => t.SnackStamps, f => snackStamps)
            .RuleFor(t => t.Tickets, f => tickets)
            .RuleFor(t => t.CardHolder, f => f.Name.FullName())
            .RuleFor(t => t.CardNumber, f => f.Finance.CreditCardNumber())
            .RuleFor(t => t.Expiry, f => f.Date.FutureOffset().ToString("MM/yy"))
            .RuleFor(t => t.CVV, f => f.Finance.CreditCardCvv());
        return faker.Generate(count);
    }


}
