using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages.Base;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Pages
{
    public class PurchasesPage : ProductListingPage
    {
        private readonly By PurchaseItems = By.CssSelector("...");

        public PurchasesPage(IWebDriver driver) : base(driver) { }

        public int GetPurchaseCount()
        {
            return driver.FindElements(PurchaseItems).Count;
        }
    }
}
