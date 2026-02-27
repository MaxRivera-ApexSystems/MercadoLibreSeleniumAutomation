using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages.Base;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Pages
{
    public class SearchResultsPage : ProductListingPage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver) { }
        //SIDE NAVBAR LOCATORS 
        private readonly By SidebarContainer = By.CssSelector("aside.ui-search-sidebar");
        private readonly By FilterSectionTitles = By.CssSelector(".ui-search-filter-dt-title");
        private readonly By FilterOptions = By.CssSelector(".ui-search-filter-container a");
        private readonly By MinPriceInput = By.CssSelector("input[data-testid='Minimum-price']");
        private readonly By MaxPriceInput = By.CssSelector("input[data-testid='Maximum-price']");
        private readonly By ApplyPriceButton = By.CssSelector("button[data-testid='ui-search-range-filter__text-submit-test']");
        private readonly By ResultItems = By.CssSelector(".ui-search-result");
        private readonly By ResultsCountLabel = By.CssSelector(".ui--search-result__quantity-results");




        private readonly By ResultsGrid =
            By.CssSelector("ol.ui-search-layout--grid");

        private readonly By GridItems =
            By.CssSelector("ol.ui-search-layout--grid > li.ui-search-layout__item");

        private readonly By ProductCardWrapper =
            By.CssSelector(".ui-search-result__wrapper");

        private readonly By ProductTitleLink =
            By.CssSelector(".poly-component__title");

        private readonly By ProductPriceCurrent =
            By.CssSelector(".poly-price__current .andes-money-amount__fraction");

        private readonly By ProductOldPrice =
            By.CssSelector(".andes-money-amount--previous");

        private readonly By ProductDiscountBadge =
            By.CssSelector(".poly-price__disc_label");

        private readonly By ProductInstallments =
            By.CssSelector(".poly-price__installments");

        private readonly By ProductShipping =
            By.CssSelector(".poly-component__shipping");

        private readonly By ProductCondition =
            By.CssSelector(".poly-component__item-condition");

        private readonly By ProductSeller =
            By.CssSelector(".poly-component__seller");

        private readonly By CardCarouselContainer =
            By.CssSelector(".andes-carousel-snapped__container");

        private readonly By CardCarouselSlides =
            By.CssSelector(".andes-carousel-snapped__slide");

        private readonly By CardCarouselActiveSlide =
            By.CssSelector(".andes-carousel-snapped__slide--active");

        private readonly By CardCarouselNextButton =
            By.CssSelector("[data-andes-carousel-snapped-control='next']");

        private readonly By CardCarouselPreviousButton =
            By.CssSelector("[data-andes-carousel-snapped-control='previous']");

        private readonly By BookmarkButton =
            By.CssSelector("[data-testid='bookmark'] button");

        private readonly By BookmarkActiveState =
            By.CssSelector("button[aria-checked='true']");



    }
}
