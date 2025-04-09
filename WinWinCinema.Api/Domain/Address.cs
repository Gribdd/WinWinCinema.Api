
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Address : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Location City { get; set; }
    public ICollection<Location> Barangays { get; set; }
}
