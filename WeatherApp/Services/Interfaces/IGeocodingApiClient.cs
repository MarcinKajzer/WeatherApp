using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.DTOs;

namespace WeatherApp.Services.Interfaces
{
    public interface IGeocodingApiClient
    {
        Task<Coordinates> GetCoordinatesByGivenPlaceName(string place);
    }
}
