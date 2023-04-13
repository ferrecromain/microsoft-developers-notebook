using LoyaltyCardManager.Test.Fixtures;
using System.Net.Http.Json;
using System.Net;
using Xunit;
using LoyaltyCardManager.WebApi.Dtms.Group;
using LoyaltyCardManager.WebApi.Dtms.LoyaltyCard;

namespace LoyaltyCardManager.Test.IntegrationTests
{
    public class GroupTests : IClassFixture<WebApiTestFixture>, IDisposable
    {
        private readonly HttpClient _httpClient;

        public GroupTests(WebApiTestFixture factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task GetById_WhenIdIsValid_ReturnGroup()
        {
            // Arrange
            GroupPostDtm postDto = new()
            {
                Name = "Restaurants",
                Description = "Fast food, casual, fine dining..."
            };

            HttpResponseMessage postResponse = await _httpClient.PostAsJsonAsync("/api/groups", postDto);

            // Act
            HttpResponseMessage getResponse = await _httpClient.GetAsync(postResponse.Headers.Location!.LocalPath);
            GroupGetDtm? getDto = await getResponse.Content.ReadFromJsonAsync<GroupGetDtm>();
            await _httpClient.DeleteAsync(postResponse.Headers.Location.LocalPath);

            // Assert
            Assert.NotNull(getDto);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(postDto.Name, getDto.Name);
            Assert.Equal(postDto.Description, getDto.Description);
        }

        [Fact]
        public async Task GetAll_ReturnsCollectionOfGroups()
        {
            // Arrange
            GroupPostDtm postDto1 = new()
            {
                Name = "Restaurants",
                Description = "Fast food, casual, fine dining..."
            };

            GroupPostDtm postDto2 = new()
            {
                Name = "Food shops",
                Description = "Grocery, supermarket.."
            };


            HttpResponseMessage postResponse1 = await _httpClient.PostAsJsonAsync("/api/groups", postDto1);
            HttpResponseMessage postResponse2 = await _httpClient.PostAsJsonAsync("/api/groups", postDto2);

            // Act
            HttpResponseMessage getResponse = await _httpClient.GetAsync("/api/groups");
            IEnumerable<GroupGetDtm> getDtos = (await getResponse.Content.ReadFromJsonAsync<IEnumerable<GroupGetDtm>>())!.OrderByDescending(p => p.Id);
            GroupGetDtm getDto1 = getDtos.ElementAt(1);
            GroupGetDtm getDto2 = getDtos.ElementAt(0);
            await _httpClient.DeleteAsync(postResponse1.Headers.Location!.LocalPath);
            await _httpClient.DeleteAsync(postResponse2.Headers.Location!.LocalPath);

            // Assert
            Assert.NotNull(getDto1);
            Assert.NotNull(getDto2);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(postDto1.Name, getDto1.Name);
            Assert.Equal(postDto1.Description, getDto1.Description);
            Assert.Equal(postDto2.Name, getDto2.Name);
            Assert.Equal(postDto2.Description, getDto2.Description);
        }

        [Fact]
        public async Task Add_WhenDtoIsValid_InsertNewGroup()
        {
            // Arrange
            GroupPostDtm postDto = new()
            {
                Name = "Restaurants",
                Description = "Fast food, casual, fine dining..."
            };

            // Act
            HttpResponseMessage postResponse = await _httpClient.PostAsJsonAsync("/api/groups", postDto);
            GroupGetDtm? getDto = await _httpClient.GetFromJsonAsync<GroupGetDtm>(postResponse.Headers.Location!.LocalPath);
            await _httpClient.DeleteAsync(postResponse.Headers.Location!.LocalPath);

            // Assert
            Assert.NotNull(getDto);
            Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);
            Assert.Equal(postDto.Name, getDto.Name);
            Assert.Equal(postDto.Description, getDto.Description);
        }

        [Fact]
        public async Task Update_WhenIdIsValid_UpdateGroup()
        {
            // Arrange
            GroupPutDtm postDto = new()
            {
                Name = "Restaurants",
                Description = "Fast food, casual, fine dining..."
            };
            HttpResponseMessage postResponse = await _httpClient.PostAsJsonAsync("/api/groups", postDto);
            GroupPutDtm putDto = new()
            {
                Name = "Food shops",
                Description = "Grocery, supermarket.."
            };

            // Act
            HttpResponseMessage putResponse = await _httpClient.PutAsJsonAsync(postResponse.Headers.Location!.LocalPath, putDto);
            HttpResponseMessage getResponse = await _httpClient.GetAsync(postResponse.Headers.Location!.LocalPath);
            GroupGetDtm? getDto = await getResponse.Content.ReadFromJsonAsync<GroupGetDtm>();
            await _httpClient.DeleteAsync(postResponse.Headers.Location!.LocalPath);

            // Assert
            Assert.NotNull(putResponse);
            Assert.Equal(HttpStatusCode.NoContent, putResponse.StatusCode);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(putDto.Name, getDto.Name);
            Assert.Equal(putDto.Description, getDto.Description);
        }

        [Fact]
        public async Task Delete_WhenIdIsValid_DeleteGroup()
        {
            // Arrange
            GroupPostDtm postDto = new()
            {
                Name = "Food shops",
                Description = "Grocery, supermarket.."
            };
            HttpResponseMessage postResponse = await _httpClient.PostAsJsonAsync("/api/groups", postDto);

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
