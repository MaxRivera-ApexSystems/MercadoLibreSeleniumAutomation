using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Pages
{
    public class LoginPage : BaseComponent
    {
        private readonly By EmailInput = By.Id("user_id");
        private readonly By ContinueButton = By.XPath("//button[@type='submit']");
        private readonly By PasswordInput = By.Id("password");
        private readonly By LoginButton = By.XPath("//button[@type='submit']");
        private readonly By ErrorMessage = By.CssSelector(".ui-form-error");

        public LoginPage(IWebDriver driver) : base(driver) { }

     

        public LoginPage EnterEmail(string email)
        {
            driver.FindElement(EmailInput).SendKeys(email);
            return this;
        }

        public LoginPage ClickContinue()
        {
            driver.FindElement(ContinueButton).Click();
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            driver.FindElement(PasswordInput).SendKeys(password);
            return this;
        }

        public HomePage ClickLogin()
        {
            driver.FindElement(LoginButton).Click();
            return new HomePage(driver);
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(ErrorMessage).Text;
        }
    }
}
