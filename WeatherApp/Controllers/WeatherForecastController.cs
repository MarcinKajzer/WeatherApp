using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApp.Models.DTOs;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IGeocodingService _geocodingClient;
        private readonly IForecastService _forecastClient;

        public WeatherForecastController(IGeocodingService geocodingClient, 
                                        IForecastService forecastClient)
        {
            _geocodingClient = geocodingClient;
            _forecastClient = forecastClient;
        }

        
        [HttpGet]
        public async Task<ActionResult<ForecastDTO>> Get([Required] string place)
        {
            CoordinatesParsed coord = await _geocodingClient.GetCoordinates(place);
           
            if (coord == null)
            {
                return BadRequest();
            }

            ForecastDTO forecast = await _forecastClient.GetForecast(coord);

            if (forecast == null)
            {
                return BadRequest();
            }
            
            forecast.ThreeHoursForecast.PlaceInfo.City = coord.Place;

            return forecast;
        }
    }

}
