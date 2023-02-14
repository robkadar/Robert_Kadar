using RestSharp;
using System.Threading.Tasks;

namespace Restful_Booker_API.API
{
    public interface IApiClient
    {
        Task<RestResponse> CreateBooking<T>(T payload) where T : class;
        Task<RestResponse> UpdateBooking<T>(T payload, string id, string user, string password) where T : class;
        Task<RestResponse> DeleteBooking(string id, string user, string password);
        Task<RestResponse> GetBooking(string id);
        Task<RestResponse> GetBookingIDs();
        Task<RestResponse> CreateToken<T>(T payload) where T : class;
    }
}
