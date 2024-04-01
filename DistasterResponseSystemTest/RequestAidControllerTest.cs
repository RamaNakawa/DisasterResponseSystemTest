using DisasterResponseSystem.Core;
using DisasterResponseSystem.Models;
using DisasterResponseSystem.PostModels;
using DisasterResponseSystem.ResponseModels;
using DistasterResponseSystemTest.Setup;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DistasterResponseSystemTest
{
    public class RequestAidControllerTest(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async void AddAidRequestSuccessTest()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "/v1/AidRequest");
            var jsonContent = JsonSerializer.Serialize(new AidRequestPost
            {
                Name = "I Need House",
                Brief = "I Need House I Need House I Need House I Need House I Need House I Need House",
                RequestedDonation = 5000
            });
            request.Content = new StringContent(jsonContent,Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void GetAidRequestsSuccessTest()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "/v1/AidRequest");
            var jsonContent = JsonSerializer.Serialize(new AidRequestPost
            {
                Name = "I Need House",
                Brief = "I Need House I Need House I Need House I Need House I Need House I Need House",
                RequestedDonation = 5000
            });
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);

            request = new HttpRequestMessage(HttpMethod.Get, "/v1/AidRequests");
            response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var val = JsonSerializer.Deserialize<ListResponse<AidRequestResponse>>(content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void UpdateAidRequestRankAndStatusSuccessTest()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "/v1/AidRequest");
            var jsonContent = JsonSerializer.Serialize(new AidRequestPost
            {
                Name = "I Need House",
                Brief = "I Need House I Need House I Need House I Need House I Need House I Need House",
                RequestedDonation = 5000
            });
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var val = JsonSerializer.Deserialize<long>(content);

            request = new HttpRequestMessage(HttpMethod.Post, $"/v1/AidRequest/{val}");
            jsonContent = JsonSerializer.Serialize(new EditAidRequestPost
            {
              Rank = (int)RankEnum.High,
              Status = (int)StatusEnum.Open,
            });
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ProcessAidRequestSuccessTest()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "/v1/AidRequest");
            var jsonContent = JsonSerializer.Serialize(new AidRequestPost
            {
                Name = "I Need House",
                Brief = "I Need House I Need House I Need House I Need House I Need House I Need House",
                RequestedDonation = 5000
            });
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var val = JsonSerializer.Deserialize<long>(content);

            request = new HttpRequestMessage(HttpMethod.Post, $"/v1/AidRequest/Process/{val}");
            jsonContent = JsonSerializer.Serialize(new ProcessAidRequestPost
            {
               Value = 200
            });
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}