using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Components.Carousel;
using ManualToSdetMercadoLibre.Components.Header;
using ManualToSdetMercadoLibre.Pages;
using ManualToSdetMercadoLibre.TestData;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace ManualToSdetMercadoLibre.Tests
{
    public class HeaderTests : TestBase
    {
        private HomePage home;

        [SetUp]
        public void TestSetUp()
        {
            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");
             home = new HomePage(driver);

        }

        [Test]
        public void SearchBarSingleProductDataReturn()
        {
            var resultsPage = home.Search("Pokemon");
            resultsPage.WaitForResultsFromSearchInput();
            var product = resultsPage.GetProductByIndex(4);
            Console.WriteLine(product.GetProductName());
        }

        [Test]
        public void SearchBarAllProductDataReturn()
        {
            var resultsPage = home.Search("Nintendo");
            resultsPage.WaitForResultsFromSearchInput();
            var products = resultsPage.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ToFormattedString());
            }
        }

        [Test]
        public void SearchAfterLoginTest()    // cambar a fljo con  real con el login page
        {
            var log = new LoginPage(driver).InjectLoginCookie();
            var resultsPage = home.Search("Nintendo");
            resultsPage.WaitForResultsFromSearchInput();
            var products = resultsPage.GetProducts();
        }

        [Test]
        public void SearchAfterLoginWithCookie()
        {
            var home = new LoginPage(driver).InjectLoginCookie();
            var resultsPage = home.Search("Nintendo");
            resultsPage.WaitForResultsFromSearchInput();
            Assert.That(resultsPage.GetProductCount(), Is.GreaterThan(0));

            var products = resultsPage.GetProducts();
            Assert.Multiple(() =>
            {
                Assert.That(products, Has.Count.GreaterThan(5));
                foreach (var product in products)
                {
                    Assert.That(product.GetProductName, Is.Not.Null.Or.Empty);
                }
            });
            //Necesario hacer login para entrar a los detalles de producto.
            products[3].GoToProductDetails();
        }

        [Test]
        public void SearchReturnsResults()
        {
            var resultsPage = home.Search("Nintendo");

            resultsPage.WaitForResultsFromSearchInput();
            var productsAvailable = resultsPage.GetProducts();

            var count = productsAvailable.Count;

            Assert.That(count, Is.GreaterThan(0), "No se encontraron productos");
        }
        [Test]
        public void AllProductsHaveNames()
        {
           

            var resultsPage = home.Search("Nintendo");

            resultsPage.WaitForResultsFromSearchInput();

            var products = resultsPage.GetProducts();

            foreach (var product in products)
            {
                Assert.That(product.GetProductName(), Is.Not.Empty);
            }
        }
        [Test]
        public void AllProductsHavePrices()
        {
            var resultsPage = home.Search("Nintendo");

            resultsPage.WaitForResultsFromSearchInput();

            var products = resultsPage.GetProducts();

            foreach (var product in products)
            {
                Assert.That(product.GetProductPrice(), Is.Not.Empty);
            }
        }

        [Test]
        public void ClickProductNavigatesToDetails()
        {
            var resultsPage = home.Search("Nintendo");

            resultsPage.WaitForResultsFromSearchInput();

            Assert.That(driver.Url, Does.Contain("mercadolibre"));

            var products = resultsPage.GetProducts();
            Assert.Multiple(() =>
            {
                Assert.That(products, Has.Count.GreaterThan(5));
                foreach (var product in products) {
                    Assert.That(product.GetProductName, Is.Not.Null.Or.Empty);
                }
            });
            //Necesario hacer login para entrar a los detalles de producto.
            products[3].GoToProductDetails();
           
        }
    }
}
