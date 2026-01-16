using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ManualToSdetMercadoLibre.Components;

using ManualToSdetMercadoLibre.Components.Header;
using ManualToSdetMercadoLibre.Components.Carousel;

namespace ManualToSdetMercadoLibre.Pages
{
    internal class HomePage : PageControls
    {



        // Attach the header component
        public HeaderComponent Header { get; }
        public CarouselComponent Carousel { get; }



        // Inject driver
        public HomePage(IWebDriver driver) : base(driver)
        {
            Header = new HeaderComponent(driver);
            Carousel = new CarouselComponent(driver);
        }




     
        public void OpenHomePage()
        {
            GoToUrl("https://www.mercadolibre.com.mx");
        }









    }
}
