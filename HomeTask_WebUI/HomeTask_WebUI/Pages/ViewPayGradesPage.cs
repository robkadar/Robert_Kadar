using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_WebUI.Pages
{
    internal class ViewPayGradesPage : AbstractPage
    {
        public ViewPayGradesPage(IWebDriver driver) : base(driver) { }
        private IWebElement AddButton => Driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']"));
        private IWebElement ConfirmDeleteButton => Driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin']"));
        private IReadOnlyCollection<IWebElement> _productsInventoryList => Driver.FindElements(By.ClassName("\"oxd-table-card\""));
        //public IWebElement GetInventoryItemByName(string productName) => _productsInventoryList.Where(element => element.FindElement(By.ClassName("inventory_item_name")).Text.Contains(productName)).FirstOrDefault();
        private IWebElement txt => Driver.FindElement(By.XPath("//span[@class='oxd-text oxd-text--span']"));

        public IWebElement GetInventoryItemByName(string productName) => _productsInventoryList.FirstOrDefault(element => element.FindElement(By.XPath(".//div[contains(@class,'oxd-table-cell oxd-padding-cell')]")).Text.Contains(productName.Trim('\"')));
        public void AddPayGrades()
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']")));
            AddButton.Click();
        }
        public void RemovePayGrades(string productName)
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("bi-trash")));

            ReadOnlyCollection<IWebElement> webElements;
            
            webElements = Driver.FindElements(By.XPath($"//div[contains(text(),'{productName}')]//..//..//..//button/i[contains(@class,'bi-trash')]"));
            if (webElements.Count == 1)
            {
                webElements[0].Click();
                ConfirmDeleteButton.Click();
            }
            
        }

        public bool CheckProductInfo(string productName, string currencyName)
        {
            ReadOnlyCollection<IWebElement> webElements;
            webElements = Driver.FindElements(By.XPath($"//div[contains(text(),'{productName}')]/following::div[contains(text(),'{currencyName}')]"));
            if (webElements.Count == 1)
            {
                return true;
            }
            return false;
        }
    }
}
