
namespace WebAPI_Test.Model.Request
{
    public class PartialBooking
    {
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public BookingDates bookingdates { get; set; }
        public string additionalneeds { get; set; }

    }
}
