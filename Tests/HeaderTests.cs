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
using OpenQA.Selenium.Support.UI;


namespace ManualToSdetMercadoLibre.Tests
{
    public class HeaderTests : TestBase
    {
        private HomePage home;
        private HeaderComponent header;
        private HeaderCategoriesComponent categories;
        private CarouselComponent carousel;


        [SetUp]
        public void TestSetUp()
        {
            home = new HomePage(driver);
            categories = new HeaderCategoriesComponent(driver);
            header = new HeaderComponent(driver);
            carousel = new CarouselComponent(driver);

        }
        [Test]
        public void SearchBar()
        {

            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");

            header.SearchFor("Pokemon");
            Thread.Sleep(2000);

        }

        [Test]
        public void NavBar()
        {

            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");

            var visibleMenu = header.GetAvailableMenuList();

            foreach (var menuItem in visibleMenu) {

                Console.WriteLine("*" + menuItem);

            }

            categories.ClickNavMenuItem("Ofertas");
            Thread.Sleep(2000);

        }

        [Test]
        public void HoverOverCategories()
        {
         
            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");
            
            categories.OpenCategoriesDropDown();
            categories.OpenCategoriesSubDropDown();
            Thread.Sleep(3000);
            var groupTitles = categories.GetAvailableGroupTitles();

            Console.WriteLine("Grupos encontrados: " + groupTitles.Count);

            foreach (var title in groupTitles)
            {
                Console.WriteLine(title);
            }
            // categories.ClickItemInGroup("Computación", "Laptops");
            // Assert.That(resultList, Does.Contain("Supermercado").And.Contain("Ofertas"));
            //Assert.That(resultList, Has.Count.GreaterThan(5));


        }

        [TestCaseSource(typeof(CategoriesTestData), nameof(CategoriesTestData.CategoriesList))]
        public void ClickCategory_ShouldNavigate(string categoryName)
        {
            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");


            categories.Hover(categories.CategoriasButton);

            categories.OpenCategory(categoryName);

            Assert.That(driver.Url.Contains(categoryName.ToLower()), $"Navigation failed for category: {categoryName}");

        }


        [Test]
        public void HoverTecnologia_ShouldDisplaySubMenu()
        {
            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");

            categories.OpenCategoriesDropDown();
            categories.OpenCategoriesSubDropDown();
           // Esperamos a que aparezca el submenu -sirve esto ? --cambiar esto por la implementacon del wait del base page
           var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => categories.SubMenuContainer.Displayed);
            var groupTitles = header.GetSubCategoryTitlesandItems().ToList();

            foreach (var title in groupTitles)
            {
                Console.WriteLine($"Grupo: {title}");
            

            }
          /*  var itemsInGroup = categories.GetItemsForGroup("Consolas y Videojuegos");
            foreach(var item in itemsInGroup)
            {
                Console.WriteLine($"Elemento del grupo : {item}");

            }
          */

        }







    }
}
