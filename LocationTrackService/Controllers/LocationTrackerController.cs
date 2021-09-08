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
        public string GetLocationDetails(string ipAddress)
        {
            string result = string.Empty;

            using (var webClient = new WebClient())
            {
                string url = "https://api.ipgeolocation.io/ipgeo";
               
                webClient.Headers.Add("Content-Type", "application/json");
                webClient.QueryString.Add("apiKey", "d361545d809a403f89a3232691f22c46");
                webClient.QueryString.Add("ip", ipAddress);
                result = webClient.DownloadString(url);
            }
            return result;
        }
       


    }
}
