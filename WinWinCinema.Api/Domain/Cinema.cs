
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Cinema : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid CityId { get; set; }
    public Guid BarangayId { get; set; }
}
