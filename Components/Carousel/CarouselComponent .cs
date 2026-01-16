using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Components.Carousel
{
    internal class CarouselComponent : PageControls
    {

        public CarouselComponent(IWebDriver driver) : base(driver) { }

        // ======================
        // LOCATORS
        // ======================

        // Main carousel container
        private IWebElement CarouselContainer =>
            driver.FindElement(By.CssSelector("section[aria-roledescription='Carrusel']"));

        // All visible slides
        private IReadOnlyCollection<IWebElement> Slides =>
            CarouselContainer.FindElements(By.CssSelector(".andes-carousel-snapped__slide"));

        // Slide navigation buttons
        private IWebElement NextButton =>
            CarouselContainer.FindElement(By.CssSelector("button[data-andes-carousel-snapped-control='next']"));

        private IWebElement PrevButton =>
            CarouselContainer.FindElement(By.CssSelector("button[data-andes-carousel-snapped-control='previous']"));

        public void GoToNextSlide() => NextButton.Click();

     
        public void GoToPreviousSlide() => PrevButton.Click();

       
        public int GetSlideCount() => Slides.Count;

     
        public List<string> GetSlideTitles()
        {
            return Slides
                .Select(s => s.Text.Trim())
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();
        }

       
        public int GetActiveSlideIndex()
        {
            var active = Slides.FirstOrDefault(s =>
                s.GetAttribute("class").Contains("--is-selected"));

            if (active == null)
                return -1;

            return Slides.ToList().IndexOf(active);
        }

        public void NavigateToSlide(string slidePartialText, int maxSteps = 8)
        {
            slidePartialText = slidePartialText.ToLower();

            for (int i = 0; i < maxSteps; i++)
            {
                var found = Slides.FirstOrDefault(s =>
                    s.Text.ToLower().Contains(slidePartialText));

                if (found != null)
                {
                    found.Click();
                    return;
                }

                GoToNextSlide();
            }

            throw new Exception($"Slide con texto '{slidePartialText}' no fue encontrada después de {maxSteps} pasos.");
        }




        public void LogCarouselSlides()
        {
            var slides = CarouselContainer.FindElements(By.XPath("./li"));

            Console.WriteLine("======= CAROUSEL SLIDES =======");

            for (int i = 0; i < slides.Count; i++)
            {
                var slide = slides[i];
                string content = slide.Text?.Trim();

                // Fallbacks if no visible text
                if (string.IsNullOrEmpty(content))
                {
                    content =
                        slide.GetAttribute("aria-label") ??
                        slide.GetAttribute("title") ??
                        slide.GetAttribute("alt") ??
                        "(no text / no label)";
                }

                // If still empty, try image source
                var imgs = slide.FindElements(By.TagName("img"));
                if (imgs.Any())
                {
                    content += $" | img: {imgs.First().GetAttribute("src")}";
                }

                Console.WriteLine($"[Carousel] Slide #{i}: {content}");
            }

            Console.WriteLine("================================");
        }


    }
}