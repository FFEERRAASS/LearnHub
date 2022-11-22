using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LearnHub.Core.Data;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("Weather/{city}")]
        public async Task<Weather> City(string city)
        {
            using (var clinet = new HttpClient())
            {
                var response = await clinet.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=51ec744f85929e0ba1941687f587002f");
                var stringResult = await response.Content.ReadAsStringAsync();// result as string 
                var weatherResult = JsonConvert.DeserializeObject<Weather>(stringResult); //convert from string to json format  

                return weatherResult;
            }
        }
    }
}
