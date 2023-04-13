using LoyaltyCardManager.Test.Fixtures;
using LoyaltyCardManager.WebApi.Dtms.LoyaltyCard;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace LoyaltyCardManager.Test.IntegrationTests
{
    public class LoyaltyCardTests : IClassFixture<WebApiTestFixture>, IDisposable
    {
        private readonly HttpClient _httpClient;

        public LoyaltyCardTests(WebApiTestFixture factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetById_WhenIdIsValid_ReturnLoyaltyCard()
        {
            // Arrange
            LoyaltyCardPostDtm postDto = new()
            {
                MerchantName = "Mc donald's",
                MembershipId = "1234"
            };

            HttpResponseMessage postResponse = await _httpClient.PostAsJsonAsync("/api/loyalty-cards", postDto);

            // Act
            HttpResponseMessage getResponse = await _httpClient.GetAsync(postResponse.Headers.Location!.LocalPath);
            LoyaltyCardGetDtm? getDto = await getResponse.Content.ReadFromJsonAsync<LoyaltyCardGetDtm>();
            await _httpClient.DeleteAsync(postResponse.Headers.Location.LocalPath);

            // Assert
            Assert.NotNull(getDto);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(postDto.MerchantName, getDto.MerchantName);
            Assert.Equal(postDto.MembershipId, getDto.MembershipId);
        }

        [Fact]
        public async Task GetAll_ReturnsCollectionOfLoyaltyCards()
        {
            // Arrange
            LoyaltyCardPostDtm postDto1 = new()
            {
                MerchantName = "Mc donald's",
                MembershipId = "1234"
            };

            LoyaltyCardPostDtm postDto2 = new()
            {
                MerchantName = "Kentucky Fried Chicken",
                MembershipId = "abcd"
            };


            HttpResponseMessage postResponse1 = await _httpClient.PostAsJsonAsync("/api/loyalty-cards", postDto1);
            HttpResponseMessage postResponse2 = await _httpClient.PostAsJsonAsync("/api/loyalty-cards", postDto2);

            // Act
            HttpResponseMessage getResponse = await _httpClient.GetAsync("/api/loyalty-cards");
            IEnumerable<LoyaltyCardGetDtm> getDtos = (await getResponse.Content.ReadFromJsonAsync<IEnumerable<LoyaltyCardGetDtm>>())!.OrderByDescending(p => p.Id);
            LoyaltyCardGetDtm getDto1 = getDtos.ElementAt(1);
            LoyaltyCardGetDtm getDto2 = getDtos.ElementAt(0);
            await _httpClient.DeleteAsync(postResponse1.Headers.Location!.LocalPath);
            await _httpClient.DeleteAsync(postResponse2.Headers.Location!.LocalPath);

            // Assert
            Assert.NotNull(getDto1);
            Assert.NotNull(getDto2);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(postDto1.MerchantName, getDto1.MerchantName);
            Assert.Equal(postDto1.MembershipId, getDto1.MembershipId);
            Assert.Equal(postDto2.MerchantName, getDto2.MerchantName);
            Assert.Equal(postDto2.MembershipId, getDto2.MembershipId);
        }

        [Fact]
        public async Task Add_WhenDtoIsValid_InsertNewLoyaltyCard()
        {
            // Arrange
            LoyaltyCardPostDtm postDto = new()
            {
                MerchantName = "Kentucky Fried Chicken",
                MembershipId = "abcd"
            };

            // Act
            HttpResponseMessage postResponse = await _httpClient.PostAsJsonAsync("/api/loyalty-cards", postDto);
            LoyaltyCardGetDtm? getDto = await _httpClient.GetFromJsonAsync<LoyaltyCardGetDtm>(postResponse.Headers.Location!.LocalPath);
            await _httpClient.DeleteAsync(postResponse.Headers.Location!.LocalPath);

            // Assert
            Assert.NotNull(getDto);
            Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);
            Assert.Equal(postDto.MerchantName, getDto.MerchantName);
            Assert.Equal(postDto.MembershipId, getDto.MembershipId);
        }

        [Fact]
        public async Task Update_WhenIdIsValid_UpdateLoyaltyCard()
        {
            // Arrange
            LoyaltyCardPostDtm postDto = new()
            {
                MerchantName = "Kentucky Fried Chicken",
                MembershipId = "abcd"
            };
            HttpResponseMessage postResponse = await _httpClient.PostAsJsonAsync("/api/loyalty-cards", postDto);
            LoyaltyCardPutDtm putDto = new()
            {
                MerchantName = "Mc donald's",
                MembershipId = "abcd"
            };

            // Act
            HttpResponseMessage putResponse = await _httpClient.PutAsJsonAsync(postResponse.Headers.Location!.LocalPath, putDto);
            HttpResponseMessage getResponse = await _httpClient.GetAsync(postResponse.Headers.Location!.LocalPath);
            LoyaltyCardGetDtm? getDto = await getResponse.Content.ReadFromJsonAsync<LoyaltyCardGetDtm>();
            await _httpClient.DeleteAsync(postResponse.Headers.Location!.LocalPath);

            // Assert
            Assert.NotNull(putResponse);
            Assert.Equal(HttpStatusCode.NoContent, putResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(putDto.MerchantName, getDto.MerchantName);
            Assert.Equal(putDto.MembershipId, getDto.MembershipId);
        }

        [Fact]
        public async Task Delete_WhenIdIsValid_DeleteLoyaltyCard()
        {
            // Arrange
            LoyaltyCardPostDtm postDto = new()
            {
                MerchantName = "Kentucky Fried Chicken",
                MembershipId = "abcd"
            };
            HttpResponseMessage postResponse = await _httpClient.PostAsJsonAsync("/api/loyalty-cards", postDto);

            // Act
            HttpResponseMessage deleteResponse = await _httpClient.DeleteAsync(postResponse.Headers.Location!.LocalPath);
            HttpResponseMessage getResponse = await _httpClient.GetAsync(postResponse.Headers.Location!.LocalPath);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}