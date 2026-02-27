using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages.Base;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Pages
{
    public class CartPage : ProductListingPage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private readonly By CheckoutButton = By.Id("checkout");

        public void ProceedToCheckout()
        {
            driver.FindElement(CheckoutButton).Click();
        }
    }
}