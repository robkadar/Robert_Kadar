﻿using OpenQA.Selenium;

namespace HomeTask_WebUI.Pages
{
    internal class DashboardPage : AbstractPage
    {
        public DashboardPage(IWebDriver driver) : base(driver) { }
        private IWebElement adminButton => Driver.FindElement(By.XPath("//span[text() = 'Admin']"));
        public void ClickOnAdminButton()
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = 'Admin']")));
            adminButton.Click();
        }
    }
}
