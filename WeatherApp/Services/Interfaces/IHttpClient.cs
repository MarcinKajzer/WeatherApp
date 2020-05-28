using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Services.Interfaces
{
    public interface IHttpClient
    {
        Task<string> Get(string url);
    }
}
