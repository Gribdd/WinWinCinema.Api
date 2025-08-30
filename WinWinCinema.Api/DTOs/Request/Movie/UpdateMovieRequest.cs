namespace WinWinCinema.Api.DTOs.Request.Movie
{
    public record UpdateMovieRequest(
        Guid Id,
        bool IsDeleted,
        string Title,
        string Description,
        string Distributor,
        string FeaturedImage,
        string BannerImage);
}
