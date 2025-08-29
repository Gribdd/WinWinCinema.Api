namespace WinWinCinema.Api.DTOs.Request.MovieSchedule;

public record UpdateMovieScheduleRequest(
    Guid Id,
    bool IsDeleted,
    DateTime ShowTime,
    DateTime EndTime,
    decimal Price,
    Guid CinemaId);
