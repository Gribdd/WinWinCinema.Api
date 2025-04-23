
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

//note: if you want to add Relationships put an instance of the class in the class that you want to have a relationship with
//example: public User User { get; set; } and not public Guid UserId { get; set; }
//note: if you want to have a collection of a class put ICollection<ClassName> instead of ClassName
//example: public ICollection<User> Users { get; set; } and not public Guid UserId { get; set; }
public class User : IEntity
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public string FName { get; set; } = null!;
    public string LName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string MobileNumber { get; set; } = null!;
    public DateOnly Birthday { get; set; }  
    public string CardHolder { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string Expiry { get; set; } = null!;
    public string CVV { get; set; } = null!;

    [ForeignKey(nameof(CityId))]
    public Guid? CityId { get; set; }
    public Location? City { get; set; }

    [ForeignKey(nameof(BarangayId))]
    public Guid? BarangayId { get; set; }
    public Location? Barangay { get; set; } 
    //public ICollection<Guid> FavoriteMovies { get; set; } = new List<Guid>();
}
