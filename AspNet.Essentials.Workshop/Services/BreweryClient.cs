using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Configuration;
using AspNet.Essentials.Workshop.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNet.Essentials.Workshop.Services
{
    public class BreweryClient : IBreweryClient
    {
        readonly HttpClient _client;
        readonly BrewerySettings _brewerySettings;

        public BreweryClient(HttpClient client, IOptions<BrewerySettings> options)
        {
            _client = client;
            _brewerySettings = options?.Value;
        }

        public async Task<Results> GetBeersAsync()
        {
            var beersJson = 
                await _client.GetStringAsync(
                    $"beers?key={_brewerySettings.ApiKey}&order=random&randomCount=10");

            return JsonConvert.DeserializeObject<Results>(beersJson);
        }
    }
}