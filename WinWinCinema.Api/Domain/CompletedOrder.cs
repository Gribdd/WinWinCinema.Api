
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class CompletedOrder : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
    public MovieSchedule Schedule { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}
