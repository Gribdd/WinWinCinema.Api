using WinWinCinema.Api.Domain.SupportTickets;

namespace WinWinCinema.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CompletedOrder> CompletedOrders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieSchedule> MovieSchedules { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<SnackOrder> SnackOrders { get; set; }
        public DbSet<SnackStamp> SnackStamps { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
    }
}
