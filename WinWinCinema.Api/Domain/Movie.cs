
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Movie : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Distributor { get; set; }
    public string FeaturedImage { get; set; }
    public string BannerImage { get; set; }

    public ICollection<Guid> CinemasGuid { get; set; }
    public ICollection<MovieSchedule> Schedules { get; set; }
}
