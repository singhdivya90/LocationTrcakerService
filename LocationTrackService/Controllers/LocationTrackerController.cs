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
        private readonly IConfiguration _configuration;

        public LocationTrackerController(ILogger<LocationTrackerController> logger,IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }

       
        
        [HttpGet]
        public string GetLocationDetails(string ipAddress)
        {
            string result = string.Empty;

            using (var webClient = new WebClient())
            {
                string url = _configuration.GetValue<string>("URL");
                string apiKey = _configuration.GetValue<string>("ApiKey");
                webClient.Headers.Add("Content-Type", "application/json");
                webClient.QueryString.Add("apiKey", apiKey);
                webClient.QueryString.Add("ip", ipAddress);
                result = webClient.DownloadString(url);
            }
            return result;
        }
       


    }
}
