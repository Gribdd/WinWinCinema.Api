
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Transaction : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
    public ICollection<Guid> SnackStamps { get; set; }
    public ICollection<Guid> Tickets { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
    
    public string CardHolder { get; set; }
    public string CardNumber { get; set; }
    public string Expiry { get; set; }
    public int CVV { get; set; }
}