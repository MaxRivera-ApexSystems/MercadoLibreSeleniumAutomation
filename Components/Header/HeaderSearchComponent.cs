using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Components.Header
{
    public class HeaderSearchComponent : BaseComponent
    {

        public HeaderSearchComponent(IWebDriver driver) : base(driver) { }

        // Locators
        public IWebElement SearchInput => driver.FindElement(By.XPath("//input[@id='cb1-edit']"));
        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[@class='nav-search-btn']"));

        // Actions
        public void EnterSearchText(string text) => SearchInput.SendKeys(text);
        public void ClickSearchButton() => SearchButton.Click();

        public SearchResultsPage SearchFor(string query)
        {
            SearchInput.SendKeys(query);
            SearchButton.Click();

            return new SearchResultsPage(driver);
        }







    }
}
