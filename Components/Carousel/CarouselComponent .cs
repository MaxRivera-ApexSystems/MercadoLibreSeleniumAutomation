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

    public  By ExhibitorCarousel =>
        By.CssSelector("[data-andes-carousel-snapped-component='true']");

        // Wrapper que contiene los slides
        public  By CarouselWrapper =>
            By.CssSelector(".andes-carousel-snapped__wrapper");

        // Todos los slides
        public  By CarouselSlides =>
            By.CssSelector(".andes-carousel-snapped__slide");

        // Slide activo
        public By ActiveSlide =>
            By.CssSelector(".andes-carousel-snapped__slide--active");

        // Links (banners clickeables)
        public By CarouselItems =>
            By.CssSelector(".andes-carousel-snapped__slide a");

        // Imágenes del carrusel
        public By CarouselImages =>
            By.CssSelector(".andes-carousel-snapped__slide img");

        // Flecha siguiente
        public   By NextButton =>
            By.CssSelector("[data-andes-carousel-snapped-control='next']");

        // Flecha anterior
        public By PreviousButton =>
            By.CssSelector("[data-andes-carousel-snapped-control='previous']");
    }
}