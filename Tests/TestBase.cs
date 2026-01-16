using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
namespace ManualToSdetMercadoLibre.Tests
{
    public class TestBase
    {

         public IWebDriver driver;

       [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

           driver = new ChromeDriver(options);

          
        }

        [TearDown]
        public void TearDown()
        {


            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }






}

