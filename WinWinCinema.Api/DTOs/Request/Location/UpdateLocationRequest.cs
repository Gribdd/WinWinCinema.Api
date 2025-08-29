namespace WinWinCinema.Api.DTOs.Request.Location;

public record UpdateLocationRequest(
    Guid Id,
    string Name,
    double XAxis,
    double YAxis);
