using HomeTask_WebUI.Core;
using HomeTask_WebUI.Entities;
using HomeTask_WebUI.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace HomeTask_WebUI.Steps
{
    [Binding]
    public class SalaryGradeStepDefinitions
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;
        private AdminPage adminPage;
        private ViewPayGradesPage viewPayGradesPage;
        private PayGradePage payGradePage;
        private EditPayGradePage editPayGradePage;
        private string testName = "Grade 10";
        private string testName2 = "Grade 1";
        private string testCurrency = "United States Dollar";
        private double testMinSalary = 500;
        private double testMaxSalary = 5000;

        [BeforeScenario]
        public void Setup()
        {
            loginPage = new LoginPage(DriverHolder.Driver);
            dashboardPage = new DashboardPage(DriverHolder.Driver);
            adminPage = new AdminPage(DriverHolder.Driver);
            viewPayGradesPage = new ViewPayGradesPage(DriverHolder.Driver);
            payGradePage = new PayGradePage(DriverHolder.Driver);
            editPayGradePage = new EditPayGradePage(DriverHolder.Driver);
        }

        [Given(@"start Google Chrome and load the ""([^""]*)"" webpage")]
        public void GivenStartGoogleChromeAndLoadTheWebpage(string baseURL)
        {
            DriverHolder.Driver.Navigate().GoToUrl(baseURL);
        }

        [Given(@"I am logged in to the website")]
        public void GivenIAmLoggedInToTheWebsite()
        {
            loginPage.LogIn("Admin", "admin123");
            loginPage.ClickLoginButton();
        }

        [Given(@"I add a new product with its currency data")]
        public void GivenIAddANewProductWithItsCurrencyData()
        {
            dashboardPage.ClickOnAdminButton();
            adminPage.GoToPayGradesPage();
            viewPayGradesPage.RemovePayGrades(testName);
            viewPayGradesPage.AddPayGrades();
            payGradePage.SaveProduct(testName);
            editPayGradePage.EnterNewSalaryData("HUF", (int)testMinSalary, (int)testMaxSalary);
        }

        [When(@"I click on the Save Currency button")]
        public void WhenIClickOnTheSaveCurrencyButton()
        {
            editPayGradePage.SaveSalaryData();
        }

        [Then(@"the entered currency info should be saved and displayed")]
        public void ThenTheEnteredCurrencyInfoShouldBeSavedAndDisplayed()
        {
            SalaryEntity result = editPayGradePage.GetSalary();
            Assert.AreEqual(testMinSalary, result.MinSalary);
            Assert.AreEqual(testMaxSalary, result.MaxSalary);
        }

        [When(@"I click on the Cancel button to cancel adding the currency info")]
        public void WhenIClickOnTheCancelButtonToCancelAddingTheCurrencyInfo()
        {
            editPayGradePage.CancelSaveSalaryData();
        }

        [Then(@"the entered data should not be visible on the Pay Grades page")]
        public void ThenTheEnteredDataShouldNotBeVisibleOnThePayGradesPage()
        {
            adminPage.GoToPayGradesPage();
            bool chkProd = viewPayGradesPage.CheckProductInfo(testName, testCurrency);
            Assert.IsFalse(chkProd);
        }
    }
}
