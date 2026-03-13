using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ManualToSdetMercadoLibre.Pages
{
    public class LoginPage : BaseComponent
    {
        // --- Locators ---
        private readonly By EmailInput = By.CssSelector("input[data-testid='user_id']");
        private readonly By ContinueButton = By.XPath("//button[@type='submit']");
        private readonly By PasswordInput = By.Id("password");
        private readonly By LoginButton = By.XPath("//button[@type='submit']");
        private readonly By ErrorMessage = By.CssSelector(".ui-form-error");

        public LoginPage(IWebDriver driver) : base(driver) { }

        // --- Actions ---
        public LoginPage EnterEmail(string email)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(EmailInput).Any() && d.FindElement(EmailInput).Displayed);
            var emailField = driver.FindElement(EmailInput);
            emailField.Clear();
            emailField.SendKeys(email);
            return this;
        }

        public LoginPage ClickContinue()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(ContinueButton).Any() && d.FindElement(ContinueButton).Enabled);
            driver.FindElement(ContinueButton).Click();
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(PasswordInput).Any() && d.FindElement(PasswordInput).Displayed);
            var passwordField = driver.FindElement(PasswordInput);
            passwordField.Clear();
            passwordField.SendKeys(password);
            return this;
        }

        public HomePage ClickLogin()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(LoginButton).Any() && d.FindElement(LoginButton).Enabled);
            driver.FindElement(LoginButton).Click();
            return new HomePage(driver);
        }

        public string GetErrorMessage()
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElements(ErrorMessage).Any() && d.FindElement(ErrorMessage).Displayed);
                return driver.FindElement(ErrorMessage).Text;
            }
            catch
            {
                return null;
            }
        }

        // --- Convenience method for full login flow ---
        public void InjectLoginCookie()
        {
            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/");

            Cookie ssidCookie = new Cookie(
                "ssid",
                "ghy-031313-NwvAXg9IjHVQkFxsVSnL60ZwH8LgVN-__-3265884414-__-1868117798071--RRR_0-RRR_0",
                ".mercadolibre.com.mx",
                "/",
                DateTime.Now.AddHours(2)
            );

            driver.Manage().Cookies.AddCookie(ssidCookie);

            driver.Navigate().Refresh();
        }
        public LoginPage LoginAs(string email, string password)
        {
            EnterEmail(email)
                .ClickContinue()
                .EnterPassword(password)
                .ClickLogin();
            return this;
        }
    }
}