using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace ManualToSdetMercadoLibre.Components.Header
{
    public class HeaderComponent : BaseComponent
    {
        public HeaderLogoComponent Logo { get; }
        public HeaderPromoBannerComponent PromoBanner { get; }
        public HeaderSearchComponent Search { get; }
        public HeaderPostalCodeComponent PostalCode { get; }
        public HeaderCategoriesComponent Category { get; }

        public HeaderComponent(IWebDriver driver) : base(driver)
        {
            Logo = new HeaderLogoComponent(driver);
            Search = new HeaderSearchComponent(driver);
            PostalCode = new HeaderPostalCodeComponent(driver);
            PromoBanner = new HeaderPromoBannerComponent(driver);
            Category = new HeaderCategoriesComponent(driver);

        }
        public void SearchFor(string text)
        {
            Search.SearchFor(text);

        }
        public void OpenCategory(string categoryName)
        {
            Category.OpenCategory(categoryName);
        }


        public IEnumerable<string> GetAvailableMenuList()
        {
            var navMenu = Category.NavMenuList;
            return navMenu.Select(we => we.Text);

        }

        public IEnumerable<string> GetSubCategoryTitlesandItems()
        {
            var navSubMenu = Category.SubCategoryGroups;
            return navSubMenu.Select(x => x.Text);
        }
        public IList<string> GetSubCategoryTitles()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var titleLinks = wait.Until(d =>
            {
                var elements = Category.SubCategoryGroupsOnlyTitles;
                return elements.Count > 0 ? elements : null;
            });

            return titleLinks.Where(t => t.Displayed && !string.IsNullOrWhiteSpace(t.Text)).Select(t => t.Text.Trim()).ToList();
        }


        public IEnumerable<string> GetSubCategoryLinksText()
        {
            var navSubMenuLinks = Category.SubCategoryLinks;

            return navSubMenuLinks.Select(l => l.Text);
        }

        public bool IsPromoBannerVisible()
        {
            return PromoBanner.FreeShippingBanner.Displayed;
        }



    }
}

