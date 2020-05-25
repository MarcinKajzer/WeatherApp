using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models.Coordinates;
using WeatherApp.Models.ForecastDTO_post;
using WeatherApp.Services;
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
        public async Task<ActionResult<ForecastDTO_post>> Get([Required] string name)
        {
            Coordinates coord = await _geocodingClient.GetCoordinatesByGivenPlaceName(name);
           
            if (coord.Results == null || !coord.Results.Any())
            {
                return BadRequest();
            }

            ForecastDTO_post forecast = await _forecastClient.GetForecastByGivenCoordinates(coord.Results[0]
                                                             .Geometry.Location);

            if (forecast == null)
            {
                return BadRequest();
            }

            return forecast;
        }
    }

}
