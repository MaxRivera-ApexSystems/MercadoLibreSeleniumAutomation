using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Components.Header
{
    internal class HeaderPromoBannerComponent : PageControls
    {

        public HeaderPromoBannerComponent(IWebDriver driver) : base(driver) { }

        // Locator
        public IWebElement FreeShippingBanner => driver.FindElement(By.XPath("//div[contains(@class,'nav-right-area')]//a[@class='exhibitor__picture']"));


        // Action
        public EnvioGratisPage OpenFreeShippingPromotion()
        {
            FreeShippingBanner.Click();
            return new EnvioGratisPage(driver);
        }
    }


}

