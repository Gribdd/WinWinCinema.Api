namespace WinWinCinema.Api.DTOs.Response.Cinema;
public record CinemaResponse(
       Guid Id,
       bool IsDeleted,
       Guid CityId,
       string CityName,
       Guid BarangayId,
       string BarangayName);