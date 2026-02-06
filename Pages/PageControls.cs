using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ManualToSdetMercadoLibre.Pages
{
    abstract class PageControls
    {
        protected IWebDriver driver;

        public PageControls(IWebDriver driver)
        {
            this.driver = driver; 

        }



        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void Type(By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }


        public void Hover(IWebElement locator)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(locator).Perform();
        }


    }
}
