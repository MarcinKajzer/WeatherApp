using System.Threading.Tasks;
using WeatherApp.DTOs;
using WeatherApp.DTOs.Coordinates;
using WeatherApp.DTOs.DTOs;

namespace WeatherApp.Services.Interfaces
{
    public interface IForecastService
    {
        Task<Forecast> Get(CoordinatesParsed coord);
    }
}
