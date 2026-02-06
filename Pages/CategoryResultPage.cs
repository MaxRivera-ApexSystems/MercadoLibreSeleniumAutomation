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
            Thread.Sleep(5000);
            return driver.FindElements(ProductCards).Count;
        }


    }
}
