using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Pages.Base
{

    public class ProductModel
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public string PreviousPrice { get; set; }
        public string Discount { get; set; }
        public string ShippingInfo { get; set; }
    } // remove? Unless you also interact with a web service directly: yes.


    public abstract class ProductListingPage : BaseComponent
    {
        // Contenedor principal de la grilla 
        protected readonly By GridContainer = By.CssSelector("section.ui-search-layout--grid__container ol");

        // Cards container
        protected readonly By ProductCards = By.CssSelector("div.poly-card");

        // Core info ??
        protected readonly By ProductTitles = By.CssSelector(".poly-component__title");
        protected readonly By ProductPrices = By.CssSelector(".poly-price__current");

        // Optional elements
        protected readonly By PreviousPrices = By.CssSelector(".andes-money-amount--previous");
        protected readonly By DiscountBadges = By.CssSelector(".poly-price__disc--pill");
        protected readonly By ShippingInfo = By.CssSelector(".poly-component__shipping");

        protected ProductListingPage(IWebDriver driver) : base(driver) { }

        public List<Product> GetProducts()
        {
            var resultList = new List<Product>();
            var cards = driver.FindElements(ProductCards);


            foreach (var item in cards)
            {
                var prod = new Product(item);
                resultList.Add(prod);
            }

            return resultList;
        }




        public int GetProductCount()
        {
            //Este método se puede considerar una rutina de usuario más que parte del page object:.
            //debido a que este número no es obtenido directamente de la página sino el equivalente
            //al usuario contar manualmente los elementos "Product Card" encontrados.
            return driver.FindElements(ProductCards).Count;
        }

        public IList<string> GetProductTitles()
        {
            //Al igual que el método anterior, esto es algo que no hace el "Page Object" en sí mismo.
            return driver.FindElements(ProductTitles).Select(e => e.Text).ToList();
        }

        public void ClickProductByIndex(int index)
        {
            //Aunque ciertamente la página en si misma dispone el orden de los elementos con los que interactuar,
            //el decidir el índice le corresponde exclusivamente al usuario: en ninguna instancia el page object
            //"pregunta" al usuario cual indice usar para encontrar el producto.
            var products = driver.FindElements(ProductCards);
            if (index >= products.Count) throw new ArgumentOutOfRangeException(nameof(index));
            products[index].Click();
        }


        public class Product
        {
            private readonly By ProductTitles = By.CssSelector(".poly-component__title");
            private readonly By ProductPrices = By.CssSelector(".poly-price__current");
            private readonly By PreviousPrices = By.CssSelector(".andes-money-amount--previous");
            private readonly By DiscountBadges = By.CssSelector(".poly-price__disc--pill");
            private readonly By ShippingInfo = By.CssSelector(".poly-component__shipping");

            private readonly IWebElement element;

            public Product(IWebElement webelement)
            {
                this.element = webelement;
            }

            public string GetProductName()
            {
                return element.FindElement(ProductTitles).Text;
            }

            public string GetProductPrice()
            {
                return element.FindElement(ProductPrices).Text.Replace("\n", " ").Trim();
            }

            public bool HasPreviousPrice()
            {
                return element.FindElements(PreviousPrices).Any();
            }

            public string GetPreviousPrice()
            {
                return HasPreviousPrice()
                    ? element.FindElement(PreviousPrices).Text.Replace("\n", " ").Trim()
                    : "N/A"; //Devolver null cuando algo no existe es aceptable.
            }

            public bool HasDiscount()
            {
                return element.FindElements(DiscountBadges).Any();
            }

            public string GetDiscount()
            {
                return HasDiscount()
                    ? element.FindElement(DiscountBadges).Text
                    : "Sin descuento"; //Devolver null cuando algo no existe es aceptable
            }

            public string GetShippingInfo()
            {
                var el = element.FindElements(ShippingInfo).FirstOrDefault();
                return el != null ? el.Text : "Envío estándar/No especificado"; //Resolver esto será interesante: no tengo sugerencias XP
            }


            public string ToFormattedString()
            {
                //Este es un excelente método de utileria aunque tampoco forma parte del page object.
                return
                    $"Nombre: {GetProductName()}\n" +
                    $"Precio: {GetProductPrice()}\n" +
                    $"Precio Anterior: {GetPreviousPrice()}\n" +
                    $"Descuento: {GetDiscount()}\n" +
                    $"Envío: {GetShippingInfo()}\n" +
                    $"---------------------------";
            }

            public ProductDetailsPage GoToProductDetails(IWebDriver driver) //Esto es un pequeño reto para la siguiente sesión.
            {
                element.FindElement(ProductTitles).Click();
                return new ProductDetailsPage(driver);
            }


        }
    }
}