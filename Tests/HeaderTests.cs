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
            home.OpenHomePage();
            header = new HeaderComponent(driver);
            carousel = new CarouselComponent(driver);

        }



        /* [Test]
         public void ClickLogo_ShouldNavigateToHome()
         {
             home.Header.Logo.ClickMainLogo();
             Assert.That(driver.Url.Contains("mercadolibre.com.mx"));
         }
        */

        [Test]
        public void HoverOverCategories()
        {

            /* header.GetVisibleNavMenuItemTexts();
             header.SearchAndReturnUrl("switch");
            */


            // header.GetVisibleCategoriesAfterHover();
            // header.HoverAndClickCategory("mascotas");

                 home.Carousel.GoToNextSlide();

               var slides = home.Carousel.GetSlideTitles();
           


            home.Carousel.LogCarouselSlides();
        }

        [TestCaseSource(typeof(CategoriesTestData), nameof(CategoriesTestData.CategoriesList))]
        public void ClickCategory_ShouldNavigate(string categoryName)
        {
            categories.Hover(categories.CategoriasButton);

            categories.ClickCategory(categoryName);

            Assert.That(driver.Url.Contains(categoryName.ToLower()),
                $"Navigation failed for category: {categoryName}");
        }


        [Test]
        public void HoverTecnologia_ShouldDisplaySubMenu()
        {
            categories.Hover(categories.CategoriasButton);
            Thread.Sleep(3000);

            categories.Hover(categories.GetCategoryElement("Tecnología"));

            // Esperamos a que aparezca el submenu - sirve esto? 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => categories.SubMenuContainer.Displayed);

            // Validar título
            Assert.That(categories.SubMenuTitle.Text, Is.EqualTo("Tecnología"));

            // validar que existan subgrupos
            Assert.That(categories.SubCategoryGroups.Count, Is.GreaterThan(0));

            // validar que existan links
            Assert.That(categories.SubCategoryLinks.Count, Is.GreaterThan(0));


            foreach (var group in categories.SubCategoryGroups)
            {
                Console.WriteLine($"Grupo: {group.Text}");
            }



        }







    }
}
