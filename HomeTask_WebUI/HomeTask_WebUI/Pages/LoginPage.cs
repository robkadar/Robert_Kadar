using HomeTask_WebUI.Entities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_WebUI.Pages
{
    internal class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        private IWebElement UserNameTextBox => Driver.FindElement(By.Name("username"));
        private IWebElement UserPasswordTextBox => Driver.FindElement(By.Name("password"));
        private IWebElement LogInButton => Driver.FindElement(By.ClassName("orangehrm-login-button"));

        public LoginPage LogIn(UserEntity userEntity)
        {
            return LogIn(userEntity.UserName, userEntity.Password);
        }
        public LoginPage LogIn(string UserName, string Password)
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("password")));
            UserNameTextBox.SendKeys(UserName);
            UserPasswordTextBox.SendKeys(Password);
            //LogInButton.Click();
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("password")));
            LogInButton.Click();
            return this;
        }
    }
}
