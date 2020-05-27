using System.Threading.Tasks;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.DTOs;

namespace WeatherApp.Services.Interfaces
{
    public interface IForecastApiClient
    {
        Task<ForecastDTO> GetForecast(Location coordinates);
      
    }
}
