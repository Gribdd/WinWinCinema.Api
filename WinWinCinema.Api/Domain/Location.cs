
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

public class Location : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public string Name { get; set; }  = string.Empty;
    public double XAxis { get; set; }
    public double YAxis { get; set; }
}
