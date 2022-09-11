using DotnetSampleSolution.WebApi.Dtms.LoyaltyCard;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using Xunit;

namespace DotnetSampleSolution.Test
{
    public class LoyaltyCardTests : IClassFixture<WebApiTestFixture>
    {
        private readonly HttpClient _httpClient;

        public LoyaltyCardTests(WebApiTestFixture factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ReturnsCollectionOfLoyaltyCards()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/LoyaltyCards/");
            string contentString = await response.Content.ReadAsStringAsync();
            IEnumerable<LoyaltyCardGetDtm> contentDtos = JsonSerializer.Deserialize<IEnumerable<LoyaltyCardGetDtm>>(contentString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(3, contentDtos.Count());
        }
    }
}