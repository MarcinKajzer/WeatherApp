using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IGeocodingService
    {
        Task<CoordinatesParsed> GetCoordinates(string place);
    }
}
