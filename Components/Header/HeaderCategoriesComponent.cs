using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualToSdetMercadoLibre.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ManualToSdetMercadoLibre.Components.Header
{
    public class HeaderCategoriesComponent : BaseComponent
    {
        
        public HeaderCategoriesComponent(IWebDriver driver) : base(driver) { }
        // ===== MAIN BUTTON =====

        //Se sugiere que todo lo referente a locators sea privado o protected (protected en caso de que se use herencia donde se reutilize el locator)
        public IReadOnlyCollection<IWebElement> NavMenuList => driver.FindElements(By.XPath("//ul[@class='nav-menu-list']/li"));
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
        public IReadOnlyCollection<IWebElement> SubCategoryGroupsOnlyTitles => SubMenuContainer.FindElements(By.XPath("//div[contains(@class,'nav-categs-detail__title')]//a"));

        // items inside each group
        public IReadOnlyCollection<IWebElement> SubCategoryLinks => SubMenuContainer.FindElements(By.CssSelector("ul.nav-categs-detail__categ-list a"));

        public IList<IWebElement> GroupTitles => SubMenuContainer.FindElements(By.CssSelector("a.nav-categs-detail__title"));

        //Sub dropdown Tecnologia
        private By CategoryGroupContainers => By.XPath("//div[contains(@class,'nav-categs-detail__categ')]");


        private By CategoryTitleLink => By.XPath(".//div[contains(@class,'nav-categs-detail__title')]//a");


        private By CategoryItemsLinks => By.XPath(".//ul[contains(@class,'nav-categs-detail__categ-list')]//a");



        //  BOTONES  DE PERFIL DE USUARIO
        public By UserMenuContainer => By.Id("nav-header-menu")
            ;

        // Links del menú de usuario
        public By CreateAccountLink => By.CssSelector("a[data-link-id='registration']");


        public By LoginLink => By.CssSelector("a[data-link-id='login']");


        public By PurchasesLink => By.CssSelector("a[data-link-id='purchases']");


        // Icono del carrito
        public By CartIcon => By.Id("nav-cart");




        // ===== ACTIONS =====

        //Technology dropdown Groups
        public IList<string> GetItemsForGroup(string groupTitle)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //kgda?
            var groupContainer = GetGroupContainerByTitle(groupTitle);

            var items = groupContainer.FindElements(CategoryItemsLinks);

            return items.Where(i => i.Displayed).Select(i => i.Text.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();

        }

        public void ClickGroupTitle(string groupTitle)
        {
            var groupContainer = GetGroupContainerByTitle(groupTitle);

            var titleLink = groupContainer.FindElement(CategoryTitleLink);

            titleLink.Click();
        }

        public void ClickItemInGroup(string groupTitle, string itemText)
        {
            var groupContainer = GetGroupContainerByTitle(groupTitle);

            var items = groupContainer.FindElements(CategoryItemsLinks);

            var itemToClick = items.FirstOrDefault(i => i.Text.Trim().Equals(itemText));

            if (itemToClick == null)
            {
                throw new NoSuchElementException(
                    $"No se encontró el item '{itemText}' en el grupo '{groupTitle}'"
                );
            }

            itemToClick.Click();
        }

        public IList<string> GetAllItemsFromAllGroups()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var groups = wait.Until(d => d.FindElements(CategoryGroupContainers));

            return groups
                .SelectMany(group =>
                    group.FindElements(CategoryItemsLinks)
                )
                .Where(i => i.Displayed)
                .Select(i => i.Text.Trim())
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();
        }

        public IList<string> GetAvailableGroupTitles()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Esperar a que existan grupos. --Excelente forma de esperar!
            var groups = wait.Until(d =>
            {
                var elements = d.FindElements(CategoryGroupContainers);
                return elements.Count > 0 ? elements : null;
            });

            var titles = new List<string>();

            foreach (var group in groups)
            {
                var titleElement = group.FindElement(CategoryTitleLink);

                if (titleElement.Displayed && !string.IsNullOrWhiteSpace(titleElement.Text))
                {
                    titles.Add(titleElement.Text.Trim());
                }
            }

            return titles;
        }


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
        public HeaderCategoriesComponent OpenCategoriesSubDropDown()
        {
            Hover(GetCategoryElement("Tecnología"));//No se recomienda hardcodear datos de prueba en el Page Object.

            return this;
        }


        //helper del  GetItemsForGroup
        private IWebElement GetGroupContainerByTitle(string groupTitle)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var groups = wait.Until(d => d.FindElements(CategoryGroupContainers));



            foreach (var group in groups)
            {
                var titleElement = group.FindElement(CategoryTitleLink);

                if (titleElement.Text.Trim().Equals(groupTitle))
                {
                    return group;
                }
            }

            throw new NoSuchElementException($"No se encontró el grupo '{groupTitle}'");
        }



        //Se sugiere que lo regresado no sea un void sino la referencia a un page object que maneje el componente que aparece al dar click en el Menu Item.
        //NavMenu methods
        public void ClickNavMenuItem(string menuText) 
        {
            var menuItems = NavMenuList;

            var itemToClick = menuItems.FirstOrDefault(we => we.Displayed && we.Text.Trim().Equals(menuText));


            if (itemToClick == null)
            {
                throw new NoSuchElementException(
                    $"No se encontró el menú '{menuText}'"
                );
            }

            itemToClick.Click();
        }


        //Se sugiere que lo regresado no sea un void sino la referencia a un page object que maneje el componente que aparece al dar click en Crear Cuenta
        //acciones menu de usario al final de nav menu 
        public void ClickCreateAccount()
        {
            driver.FindElement(CreateAccountLink).Click();
        }

        //Se sugiere que lo regresado no sea un void sino la referencia a un page object que maneje el componente que aparece al dar click en Login
        public void ClickLogin()
        {
            driver.FindElement(LoginLink).Click();
        }

        //Se sugiere que......dar click en Compras
        public void ClickPurchases()
        {
            driver.FindElement(PurchasesLink).Click();
        }

        //Se sugiere que.....dar click en el Carrito
        public void ClickCart()
        {
            driver.FindElement(CartIcon).Click();
        }



    }
















}

