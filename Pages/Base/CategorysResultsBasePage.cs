using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ManualToSdetMercadoLibre.Pages.Base
{
    public class CategorysResultsBasePage : BaseComponent

    {
        protected CategorysResultsBasePage(IWebDriver driver) : base(driver) { }
        protected By ProductCards => By.CssSelector("div.poly-card");
        protected By ProductTitle => By.CssSelector("h2.poly-box");
        protected By Prices => By.CssSelector("span.andes-money-amount__fraction");
        protected By FiltersSection => By.Id("filters");
        protected By StorefrontIframe => By.CssSelector("iframe[src*='storefront'], iframe[src*='mshops']");

        protected void SwitchToResultsIframe()
        {
        

            var iframe = driver.FindElement(StorefrontIframe);
            driver.SwitchTo().Frame(iframe);
        }
        

    }
}
