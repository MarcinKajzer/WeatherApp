using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.ForecastDTO_post;

namespace WeatherApp.Services.Interfaces
{
    public interface IForecastApiClient
    {
        Task<ForecastDTO_post> GetForecastByGivenCoordinates(Location coordinates);
    }
}
