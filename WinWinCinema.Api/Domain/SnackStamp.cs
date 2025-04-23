
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class SnackStamp : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }


    [ForeignKey(nameof(UserId))]
    public Guid UserId { get; set; }
    public User? User { get; set; }


    [ForeignKey(nameof(SnackId))]
    public Guid SnackId { get; set; }
    public Snack? Snack { get; set; }


    [ForeignKey(nameof(MovieId))]
    public Guid MovieId { get; set; }
    public Movie? Movie { get; set; }


    [ForeignKey(nameof(CinemaId))]
    public Guid CinemaId { get; set; }
    public Cinema? Cinema { get; set; }


    [ForeignKey(nameof(MovieScheduledId))]
    public Guid MovieScheduledId { get; set; }
    public MovieSchedule? MovieScheduled { get; set; }
}
