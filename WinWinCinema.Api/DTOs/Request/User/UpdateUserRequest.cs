namespace WinWinCinema.Api.DTOs.Request.User;

public record UpdateUserRequest(
    Guid Id,
    string? FName,
    string? LName,
    string? Email,
    string? Password,        
    string? MobileNumber,
    DateOnly? Birthday,
    string? CardHolder,
    string? CardNumber,
    string? Expiry,
    string? CVV,
    bool? IsDeleted,
    Guid? CityId,
    Guid? BarangayId);