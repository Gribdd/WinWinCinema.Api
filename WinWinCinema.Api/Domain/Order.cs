
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Order : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(UserId))]
    public Guid UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey(nameof(MovieId))]
    public Guid MovieId { get; set; }
    public Movie? Movie { get; set; }

    [ForeignKey(nameof(CinemaId))]
    public Guid CinemaId { get; set; }
    public Cinema? Cinema { get; set; }

    [ForeignKey(nameof(ScheduleId))]
    public Guid ScheduleId { get; set; }
    public MovieSchedule? Schedule { get; set; }

    public ICollection<Seat> SelectedSeats { get; set; } = new List<Seat>();
    public ICollection<Snack> SelectedSnacks { get; set; } = new List<Snack>();

    //public ICollection<Guid> SnackStampsGuid { get; set; } = new List<Guid>();
    public ICollection<Snack> SnackStamps { get; set; } = new List<Snack>();

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    //public ICollection<Guid> TicketGuid { get; set; } = new List<Guid>();


    public string CardHolder { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string Expiry { get; set; } = null!;
    public int CVV { get; set; }
    public int TicketQuantity { get; set; }
}
