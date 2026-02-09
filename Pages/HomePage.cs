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


        //Se sugiere que todo lo que sea referente a locators sea private o protected(protected en caso de que se aplique herencia)
        // Inject driver
        public HomePage(IWebDriver driver) : base(driver)
        {
            Header = new HeaderComponent(driver);
            Carousel = new CarouselComponent(driver);
        }

        // ===== LINKS / ACTIONS =====
        public static readonly By SlideLinks =
            By.CssSelector(
                ".dynamic-access-card-item__item-title, " +
                ".dynamic-access-card-ecosistemic__action"
            );

        // ===== IMÁGENES =====
        public static readonly By SlideImages =
            By.CssSelector(".dynamic-access-card img");

        // ===== BOTONES DENTRO DE SLIDES (ej: Medios de pago) =====
        public static readonly By SlideButtons =
            By.CssSelector(".dynamic-access-card button");


        //Excelentes métodos!!
        public bool IsCarouselDisplayed()
        {
            return driver.FindElement(Carousel.NextButton).Displayed;
        }

        public int GetCarouselSlideCount()
        {
            return driver.FindElements(Carousel.CarouselSlides).Count;
        }

        public void ClickNext()
        {
             driver.FindElement(Carousel.NextButton).Click();

        }

        public void ClickPrevious()
        {
            driver.FindElement(Carousel.PreviousButton).Click();
        }

        public void ClickActiveBanner()
        {
            var activeSlide = driver.FindElement(Carousel.ActiveSlide);
            activeSlide.FindElement(By.TagName("a")).Click();
        }

    }


}

