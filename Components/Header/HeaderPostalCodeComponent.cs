using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Components.Header
{
    public class HeaderPostalCodeComponent : BaseComponent
    {
        public HeaderPostalCodeComponent(IWebDriver driver) : base(driver) { }

        // Locators - Es necesario declararlos como private o protected(protected en caso de reutilizarse por medio de herencia.)
        public IWebElement PostalCodeButton => driver.FindElement(By.XPath("//a[contains(@class,'nav-menu-cp')]"));

        // === Locators ===

        public IWebElement PostalCodeInput =>
            driver.FindElement(By.XPath("//input[@data-testid='zip-code-textfield']"));

        public IWebElement PostalCodeUseButton =>
            driver.FindElement(By.XPath("//button[@data-testid='button-use-zipcode']"));

        public IWebElement PostalCodeDisplayText =>
            driver.FindElement(By.XPath("//a[contains(@class,'nav-menu-cp')]"));

        public HeaderPostalCodeComponent OpenPostalCodeEditor()
        {
            PostalCodeButton.Click();
            return this;
        }

        public HeaderPostalCodeComponent UpdatePostalCode(string postalCode)
        {
            PostalCodeInput.SendKeys(postalCode);
            PostalCodeUseButton.Click();
            return this;
        }

        public string DisplayedPostalCode => PostalCodeDisplayText.Text.Trim();

    }
}

