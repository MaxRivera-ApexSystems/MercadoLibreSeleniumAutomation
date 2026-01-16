using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Components.Header
{
    internal class HeaderSearchComponent : PageControls
    {

        public HeaderSearchComponent(IWebDriver driver) : base(driver) { }

        // Locators
        public IWebElement SearchInput => driver.FindElement(By.XPath("//input[@id='cb1-edit']"));
        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[@class='nav-search-btn']"));

        // Actions
        public void EnterSearchText(string text) => SearchInput.SendKeys(text);
        public void ClickSearchButton() => SearchButton.Click();

        public void Search(string text)
        {
            EnterSearchText(text);
            ClickSearchButton();
        }











    }
}
