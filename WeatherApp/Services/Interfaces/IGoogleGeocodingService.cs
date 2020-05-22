using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;

namespace WeatherApp.Services.Interfaces
{
    interface IGoogleGeocodingService
    {
        Task<Location> GetCoordinatesByGivenPlaceName(string place);
    }
}
