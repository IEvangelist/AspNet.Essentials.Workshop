using AspNet.Essentials.Workshop.Configuration;
using AspNet.Essentials.Workshop.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspNet.Essentials.WorkshopTests
{
    public class BreweryClientTests
    {
        [Fact]
        public async Task GetBeersAsyncReturnsNullOnError()
        {
            // Arrange
            var handler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(handler.Object);

            // Act
            var sut =
                new BreweryClient(
                    httpClient,
                    Options.Create(new BrewerySettings()),
                    NullLogger<BreweryClient>.Instance);

            // Assert
            var results = await sut.GetBeersAsync();
            Assert.Null(results);
        }
    }
}