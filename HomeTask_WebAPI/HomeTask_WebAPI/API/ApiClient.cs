using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;

namespace HomeTask_WebAPI.API
{
    public class ApiClient : IApiClient, IDisposable
    {
        readonly RestClient client;
        const string BASE_URL = "https://restful-booker.herokuapp.com/apidoc";

        public ApiClient()
        {
            var options = new RestClientOptions(BASE_URL);
            client = new RestClient(options);
        }

        public async Task<RestResponse> CreateBooking(string payload)
        {
            var request = new RestRequest(Endpoints.CREATE_BOOKING, Method.Post);
            request.AddBody(payload);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> CreateToken(string payload)
        {
            var request = new RestRequest(Endpoints.AUTH, Method.Post);
            request.AddBody(payload);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> DeleteBooking(string id, string user, string password)
        {
            client.Authenticator = new HttpBasicAuthenticator(user, password);
            var request = new RestRequest(Endpoints.DELETE_BOOKING, Method.Delete);
            request.AddUrlSegment(id, id);
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
            request.AddUrlSegment(id, id);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetBookingIDs()
        {
            var request = new RestRequest(Endpoints.GET_BOOKING_ID, Method.Get);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> UpdateBooking(string payload, string id, string user, string password)
        {
            client.Authenticator = new HttpBasicAuthenticator(user, password);
            var request = new RestRequest(Endpoints.UPDATE_BOOKING, Method.Put);
            request.AddUrlSegment(id, id);
            request.AddBody(payload);
            return await client.ExecuteAsync(request);
        }
    }
}
