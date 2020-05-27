using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models.DTOs;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IGeocodingApiClient _geocodingClient;
        private readonly IForecastApiClient _forecastClient;

        public WeatherForecastController(IGeocodingApiClient geocodingClient, 
                                        IForecastApiClient forecastClient)
        {
            _geocodingClient = geocodingClient;
            _forecastClient = forecastClient;
        }

        
        [HttpGet]
        public async Task<ActionResult<ForecastDTO>> Get([Required] string name)
        {
            Coordinates coord = await _geocodingClient.GetCoordinatesByGivenPlaceName(name);
           
            if (coord.Results == null || !coord.Results.Any())
            {
                return BadRequest();
            }

            ForecastDTO forecast = await _forecastClient.GetForecast(coord.Results[0].Geometry.Location);

            if (forecast == null)
            {
                return BadRequest();
            }
            
            forecast.ThreeHoursForecast.PlaceInfo.City = coord.Results[0].FormattedAddress;

            return forecast;
        }
    }

}
