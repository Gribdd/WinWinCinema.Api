using WinWinCinema.Api.Repositories;
using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IAddressRepository AddressRepository { get; }
    public ICinemaRepository CinemaRepository { get; }
    public ICompletedOrderRepository CompletedOrderRepository { get; }
    public ILocationRepository LocationRepository { get; }
    public IMessageRepository MessageRepository { get; }
    public IMovieRepository MovieRepository { get; }
    public IMovieScheduleRepository MovieScheduleRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public ISeatRepository SeatRepository { get; }
    public ISnackOrderRepository SnackOrderRepository { get; }
    public ISnackRepository SnackRepository { get; }
    public ISnackStampRepository SnackStampRepository { get; }
    public ISupportTicketRepository SupportTicketRepository { get; }
    public ITicketRepository TicketRepository { get; }
    public ITransactionRepository TransactionRepository { get; }
    public IUserRepository UserRepository { get; }


    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        AddressRepository = new AddressRepository(_context);
        CinemaRepository = new CinemaRepository(_context);
        CompletedOrderRepository = new CompletedOrderRepository(_context);
        LocationRepository = new LocationRepository(_context);
        MessageRepository = new MessageRepository(_context);
        MovieRepository = new MovieRepository(_context);
        MovieScheduleRepository = new MovieScheduleRepository(_context);
        OrderRepository = new OrderRepository(_context);
        SeatRepository = new SeatRepository(_context);
        SnackOrderRepository = new SnackOrderRepository(_context);
        SnackRepository = new SnackRepository(_context);
        SnackStampRepository = new SnackStampRepository(_context);
        SupportTicketRepository = new SupportTicketRepository(_context);
        TicketRepository = new TicketRepository(_context);
        TransactionRepository = new TransactionRepository(_context);
        UserRepository = new UserRepository(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
