namespace WinWinCinema.Api.DTOs.Response.User;

public record UserResponse(
    Guid Id,
    string FName,
    string LName,
    string Email,
    string MobileNumber,
    DateOnly Birthday,
    string CardHolder,
    string MaskedCardNumber,
    string Expiry,
    Guid? CityId,
    string? CityName,
    Guid? BarangayId,
    string? BarangayName);