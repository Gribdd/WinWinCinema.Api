using WinWinCinema.Api.Repositories.Interfaces;

namespace WinWinCinema.Api.UnitOfWork;

public interface IUnitOfWork
{
    IAddressRepository AddressRepository { get; }
    ICinemaRepository CinemaRepository { get; }
    ICompletedOrderRepository CompletedOrderRepository { get; }
    ILocationRepository LocationRepository { get; }
    IMessageRepository MessageRepository { get; }
    IMovieRepository MovieRepository { get; }
    IMovieScheduleRepository MovieScheduleRepository { get; }
    IOrderRepository OrderRepository { get; }
    ISeatRepository SeatRepository { get; }
    ISnackOrderRepository SnackOrderRepository { get; }
    ISnackRepository SnackRepository { get; }
    ISnackStampRepository SnackStampRepository { get; }
    ISupportTicketRepository SupportTicketRepository { get; }
    ITicketRepository TicketRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    IUserRepository UserRepository { get; }
    Task<int> SaveAsync();
}
