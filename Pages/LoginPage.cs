using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.config;
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

   
        // --- Convenience method for full login flow ---
        public HomePage InjectLoginCookie()
        {
            //Es conveneinte dejar este tipo de metodos para Setup de la prueba en vez del page object.
            //Para este caso en particular, la cookie no es solo para el HomePage u login, es para toda la aplicación.
            var cookieValue = ConfigReader.GetSsid(); // string
            Cookie ssidCookie = new Cookie("ssid", cookieValue, ".mercadolibre.com.mx", "/", DateTime.Now.AddHours(2));
            driver.Manage().Cookies.AddCookie(ssidCookie);
            driver.Manage().Cookies.AddCookie(ssidCookie);
            driver.Navigate().Refresh();
            return new HomePage(driver);

        }
        public HomePage LoginAs(string email, string password)
        {
            EnterEmail(email)
                .ClickContinue()
                .EnterPassword(password);

            return ClickLogin(); // esto regresa HomePage
        }
    }
}