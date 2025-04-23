
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Snack : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
}
