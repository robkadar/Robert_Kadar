using Restful_Booker_API.Model.Request;

namespace Restful_Booker_API.Model.Response
{
    public class BookingResponse
    {
        public int bookingid { get; set; }
        public Booking booking { get; set; }
    }
}
