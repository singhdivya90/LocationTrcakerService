using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LocationTrackService.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace LocationTrackService.Controllers
{
    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    [Route("[controller]")]
    public class LocationTrackerController : ControllerBase
    {


        private readonly ILogger<LocationTrackerController> _logger;

        public LocationTrackerController(ILogger<LocationTrackerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetName()
        {
            return "Hello Divya!";
        }
        


       
        [HttpPost]
        public async Task<LocationDetails> GetLocationDetailsAsync(string ipAddress)
        {
            LocationDetails locationDetails = new LocationDetails();
            using (var httpClient = new HttpClient())
            {
                string url = "https://api.ipgeolocation.io/ipgeo-bulk";
                var parameters = new Dictionary<string, string> { { "apiKey", "91a7b88c701a4ef599c1d49d9c5c8c2a" }, { "ips", "[8.8.8.8,1.1.1.1]" } };
                httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
                httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
                var encodedContent = new FormUrlEncodedContent(parameters);

                var response = await httpClient.PostAsync(url, encodedContent).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                }
            }
            return locationDetails;
        }
    }
}
