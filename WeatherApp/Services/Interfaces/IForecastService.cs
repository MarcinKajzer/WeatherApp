using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.DTOs;

namespace WeatherApp.Services.Interfaces
{
    public interface IForecastService
    {
        Task<ForecastDTO> GetForecast(CoordinatesParsed coord);
    }
}
