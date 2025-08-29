namespace WinWinCinema.Api.DTOs.Request.Cinema;

public record CreateCinemaRequest(
    Guid CityId,
    Guid BarangayId);
