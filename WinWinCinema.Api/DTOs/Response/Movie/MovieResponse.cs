namespace WinWinCinema.Api.DTOs.Response.Movie
{
    public record MovieResponse(
        Guid Id,
        bool IsDeleted,
        string Title,
        string Description,
        string Distributor,
        string FeaturedImage,
        string BannerImage);
}
