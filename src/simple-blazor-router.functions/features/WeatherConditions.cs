using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using simple_blazor_router.application.WeatherConditions;
using System.Linq;
using System.Collections.Generic;

namespace simple_blazor_router.functions.features
{
    public class WeatherConditions
    {
        private readonly IWeatherConditionsProvider _weatherConditionsProvider;

        public WeatherConditions(IWeatherConditionsProvider weatherConditionsProvider)
        {
            _weatherConditionsProvider = weatherConditionsProvider;
        }

        [FunctionName("weather-conditions")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            string id = req.Query["id"];

            string responseMessage = "";

            if(string.IsNullOrEmpty(id))
                responseMessage = JsonConvert.SerializeObject(_weatherConditionsProvider.Get().ToList());   
            else 
                responseMessage = JsonConvert.SerializeObject(_weatherConditionsProvider.Get(int.Parse(id)));

            return new OkObjectResult(responseMessage);
        }
    }
}