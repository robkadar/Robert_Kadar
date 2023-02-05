Feature: SalaryGrade

Scenario to add new Pay Grade record and its currency

Background: Loading the webpage for testing
	Given start Google Chrome and load the "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login" webpage

@AddNewSalaryGrade
Scenario: Add new salary grade
	Given I am logged in to the website
	And I add a new product with its currency data
	When I click on the Save Currency button
	Then the entered currency info should be saved and displayed

@CancelAddNewSalaryGrade
Scenario: Cancel addiing new salary grade
	Given I am logged in to the website
	And I add a new product with its currency data
	When I click on the Cancel button to cancel adding the currency info
	Then the entered data should not be visible on the Pay Grades page
