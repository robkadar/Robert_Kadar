using RestSharp;
using System.Threading.Tasks;

namespace HomeTask_WebAPI.API
{
    public interface IApiClient
    {
        Task<RestResponse> CreateBooking(string payload);
        Task<RestResponse> UpdateBooking(string payload, string id, string user, string password);
        Task<RestResponse> DeleteBooking(string id, string user, string password);
        Task<RestResponse> GetBooking(string id);
        Task<RestResponse> GetBookingIDs();
        Task<RestResponse> CreateToken(string payload);
    }
}
