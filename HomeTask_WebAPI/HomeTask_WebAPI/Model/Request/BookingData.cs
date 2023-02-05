using Newtonsoft.Json;

namespace HomeTask_WebAPI.Model.Request
{
    public class BookingData
    {
        public string BookingInfo(string firstName, string lastName, int totalPrice, bool depositPaid, string checkIn, string checkOut, string additionalNeeds)
        {
            var model = new Booking
            {
                firstname = firstName,
                lastname = lastName,
                totalprice = totalPrice,
                depositpaid = depositPaid,
                bookingdates = new BookingDates
                {
                    checkin = checkIn,
                    checkout = checkOut
                },
                additionalneeds = additionalNeeds
            };

            var output = JsonConvert.SerializeObject(model, Formatting.Indented);
            return output;
        }

        public string BookingInfoFail(string firstName, string lastName, int totalPrice, bool depositPaid)
        {
            var model = new Booking
            {
                firstname = firstName,
                lastname = lastName,
                totalprice = totalPrice,
                depositpaid = depositPaid
            };

            var output = JsonConvert.SerializeObject(model, Formatting.Indented);
            return output;
        }
    }
}
