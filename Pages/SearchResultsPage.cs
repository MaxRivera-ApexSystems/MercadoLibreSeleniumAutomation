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
            //Aunque ciertamente esto facilita las cosas (y no está en uso), ¿que sucede cuando el criterio de búsqueda usado en realidad tiene 0 resultados?
            wait.Until(d =>
                d.FindElements(GridItems).Count > 0
            );
        }


        public Product GetProductByIndex(int index)
        {
            //Este es un buen método de utileria aunque no es una acción que el page object haga sino el usuario.
            var cards = driver.FindElements(ProductCards);

            if (index < 0 || index >= cards.Count)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Index {index} is out of range. Total products: {cards.Count}");

            return new Product(cards[index]);
        }

        public void WaitForCategorySection()
        {
            //Aquí aplica el mismo comentario que en el método WaitForResults y 
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
            //Se sugiere hacer este metodo privado ya que la espera es implícita y no
            //algo hecho bajo demanda por el usuario.
            //De hecho, de alguna manera, podría ser parte del constructor para la página SearchResults.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElements(SearchResultItems).Count > 0); //Esperar siempre por resultados es potencialmente riesgoso.
        }

        public int GetVisibleProductsCount()
        {
            //Este es un método de utileria dado que no es una acción del page object
            //sino algo que hace el usuario.
            return driver.FindElements(GridItems).Count;
        }

        




    }
}