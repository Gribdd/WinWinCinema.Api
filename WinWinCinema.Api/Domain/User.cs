
using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain;

//note: if you want to add Relationships put an instance of the class in the class that you want to have a relationship with
//example: public User User { get; set; } and not public Guid UserId { get; set; }
//note: if you want to have a collection of a class put ICollection<ClassName> instead of ClassName
//example: public ICollection<User> Users { get; set; } and not public Guid UserId { get; set; }
public class User : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string MobileNumber { get; set; }
    public DateOnly Birthday { get; set; }
    public string CardHolder { get; set; }
    public string CardNumber { get; set; }
    public string Expiry { get; set; }
    public string CVV { get; set; }

    public Guid CityId { get; set; }
    public Guid BarangayId { get; set; }
    public ICollection<Guid> FavoriteMovies { get; set; }
}
