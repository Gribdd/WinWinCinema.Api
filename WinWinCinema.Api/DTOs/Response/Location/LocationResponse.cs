namespace WinWinCinema.Api.DTOs.Response.Location;

public record LocationResponse(
    Guid Id,
    bool IsDeleted,
    string Name,
    double XAxis,
    double YAxis);
