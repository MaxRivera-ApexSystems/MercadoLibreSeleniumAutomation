using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Components.Carousel
{
    public class CarouselComponent : BaseComponent
    {

        public CarouselComponent(IWebDriver driver) : base(driver) { }

    private  By ExhibitorCarousel => By.CssSelector("[data-andes-carousel-snapped-component='true']");


        // Wrapper que contiene los slides
        private  By CarouselWrapper => By.CssSelector(".andes-carousel-snapped__wrapper");


        // Todos los slides
        private  By CarouselSlides => By.CssSelector(".andes-carousel-snapped__slide");


        // Slide activo
        private By ActiveSlide => By.CssSelector(".andes-carousel-snapped__slide--active");


        // Links (banners clickeables)
        private By CarouselItems => By.CssSelector(".andes-carousel-snapped__slide a");


        // Imágenes del carrusel
        private By CarouselImages =>
            By.CssSelector(".andes-carousel-snapped__slide img");

        // Flecha siguiente
        private By NextButton =>
            By.CssSelector("[data-andes-carousel-snapped-control='next']");

        // Flecha anterior
        private By PreviousButton =>
            By.CssSelector("[data-andes-carousel-snapped-control='previous']");


        public bool IsDisplayed()
        {
            return driver.FindElement(NextButton).Displayed;
        }

        public int GetSlideCount()
        {
            return driver.FindElements(CarouselSlides).Count;
        }

        public void ClickNext()
        {
            driver.FindElement(NextButton).Click();
        }

        public void ClickPrevious()
        {
            driver.FindElement(PreviousButton).Click();
        }

        public void ClickActiveBanner()
        {
            var activeSlide = driver.FindElement(ActiveSlide);
            activeSlide.FindElement(By.TagName("a")).Click();
        }
    }
}