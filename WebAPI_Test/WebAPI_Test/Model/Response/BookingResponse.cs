using WebAPI_Test.Model.Request;

namespace WebAPI_Test.Model.Response
{
    class BookingResponse
    {
        public int bookingid { get; set; }
        public Booking booking { get; set; }
    }
}
