
namespace HomeTask_WebAPI.Model
{
    partial class Booking
    {
        public int bookingid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public BookingDates bookingdates { get; set; }
        public string additionalneeds { get; set; }
    }
    partial class BookingDates
    {
        //private Booking obj;
        public string checkin { get; set; }
        public string checkout { get; set; }
    }
}
