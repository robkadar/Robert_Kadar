using NUnit.Framework;
using Restful_Booker_API.API;
using Restful_Booker_API.Model.Request;
using Restful_Booker_API.Model.Response;
using Restful_Booker_API.Utils;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Restful_Booker_API.Tests.BDD.Steps
{
    [Binding]
    public class ApiTestStepDefinitions
    {
        private Booking _bookingBuilder;
        private PartialBooking _partialBookingBuilder;
        private ScenarioContext _scenarioContext;
        private HttpStatusCode _statusCode;
        RestResponse response;
        string payload;
        string id = "1";
        string username = "admin";
        string password = "password123";
        string userFail = "";
        string passwordFail = "";

        public ApiTestStepDefinitions(Booking bookingBuilder, PartialBooking partialBookingBuilder, ScenarioContext scenarioContext)
        {
            _bookingBuilder = bookingBuilder;
            _partialBookingBuilder = partialBookingBuilder;
            _scenarioContext = scenarioContext;
        }

        [Given(@"Having the booking info")]
        public void GivenHavingTheBookingInfo()
        {
            _bookingBuilder = new BookingBuilder()
                .SetFirstName("Robert")
                .SetLastName("Kadar")
                .SetTotalPrice(500)
                .SetDepositPaid(true)
                .SetBookingDates("2022-10-10", "2022-12-10")
                .SetAdditionalNeeds("Breakfast")
                .BookingBuild();
        }

        [When(@"sending the POST request with booking info to the website")]
        public async Task WhenSendingThePOSTRequestWithBookingInfoToTheWebsite()
        {
            var api = new ApiClient();
            response = await api.CreateBooking<Booking>(_bookingBuilder);
        }

        [Then(@"the response status code would be (.*)")]
        public void ThenTheResponseStatusCodeWouldBe(int statusCode)
        {
            _statusCode = response.StatusCode;
            var code = (int)_statusCode;
            Assert.AreEqual(statusCode, code);
        }

        [Then(@"the response context should contains FirstName ""([^""]*)""")]
        public void ThenTheResponseContextShouldContainsFirstName(string fName)
        {
            var content = HandleContent.GetContent<BookingResponse>(response);
            Assert.AreEqual(content.booking.firstname, fName);
        }

        [Given(@"Having the partial booking info")]
        public void GivenHavingThePartialBookingInfo()
        {
            _partialBookingBuilder = new BookingBuilder()
                .SetTotalPrice(500)
                .SetDepositPaid(true)
                .SetBookingDates("2022-10-10", "2022-12-10")
                .SetAdditionalNeeds("Breakfast")
                .PartialBookingBuild();
        }

        [When(@"sending the POST request with the partial booking info to the website")]
        public async Task WhenSendingThePOSTRequestWithThePartialBookingInfoToTheWebsite()
        {
            var api = new ApiClient();
            response = await api.CreateBooking<PartialBooking>(_partialBookingBuilder);
        }

        [When(@"I send the GET request for the booking ID (.*)")]
        public async Task WhenISendTheGETRequestForTheBookingID(string strID)
        {
            var api = new ApiClient();
            response = await api.GetBooking(strID);
        }

        [When(@"I send the GET request for inexistent booking ID (.*)")]
        public async Task WhenISendTheGETRequestForInexistentBookingID(string strID)
        {
            var api = new ApiClient();
            response = await api.GetBooking(strID);
        }

        [Given(@"Having the booking info for the existing ID")]
        public void GivenHavingTheBookingInfoForTheExistingID()
        {
            _bookingBuilder = new BookingBuilder()
                .SetFirstName("Robert")
                .SetLastName("Kadar")
                .SetTotalPrice(500)
                .SetDepositPaid(true)
                .SetBookingDates("2022-10-10", "2022-12-10")
                .SetAdditionalNeeds("Breakfast")
                .BookingBuild();
        }

        [When(@"sending the PUT request with booking info for the existing ID")]
        public async Task WhenSendingThePUTRequestWithBookingInfoForTheExistingID()
        {
            var api = new ApiClient();
            response = await api.UpdateBooking(_bookingBuilder, id, username, password);
        }

        [When(@"sending the PUT request with booking info for the existing ID without authentication")]
        public async Task WhenSendingThePUTRequestWithBookingInfoForTheExistingIDWithoutAuthentication()
        {
            var api = new ApiClient();
            response = await api.UpdateBooking(_bookingBuilder, id, userFail, passwordFail);
        }

        [When(@"I send the DELETE request for booking ID (.*)")]
        public async Task WhenISendTheDELETERequestForBookingID(string strID)
        {
            var api = new ApiClient();
            response = await api.DeleteBooking(strID, username, password);
        }

        [When(@"I send the DELETE request for inexistent booking ID (.*)")]
        public async Task WhenISendTheDELETERequestForInexistentBookingID(string strID)
        {
            var api = new ApiClient();
            response = await api.DeleteBooking(strID, username, password);
        }
    }
}
