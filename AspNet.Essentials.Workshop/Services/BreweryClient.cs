using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Configuration;
using AspNet.Essentials.Workshop.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNet.Essentials.Workshop.Services
{
    public class BreweryClient : IBreweryClient
    {
        readonly HttpClient _client;
        readonly ILogger<BreweryClient> _logger;
        readonly string _apiKey;

        public BreweryClient(
            HttpClient client,
            IOptions<BrewerySettings> options,
            ILogger<BreweryClient> logger)
        {
            _client = client;
            _logger = logger;
            _apiKey = options?.Value?.ApiKey;
        }

        public async Task<Results> GetBeersAsync()
        {
            try
            {
                var results =
                    await _client.GetStringAsync(
                        $"beers?key={_apiKey}&order=random&randomCount=10");

                return JsonConvert.DeserializeObject<Results>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return null;
        }
    }
}