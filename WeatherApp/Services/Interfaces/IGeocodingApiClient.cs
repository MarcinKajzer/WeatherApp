using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;

namespace WeatherApp.Services.Interfaces
{
    interface IGeocodingApiClient
    {
        Task<Coordinates> GetCoordinatesByGivenPlaceName(string place);
    }
}
