
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Ticket : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
    public Guid MovieScheduleId { get; set; }
    public Guid SeatId { get; set; }
}
