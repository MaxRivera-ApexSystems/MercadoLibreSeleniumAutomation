using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ManualToSdetMercadoLibre.Pages
{
        public class RegisterPage : BaseComponent
        {
         
            private readonly By NameInput = By.Id("first_name");
            private readonly By LastNameInput = By.Id("last_name");
            private readonly By EmailInput = By.Id("email");
            private readonly By PasswordInput = By.Id("password");
            private readonly By RegisterButton = By.XPath("//button[@type='submit']");
            private readonly By ErrorMessage = By.CssSelector(".ui-form-error");

            public RegisterPage(IWebDriver driver) : base(driver) { }

            //acciones 
            public RegisterPage EnterName(string name)
            {
                driver.FindElement(NameInput).SendKeys(name);
                return this;
            }

            public RegisterPage EnterLastName(string lastName)
            {
                driver.FindElement(LastNameInput).SendKeys(lastName);
                return this;
            }

            public RegisterPage EnterEmail(string email)
            {
                driver.FindElement(EmailInput).SendKeys(email);
                return this;
            }

            public RegisterPage EnterPassword(string password)
            {
                driver.FindElement(PasswordInput).SendKeys(password);
                return this;
            }

            public HomePage ClickRegister()
            {
                driver.FindElement(RegisterButton).Click();
                return new HomePage(driver);
            }

            public string GetErrorMessage()
            {
                return driver.FindElement(ErrorMessage).Text;
            }
        }
    }






