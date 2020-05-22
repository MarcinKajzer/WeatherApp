using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.ForecastDTO_post;

namespace WeatherApp.Services.Interfaces
{
    public interface IForecastService
    {
        Task<ForecastDTO_post> GetForecastByCoordinates(Location coordinates);
    }
}
