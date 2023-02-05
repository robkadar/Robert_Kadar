using HomeTask_WebAPI.API;
using HomeTask_WebAPI.Model.Request;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HomeTask_WebAPI.Test.Steps
{
    [Binding]
    public class ApiTestStepDefinitions
    {
        private readonly BookingData _bookingData;
        public RestResponse response;
        private ScenarioContext _scenarioContext;
        private HttpStatusCode _statusCode;
        string payload;
        string id = "1";
        string username = "admin";
        string password = "password123";
        string userFail = "";
        string passwordFail = "";

        public ApiTestStepDefinitions(BookingData bookingData, ScenarioContext scenarioContext)
        {
            _bookingData = bookingData;
            _scenarioContext = scenarioContext;
        }

        [Given(@"Having the booking info")]
        public void GivenHavingTheBookingInfo()
        {
            string fName = "Robert";
            string lName = "Kadar";
            int tPrice = 100;
            bool dPaid = true;
            string chkIn = "2022-10-10";
            string chkOut = "2022-12-10";
            string addNeeds = "Breakfast";

            payload = _bookingData.BookingInfo(fName, lName, tPrice, dPaid, chkIn, chkOut, addNeeds);
        }

        [When(@"sending the POST request with booking info to the website")]
        public async Task WhenSendingThePOSTRequestWithBookingInfoToTheWebsite()
        {
            var api = new ApiClient();
            response = await api.CreateBooking(payload);
        }

        [Then(@"the response status code would be (.*)")]
        public void ThenTheResponseStatusCodeWouldBe(int statusCode)
        {
            _statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(statusCode, code);
        }

        [Given(@"Having the partial booking info")]
        public void GivenHavingThePartialBookingInfo()
        {
            string fName = "Robert";
            string lName = "Kadar";
            int tPrice = 100;
            bool dPaid = true;

            payload = _bookingData.BookingInfoFail(fName, lName, tPrice, dPaid);
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
            string fName = "Robert";
            string lName = "Kadar";
            int tPrice = 100;
            bool dPaid = true;
            string chkIn = "2022-10-10";
            string chkOut = "2022-12-10";
            string addNeeds = "Breakfast";

            payload = _bookingData.BookingInfo(fName, lName, tPrice, dPaid, chkIn, chkOut, addNeeds);
        }

        [When(@"sending the PUT request with booking info for the existing ID")]
        public async Task WhenSendingThePUTRequestWithBookingInfoForTheExistingID()
        {
            var api = new ApiClient();
            response = await api.UpdateBooking(payload, id, username, password);
        }

        [When(@"sending the PUT request with booking info for the existing ID without authentication")]
        public async Task WhenSendingThePUTRequestWithBookingInfoForTheExistingIDWithoutAuthentication()
        {
            var api = new ApiClient();
            response = await api.UpdateBooking(payload, id, userFail, passwordFail);
        }

    }
}
