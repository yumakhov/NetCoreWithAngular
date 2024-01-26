using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NetCoreWithAngular.Models;
using System.Net.Http.Json;

namespace NetCoreWithAngular.IntegrationTests
{
    public class CardsControllerTests: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CardsControllerTests(WebApplicationFactory<Program> factory) 
        {
            _factory = factory;
        }

        [Fact]
        public async void GetAllCardsAsync()
        {
            // Arrange
            var httpClient = _factory.CreateClient();

            // Act
            var response = await httpClient.GetAsync("/cards");

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IList<CardVM>>();
            Assert.NotNull(result);
            Assert.Equal(6, result.Count);
        }
    }
}