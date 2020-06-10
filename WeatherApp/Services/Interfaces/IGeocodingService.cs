using System.Threading.Tasks;
using WeatherApp.DTOs;

namespace WeatherApp.Services.Interfaces
{
    public interface IGeocodingService
    {
        Task<CoordinatesParsed> GetCoordinates(string place);
    }
}
