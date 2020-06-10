using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.DTOs;
using WeatherApp.DTOs.DTOs;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IGeocodingService _geocodingService;
        private readonly IForecastService _forecastService;

        public WeatherForecastController(IGeocodingService geocodingClient, 
                                        IForecastService forecastClient)
        {
            _geocodingService = geocodingClient;
            _forecastService = forecastClient;
        }

        [Route("forecast")]
        [HttpGet]
        public async Task<ActionResult<Forecast>> GetByPlace([Required] string place)
        {
            CoordinatesParsed coord = await _geocodingService.GetCoordinates(place);
           
            if (coord == null)
            {
                return BadRequest();
            }

            Forecast forecast = await _forecastService.Get(coord);

            if (forecast == null)
            {
                return BadRequest();
            }
            
            forecast.ThreeHoursForecast.PlaceInfo.City = coord.Place;

            return forecast;
        }

    }

}
