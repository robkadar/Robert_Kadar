Feature: ApiTest

API Testing Scenarios for the Web API https://restful-booker.herokuapp.com/ 
These scenarios covers CRUD operations (1 positive and 1 negative test for each operations)

@CreateNewBookingPositiveTest
Scenario: Create new booking - positive test
	Given Having the booking info
	When sending the POST request with booking info to the website
	Then the response status code would be 200

@CreateNewBookingNegativeTest
Scenario: Create new booking - negative test
	Given Having the partial booking info
	When sending the POST request with booking info to the website
	Then the response status code would be 500

@DeleteBookingPositiveTest
Scenario: Delete booking ID - positive test
	When I send the DELETE request for booking ID 2
	Then the response status code would be 201

@DeleteBookingNegativeTest
Scenario: Delete booking ID - negative test
	When I send the DELETE request for inexistent booking ID aabbcc000
	Then the response status code would be 405

@GetBookingPositiveTest
Scenario: Get Booking - positive test
	When I send the GET request for the booking ID 1
	Then the response status code would be 200

@GetBookingNegativeTest
Scenario: Get Booking - negative test
	When I send the GET request for inexistent booking ID aabbcc111
	Then the response status code would be 404

@UpdateBookingPositiveTest
Scenario: Update booking info - positive test
	Given Having the booking info for the existing ID
	When sending the PUT request with booking info for the existing ID
	Then the response status code would be 200

@UpdateBookingNegativeTest
Scenario: Update booking info - negative test
	Given Having the booking info for the existing ID
	When sending the PUT request with booking info for the existing ID without authentication
	Then the response status code would be 500