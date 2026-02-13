using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Components.Header
{
    public class HeaderPromoBannerComponent : BaseComponent
    {

        public HeaderPromoBannerComponent(IWebDriver driver) : base(driver) { }

        // Locator - hacerlo private o protected.
        public IWebElement FreeShippingBanner => driver.FindElement(By.XPath("//div[contains(@class,'nav-right-area')]//a[@class='exhibitor__picture']"));


        // Action
        public void  OpenFreeShippingPromotion()
        {
            FreeShippingBanner.Click();
        }
    }


}

