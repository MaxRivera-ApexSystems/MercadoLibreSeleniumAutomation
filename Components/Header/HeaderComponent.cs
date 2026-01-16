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
    internal class HeaderComponent : PageControls
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
        

    }
}
