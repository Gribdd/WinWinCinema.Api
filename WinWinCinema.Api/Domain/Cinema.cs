
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Cinema : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }


    [ForeignKey(nameof(CityId))]
    public Guid CityId { get; set; }
    public Location? City { get; set; } 

    [ForeignKey(nameof(BarangayId))]
    public Guid BarangayId { get; set; }
    public Location? Barangay { get; set; }
}
