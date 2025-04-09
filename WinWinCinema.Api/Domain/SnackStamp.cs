
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class SnackStamp : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid UserId { get; set; }
    public Guid SnackId { get; set; }
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
    public Guid MovieScheduledId { get; set; }
}
