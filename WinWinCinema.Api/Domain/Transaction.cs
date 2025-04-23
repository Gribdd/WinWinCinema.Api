
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Transaction : IEntity
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


    //public ICollection<Guid> SnackStampsGuid { get; set; } = new List<Guid>();
    public ICollection<SnackStamp> SnackStamps { get; set; } = new List<SnackStamp>();

    //public ICollection<Guid> TicketsGuid { get; set; } = new List<Guid>();
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
    
    public string CardHolder { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string Expiry { get; set; } = null!;
    public string CVV { get; set; } = null!;
}