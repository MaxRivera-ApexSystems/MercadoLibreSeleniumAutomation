using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ManualToSdetMercadoLibre.Pages
{
    public class SearchResultsPage : ProductListingPage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver) { }

        // --- RESULTS GRID ---
        private readonly By ResultsGrid = By.CssSelector("ol.ui-search-layout--grid");
        private readonly By SearchResultItems = By.CssSelector("li.ui-search-layout__item");
        private readonly By ResultsFromCategorySection = By.CssSelector("section.ui-category-trends-desktop-content");


        private readonly By GridItems = By.CssSelector("ol.ui-search-layout--grid > li.ui-search-layout__item");

        // --- PRODUCT CARD DATA ---
        private readonly By ProductTitleLink = By.CssSelector(".poly-component__title");
        private readonly By ProductPriceCurrent = By.CssSelector(".poly-price__current");
        private readonly By ProductOldPrice = By.CssSelector(".andes-money-amount--previous");
        private readonly By ProductDiscountBadge = By.CssSelector(".poly-price__disc--pill");
        private readonly By ProductShipping = By.CssSelector(".poly-component__shipping");


        // --- WAIT FOR RESULTS ---

        // ---Results From the Categories dropdowns ---
        public void WaitForResults()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(d =>
                d.FindElements(GridItems).Count > 0
            );
        }


        public Product GetProductByIndex(int index)
        {
            var cards = driver.FindElements(ProductCards);

            if (index < 0 || index >= cards.Count)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Index {index} is out of range. Total products: {cards.Count}");

            return new Product(cards[index]);
        }

        public void WaitForCategorySection()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            wait.Until(d =>
            {
                var section = d.FindElements(ResultsFromCategorySection);

                if (section.Count == 0)
                    return false;

                return section[0].Displayed;
            });
        }
        // --- Results From searching from the search input, diff locators for the items ---

        public void WaitForResultsFromSearchInput()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElements(SearchResultItems).Count > 0);
        }

        public int GetVisibleProductsCount()
        {
            return driver.FindElements(GridItems).Count;
        }

        




    }
}