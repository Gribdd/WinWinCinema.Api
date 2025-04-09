
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Order : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
        
    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }

    public MovieSchedule Schedule { get; set; }
    public ICollection<Seat> SelectedSeats { get; set; }
    public ICollection<Snack> SelectedSnacks { get; set; }
    public ICollection<Guid> SnackStamps { get; set; }
    public ICollection<Guid> Tickets { get; set; }

    public string CardHolder { get; set; }
    public string CardNumber { get; set; }
    public string Expiry { get; set; }
    public int CVV { get; set; }
    public int TicketQuantity { get; set; }
}
