
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class MovieSchedule : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public DateTime ShowTime { get; set; }
    public DateTime EndTime { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [ForeignKey(nameof(CinemaId))]
    public Guid CinemaId { get; set; }
    public Cinema? Cinema { get; set; }

    [ForeignKey(nameof(MovieId))]
    public Guid MovieId { get; set; }
    public Movie? Movie { get; set; }

    public ICollection<CompletedOrder> CompletedOrders { get; set; } = new List<CompletedOrder>();

    //public ICollection<Seat> LeftWingSeats { get; set; } = new List<Seat>();
    //public ICollection<Seat> CenterSeats { get; set; } = new List<Seat>();
    //public ICollection<Seat> RightWingSeats { get; set; } = new List<Seat>();
}
