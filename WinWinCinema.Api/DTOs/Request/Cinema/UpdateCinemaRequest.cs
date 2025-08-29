namespace WinWinCinema.Api.DTOs.Request.Cinema;

public record UpdateCinemaRequest(
    Guid Id,
    bool IsDeleted,
    Guid CityId,
    Guid BarangayId);
