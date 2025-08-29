using WinWinCinema.Api.DTOs.Request.Location;
using WinWinCinema.Api.DTOs.Response.Location;

namespace WinWinCinema.Api.Mappings;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<CreateLocationRequest, Location>();
        CreateMap<UpdateLocationRequest, Location>();
        CreateMap<Location, LocationResponse>();
    }
}
