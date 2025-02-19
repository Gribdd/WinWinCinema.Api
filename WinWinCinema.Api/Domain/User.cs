
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

public class Address : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Location City { get; set; }
    public ICollection<Location> Barangays { get; set; }
}

public class Location : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public string Name { get; set; } 
    public double XAxis { get; set; }
    public double YAxis { get; set; }
}

public class Cinema : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid CityId { get; set; }
    public Guid BarangayId { get; set; }
}

public class Seat : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsOccupied { get; set; }
}

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

public class MovieSchedule : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public DateTime ShowTime { get; set; }
    public DateTime EndTime { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public Guid CinemaId { get; set; }
    public ICollection<Seat> LeftWingSeats { get; set; } = new List<Seat>();
    public ICollection<Seat> CenterSeats { get; set; } = new List<Seat>();
    public ICollection<Seat> RightWingSeats { get; set; } = new List<Seat>();
}

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

public class Snack : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}

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

public class Order : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
        
    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }

    public MovieSchedule Schedule { get; set; }
    public ICollection<Seat> SelectedSeats { get; set; }
    public ICollection<Snack> SelectedSnacks { get; set; }
    public ICollection<Guid> SnackStamps { get; set; }
    public ICollection<Guid> Tickets { get; set; }

    public string CardHolder { get; set; }
    public string CardNumber { get; set; }
    public string Expiry { get; set; }
    public int CVV { get; set; }
    public int TicketQuantity { get; set; }
}

public class SnackOrder : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid SnackId { get; set; }
    public Snack Snack { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
}

public class SnackStamp : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid UserId { get; set; }
    public Guid SnackId { get; set; }
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
    public Guid MovieScheduledId { get; set; }
}

public class Transaction : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
    public ICollection<Guid> SnackStamps { get; set; }
    public ICollection<Guid> Tickets { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
    
    public string CardHolder { get; set; }
    public string CardNumber { get; set; }
    public string Expiry { get; set; }
    public int CVV { get; set; }
}