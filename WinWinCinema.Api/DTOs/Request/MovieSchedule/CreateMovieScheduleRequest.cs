namespace WinWinCinema.Api.DTOs.Request.MovieSchedule;


public record CreateMovieScheduleRequest(
    DateTime ShowTime,
    DateTime EndTime,
    decimal Price,
    Guid CinemaId);
