using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful_Booker_API.Model.Request
{
    public class BookingBuilder
    {
        private Booking booking = new Booking();
        private PartialBooking partialBooking = new PartialBooking();

        public BookingBuilder SetFirstName(string fName)
        {
            booking.firstname = fName;
            return this;
        }

        public BookingBuilder SetLastName(string lName)
        {
            booking.lastname = lName;
            return this;
        }

        public BookingBuilder SetTotalPrice(int tPrice)
        {
            partialBooking.totalprice = tPrice;
            booking.totalprice = tPrice;
            return this;
        }

        public BookingBuilder SetDepositPaid(bool dPaid)
        {
            partialBooking.depositpaid = dPaid;
            booking.depositpaid = dPaid;
            return this;
        }

        public BookingBuilder SetBookingDates(string chkIn, string chkOut)
        {
            partialBooking.bookingdates = new BookingDates
            {
                checkin = chkIn,
                checkout = chkOut
            };

            booking.bookingdates = new BookingDates
            {
                checkin = chkIn,
                checkout = chkOut
            };
            return this;
        }

        public BookingBuilder SetAdditionalNeeds(string addNeeds)
        {
            //partialBooking.additionalneeds = addNeeds;
            booking.additionalneeds = addNeeds;
            return this;
        }

        public PartialBooking PartialBookingBuild()
        {
            return partialBooking;
        }
        public Booking BookingBuild()
        {
            return booking;
        }
    }
}
