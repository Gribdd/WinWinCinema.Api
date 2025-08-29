namespace WinWinCinema.Api.DTOs.Request.User;

public record CreateUserRequest(
    string FName,
    string LName,
    string Email,
    string Password,
    string MobileNumber,
    DateOnly Birthday,
    string CardHolder,
    string CardNumber,
    string Expiry,
    string CVV,
    Guid? CityId,
    Guid? BarangayId);
