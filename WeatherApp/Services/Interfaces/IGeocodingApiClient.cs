using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;

namespace WeatherApp.Services.Interfaces
{
    public interface IGeocodingApiClient
    {
        Task<Coordinates> GetCoordinatesByGivenPlaceName(string place);
    }
}
