using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages.Base;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Pages
{
    public class CategoryResultPage : CategorysResultsBasePage
    {
        public CategoryResultPage(IWebDriver driver) : base(driver) { }


        public int GetProductCount()
        {
            Thread.Sleep(5000); // Sería conveniente hacerlo con un WebDriver wait si la busqueda posterior no está anidada.
            return driver.FindElements(ProductCards).Count;
        }


    }
}
