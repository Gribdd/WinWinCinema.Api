
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class CompletedOrder : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }


    [ForeignKey(nameof(MovieId))]
    public Guid MovieId { get; set; }
    public Movie? Movie { get; set; }

    [ForeignKey(nameof(CinemaId))]
    public Guid CinemaId { get; set; }
    public Cinema? Cinema { get; set; }

    [ForeignKey(nameof(ScheduleId))]
    public Guid ScheduleId { get; set; }
    public MovieSchedule? Schedule { get; set; } 
}
