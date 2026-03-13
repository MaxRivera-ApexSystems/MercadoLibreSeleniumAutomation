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
    }



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

        // --- NUEVO METODO PARA EXTRAER Y LOGGEAR CARACTERISTICAS ---
        public List<ProductModel> LogAndGetProductsInfo()
        {
            List<ProductModel> extractedProducts = new List<ProductModel>();

            var cards = driver.FindElements(ProductCards);

            Console.WriteLine($"\n--- REPORTE DE CATEGORÍA ---");
            Console.WriteLine($"Total de productos encontrados en esta página: {cards.Count}\n");

            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];
                var productData = new ProductModel();

                try
                {
                    productData.Title = card.FindElement(ProductTitles).Text;
                    productData.Price = card.FindElement(ProductPrices).Text.Replace("\n", " ").Trim();

                    // Elementos Opcionales
                    var prevPriceElement = card.FindElements(PreviousPrices).FirstOrDefault();
                    productData.PreviousPrice = prevPriceElement != null ? prevPriceElement.Text.Replace("\n", " ").Trim() : "N/A";

                    var discountElement = card.FindElements(DiscountBadges).FirstOrDefault();
                    productData.Discount = discountElement != null ? discountElement.Text : "Sin descuento";

                    var shippingElement = card.FindElements(ShippingInfo).FirstOrDefault();
                    productData.ShippingInfo = shippingElement != null ? shippingElement.Text : "Envío estándar/No especificado";

                    // Agregamos a nuestra lista
                    extractedProducts.Add(productData);

                    // Imprimimos el Log en consola
                    Console.WriteLine($"Producto [{i + 1}]: {productData.Title}");
                    Console.WriteLine($"  -> Precio Actual: {productData.Price}");
                    Console.WriteLine($"  -> Precio Anterior: {productData.PreviousPrice}");
                    Console.WriteLine($"  -> Descuento: {productData.Discount}");
                    Console.WriteLine($"  -> Envío: {productData.ShippingInfo}");
                    Console.WriteLine(new string('-', 30));
                }
               
                catch (Exception ex)
                {
                    Console.WriteLine($"Error leyendo el producto [{i + 1}]: {ex.Message}");
                }
            }

            return extractedProducts;
        }
        // conbinar con el otro metodo?
        public ProductModel GetProductInfoByIndex(int index)
        {
            var cards = driver.FindElements(ProductCards);

            if (index >= cards.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "El índice excede el número de productos.");

            var card = cards[index];
            var productData = new ProductModel();

            try
            {
                productData.Title = card.FindElement(ProductTitles).Text;
                productData.Price = card.FindElement(ProductPrices).Text.Replace("\n", " ").Trim();

                var prevPriceElement = card.FindElements(PreviousPrices).FirstOrDefault();
                productData.PreviousPrice = prevPriceElement != null
                    ? prevPriceElement.Text.Replace("\n", " ").Trim()
                    : "N/A";

                var discountElement = card.FindElements(DiscountBadges).FirstOrDefault();
                productData.Discount = discountElement != null
                    ? discountElement.Text
                    : "Sin descuento";

                var shippingElement = card.FindElements(ShippingInfo).FirstOrDefault();
                productData.ShippingInfo = shippingElement != null
                    ? shippingElement.Text
                    : "Envío estándar/No especificado";

                Console.WriteLine($"\n--- PRODUCTO [{index}] ---");
                Console.WriteLine($"Título: {productData.Title}");
                Console.WriteLine($"Precio Actual: {productData.Price}");
                Console.WriteLine($"Precio Anterior: {productData.PreviousPrice}");
                Console.WriteLine($"Descuento: {productData.Discount}");
                Console.WriteLine($"Envío: {productData.ShippingInfo}");
                Console.WriteLine(new string('-', 30));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error leyendo el producto [{index}]: {ex.Message}");
            }

            return productData;
        }


    }
}