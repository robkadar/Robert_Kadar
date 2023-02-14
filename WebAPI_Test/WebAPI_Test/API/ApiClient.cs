using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
using WebAPI_Test.Utils;

namespace WebAPI_Test.API
{
    public class ApiClient : IApiClient, IDisposable
    {
        readonly RestClient client;
        const string BASE_URL = "https://restful-booker.herokuapp.com";

        public ApiClient() 
        {
            var options = new RestClientOptions(BASE_URL);
            client = new RestClient(options);
        }
        public async Task<RestResponse> CreateBooking<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_BOOKING, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            RestResponse response = await client.ExecuteAsync<T>(request);
            var content = response.Content;
            return response;
        }

        public async Task<RestResponse> CreateToken<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.AUTH, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> DeleteBooking(string id, string user, string password)
        {
            client.Authenticator = new HttpBasicAuthenticator(user, password);
            var request = new RestRequest(Endpoints.DELETE_BOOKING, Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddUrlSegment("id", id);
            return await client.ExecuteAsync(request);
        }

        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse> GetBooking(string id)
        {
            var request = new RestRequest(Endpoints.GET_BOOKING, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddUrlSegment("id", id);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetBookingIDs()
        {
            var request = new RestRequest(Endpoints.GET_BOOKING_ID, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> UpdateBooking<T>(T payload, string id, string user, string password) where T : class
        {
            client.Authenticator = new HttpBasicAuthenticator(user, password);
            var request = new RestRequest(Endpoints.UPDATE_BOOKING, Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddUrlSegment("id", id);
            request.AddBody(payload);
            RestResponse response = await client.ExecuteAsync<T>(request);
            var content = response.Content;
            return response;
        }
    }
}
