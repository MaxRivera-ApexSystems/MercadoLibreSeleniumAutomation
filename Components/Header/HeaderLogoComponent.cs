using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Components.Header
{
    public class HeaderLogoComponent : BaseComponent
    {
        public HeaderLogoComponent(IWebDriver driver) : base(driver) { }

        public IWebElement MainLogo => driver.FindElement(By.XPath("//a[contains(@class,'nav-logo')]")); //Hacer el locator como private.

        public HomePage NavigateToHome()
        {
            MainLogo.Click();
            return new HomePage(driver);
        }
    }


}

