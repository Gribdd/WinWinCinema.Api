using WinWinCinema.Api.DTOs.Request.Location;
using WinWinCinema.Api.DTOs.Response.Location;
using WinWinCinema.Api.Services.Interfaces;
using WinWinCinema.Api.UnitOfWork;

namespace WinWinCinema.Api.Services.Implementations;

public class LocationService : ILocationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LocationResponse> CreateLocationAsync(CreateLocationRequest request)
    {
        try
        {
            var locationEntity = _mapper.Map<Location>(request);
            await _unitOfWork.LocationRepository.AddAsync(locationEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<LocationResponse>(locationEntity);
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<LocationResponse>> GetAllLocationsAsync()
    {
        try
        {
            var locations = await _unitOfWork.LocationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LocationResponse>>(locations);
        }
        catch
        {
            throw;
        }
    }

    public async Task<LocationResponse?> GetLocationByIdAsync(Guid id)
    {
        try
        {
            var location = await _unitOfWork.LocationRepository.GetByIdAsync(id);
            if (location == null)
            {
                return null;
            }

            return _mapper.Map<LocationResponse>(location);
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> SoftDeleteLocationAsync(Guid id)
    {
        var location = await _unitOfWork.LocationRepository.GetByIdAsync(id);
        if (location == null)
        {
            return false;
        }

        location.IsDeleted = true;
        await _unitOfWork.LocationRepository.UpdateAsync(location);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> UpdateLocationAsync(Guid id, UpdateLocationRequest request)
    {
        var location = await _unitOfWork.LocationRepository.GetByIdAsync(id);
        if (location == null)
        {
            return false;
        }

        _mapper.Map(request, location);
        await _unitOfWork.LocationRepository.UpdateAsync(location);
        await _unitOfWork.SaveAsync();

        return true;
    }
}
