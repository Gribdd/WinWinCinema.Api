
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Seat : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsOccupied { get; set; }
}
