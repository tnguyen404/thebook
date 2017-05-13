using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TheBook.Service
{
    public class GeoCoordsService
    {
        private IConfigurationRoot _config;
        private ILogger<GeoCoordsService> _logger;

        public GeoCoordsService(ILogger<GeoCoordsService>logger, IConfigurationRoot config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<GeCoordsResult> GetCoordsAsync(string nameOfStop)
        {
            var result = new GeCoordsResult() {
                Success = false,
                Message="Fail to load geocoords service"                
            };
            var apiKey = _config["Key:BingKey_2"];
            var encodeName = WebUtility.UrlEncode(nameOfStop);
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodeName}&key={apiKey}";

            var client = new HttpClient();
            var jsonResult =await client.GetStringAsync(url);
            var results = JObject.Parse(jsonResult);

            return result;
        }
    }
}
