using Microsoft.Extensions.DependencyInjection;
using NetCoreWithAngular.DAL.Abstract;
using NetCoreWithAngular.Models;
using System.Net.Http.Json;

namespace NetCoreWithAngular.IntegrationTests
{
    public class CardsControllerTests: IClassFixture<TestWebApplicationFactory<Program>>
    {
        private const string BaseUrl = "/cards";

        private readonly TestWebApplicationFactory<Program> _factory;
        private readonly IServiceProvider _serviceProvider;

        public CardsControllerTests(TestWebApplicationFactory<Program> factory) 
        {
            _factory = factory;
            _serviceProvider = factory.Services;
        }

        [Fact]
        public async void GetAllCardsAsync()
        {
            // Arrange
            var httpClient = _factory.CreateClient();

            // Act
            var response = await httpClient.GetAsync(BaseUrl);

            // Assert
            var result = await DeserializeResponseAsync<IList<CardVM>>(response);
            Assert.NotNull(result);
            Assert.Equal(6, result.Count);
        }

        [Fact]
        public async void CreateCardAsync()
        {
            // Arrange
            var httpClient = _factory.CreateClient();
            var data = new CardDataVM
            {
                Name = "Test Name",
                ItemsCount = 375
            };

            // Act
            var response = await httpClient.PostAsJsonAsync(BaseUrl, data);

            // Assert
            var result = await DeserializeResponseAsync<CardVM>(response);
            Assert.NotNull(result);
            Assert.Equal(data.Name, result.Name);
            Assert.Equal(data.ItemsCount, result.ItemsCount);

            using var scope = _serviceProvider.CreateScope();
            var cardsRepository = scope.ServiceProvider.GetRequiredService<ICardsRepository>();
            var createdCard = await cardsRepository.GetAsync(result.Id);
            Assert.NotNull(createdCard);
            Assert.Equal(data.Name, createdCard.Name);
            Assert.Equal(data.ItemsCount, createdCard.ItemsCount);

            await cardsRepository.DeleteAsync(createdCard.Id);
        }

        private static async Task<T?> DeserializeResponseAsync<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}