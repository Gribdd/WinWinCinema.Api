
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Movie : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Distributor { get; set; } = null!;
    public string FeaturedImage { get; set; } = null!;
    public string BannerImage { get; set; } = null!;

    public ICollection<MovieSchedule> Schedules { get; set; } = new List<MovieSchedule>();
}
