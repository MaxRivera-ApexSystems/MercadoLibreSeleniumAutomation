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
        private HeaderComponent header;
        private HeaderCategoriesComponent categories;
        private CarouselComponent carousel;
        private LoginPage loginPage;
        private SearchResultsPage resultsPage;


        [SetUp]
        public void TestSetUp()
        {
            home = new HomePage(driver);
            categories = new HeaderCategoriesComponent(driver);
            header = new HeaderComponent(driver);
            loginPage = new LoginPage(driver);
            resultsPage = new SearchResultsPage(driver);



        }
        [Test]
        public void SearchBarSingleProductDataReturn()
        {
            var resultsPage = new SearchResultsPage(driver);

            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");

            header.Search.SearchFor("Pokemon");
            Thread.Sleep(5000);

            resultsPage.WaitForResultsFromSearchInput();



            int count = resultsPage.GetProductCount();

            Console.WriteLine($"Productos encontrados: {count}");
            var product = resultsPage.GetProductInfoByIndex(4);
        }
        [Test]
        public void SearchBarAllProductDataReturn()
        {
            var resultsPage = new SearchResultsPage(driver);

            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");

            header.Search.SearchFor("Nintendo");
            Thread.Sleep(5000);

            resultsPage.WaitForResultsFromSearchInput();

            int count = resultsPage.GetProductCount();

            Console.WriteLine($"Productos encontrados: {count}");
            var products = resultsPage.LogAndGetProductsInfo();
        }

        [Test]
        public void SearchAfterLoginTest()
        {
            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");
            loginPage.InjectLoginCookie();

            Console.WriteLine("Session injected successfully.");

            Thread.Sleep(2000);
           

            Console.WriteLine("Login successful. Ready to start test flow.");

            // Ahora sí podemos buscar segun
            header.Search.SearchFor("Nintendo");
            Thread.Sleep(2000);
            var products = resultsPage.LogAndGetProductsInfo();


        }

        [Test]
        public void HoverOverCategories()
        {

            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");

            categories.OpenCategoriesDropDown();
            categories.OpenCategoriesSubDropDown("Tecnología");
            Thread.Sleep(3000);
            var groupTitles = categories.GetAvailableGroupTitles();

            Console.WriteLine("Grupos encontrados: " + groupTitles.Count);

            foreach (var title in groupTitles)
            {
                Console.WriteLine(title);
            }
           
        }

        [Test]
        public void SubDropDownTest()
        {

            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");

            categories.OpenCategoriesDropDown();
            categories.OpenCategoriesSubDropDown("Tecnología");
            categories.ClickItemInGroup("Consolas y Videojuegos", "Videojuegos");
            Thread.Sleep(3000);


            resultsPage.WaitForCategorySection();
            int count = resultsPage.GetProductCount();

            var products = resultsPage.LogAndGetProductsInfo();



        }


    


      







    }
}
