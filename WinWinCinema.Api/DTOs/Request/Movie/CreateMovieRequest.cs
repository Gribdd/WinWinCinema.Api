namespace WinWinCinema.Api.DTOs.Request.Movie
{
    public record CreateMovieRequest(
        string Title,
        string Description,
        string Distributor,
        string FeaturedImage,
        string BannerImage);
}
