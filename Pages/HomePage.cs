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
    public class HomePage : BaseComponent
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

       


    }


}

