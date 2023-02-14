
namespace Restful_Booker_API.Model.Request
{
    public class PartialBooking
    {
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public BookingDates bookingdates { get; set; }
        public string additionalneeds { get; set; }
    }
}
