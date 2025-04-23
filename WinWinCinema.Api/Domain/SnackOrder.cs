
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class SnackOrder : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(SnackId))]
    public Guid SnackId { get; set; }
    public Snack? Snack { get; set; }

    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
}
