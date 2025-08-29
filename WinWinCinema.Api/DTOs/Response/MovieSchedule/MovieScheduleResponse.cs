namespace WinWinCinema.Api.DTOs.Response.MovieSchedule;

public record MovieScheduleResponse(
    Guid Id,
    bool IsDeleted,
    DateTime ShowTime,
    DateTime EndTime,
    decimal Price,
    Guid CinemaId,
    string CinemaName);