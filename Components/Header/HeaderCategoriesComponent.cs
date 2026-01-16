using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ManualToSdetMercadoLibre.Components.Header
{
    internal class HeaderCategoriesComponent : PageControls
    {
        public HeaderCategoriesComponent(IWebDriver driver) : base(driver) { }

        // ===== MAIN BUTTON =====
        public IWebElement NavMenuList => driver.FindElement(By.XPath("//ul[@class='nav-menu-list']"));

        public IWebElement CategoriasButton => driver.FindElement(By.XPath("//a[@data-js='nav-menu-categories-trigger']"));
        // NEW — overlay locator Hover over 
        public IWebElement CategoryOverlay => driver.FindElement(By.XPath("//div[contains(@class,'nav-categs-overlay')]"));

        public IReadOnlyCollection<IWebElement> CategoryItems => driver.FindElements(By.XPath("//ul[@class='nav-categs-departments']//a"));
        //===== GENERIC CATEGORIE LOCATOR =====
        public IWebElement GetCategoryElement(string categoryName) => driver.FindElement(By.XPath($"//ul//a[normalize-space()='{categoryName}']"));
        // SUBMENU of  teconology category 
        public IWebElement SubMenuContainer => driver.FindElement(By.CssSelector("div.nav-categs-detail"));
        // MAIN title of submenu
        public IWebElement SubMenuTitle => SubMenuContainer.FindElement(By.CssSelector("header div[role='heading']"));
        // ALL subcategory groups
        public IReadOnlyCollection<IWebElement> SubCategoryGroups => SubMenuContainer.FindElements(By.CssSelector("div.nav-categs-detail__categ"));
        // items inside each group
        public IReadOnlyCollection<IWebElement> SubCategoryLinks => SubMenuContainer.FindElements(By.CssSelector("ul.nav-categs-detail__categ-list a"));
        // ===== ACTIONS =====
        public CategoryResultPage OpenCategory(string category)
        {
            GetCategoryElement(category).Click();
            return new CategoryResultPage(driver);

        }

        public HeaderCategoriesComponent OpenCategoriesDropDown()
        {
            Hover(CategoriasButton);
            return this;
        }



      







    }
















}

