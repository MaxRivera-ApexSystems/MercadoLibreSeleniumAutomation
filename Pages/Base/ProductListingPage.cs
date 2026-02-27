using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Pages.Base
{
    public abstract class ProductListingPage : BaseComponent
    {
        //Cards container
        protected readonly By ProductCards = By.CssSelector("div.poly-card");

        //Core info
        protected readonly By ProductTitles = By.CssSelector(".poly-component__title");
        protected readonly By ProductImages = By.CssSelector(".poly-component__picture");
        protected readonly By ProductPrices = By.CssSelector(".poly-price__current");
        protected readonly By ProductPriceFraction = By.CssSelector(".poly-price__current .andes-money-amount__fraction");

        //Optional elements
        protected readonly By PreviousPrices = By.CssSelector(".andes-money-amount--previous");
        protected readonly By DiscountBadges = By.CssSelector(".poly-price__disc--pill");
        protected readonly By ShippingInfo = By.CssSelector(".poly-component__shipping");

        protected ProductListingPage(IWebDriver driver) : base(driver) { }

        public int GetProductCount()
        {
            return driver.FindElements(ProductCards).Count;
        }

        public IList<string> GetProductTitles()
        {
            return driver.FindElements(ProductTitles).Select(e => e.Text).ToList();


        }

        public void ClickProductByIndex(int index)
        {
            var products = driver.FindElements(ProductCards);

            if (index >= products.Count) throw new ArgumentOutOfRangeException(nameof(index));


            products[index].Click();
        }
    }
}