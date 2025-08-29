namespace WinWinCinema.Api.DTOs.Request.Location;

public record CreateLocationRequest(
    string Name,
    double XAxis,
    double YAxis);

