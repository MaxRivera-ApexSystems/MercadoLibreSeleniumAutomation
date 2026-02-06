using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ManualToSdetMercadoLibre.Pages
{
    public abstract class BaseComponent
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        protected BaseComponent(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Hover(IWebElement element)
        {
            new Actions(driver).MoveToElement(element).Perform();


        }

        protected void ClickWithJs(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);

        }


        public void ScrollWithJs() => ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 4);");

        
    }
}
