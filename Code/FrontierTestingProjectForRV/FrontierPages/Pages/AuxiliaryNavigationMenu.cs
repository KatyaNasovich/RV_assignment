using OpenQA.Selenium;


namespace FrontierPages.Pages
{
    public class AuxiliaryNavigationMenu : BasePage
    {
        public AuxiliaryNavigationMenu(IWebDriver driver) : base(driver)
        {
        }

        #region Locators values

        private const string LocatorTemplateMenuItemDesktop = "//div[@class = 'show-for-medium-up']//nav[@class= 'nav-aux']//a[contains(text(), '{0}')]";
        private const string LocatorTemplateMenuItemMobile = "//div[@class = 'hide-for-medium-up']//nav[@class= 'nav-aux']//a[contains(text(), '{0}')]";
        private const string LocatorHamburgerMenu = ".masthead__menu.js-menu-toggle";

        #endregion

        #region Methods
        public BusinessPage GoToBusinessPage()
        {
            GoToMenuItem("Business");
            return new BusinessPage(Driver);
        }

        public ExistingCustomersPage GoToExistingCustomersPage()
        {
            GoToMenuItem("Customers");
            return new ExistingCustomersPage(Driver);
        }

        public MyAccountPage GoToMyAccountPage()
        {
            GoToMenuItem("Account");
            return new MyAccountPage(Driver);
        }

        public EspanolPage GoToEspanolPage()
        {
            GoToMenuItem("Espanol");
            return new EspanolPage(Driver);
        }

        private void GoToMenuItem(string menuItemText)
        {
            IWebElement hamburgerMenu = null;
            try
            {
                hamburgerMenu = Driver.FindElement(By.CssSelector(LocatorHamburgerMenu));
                if (!hamburgerMenu.Displayed)
                {
                    hamburgerMenu = null;
                }
            }
            catch (NoSuchElementException)
            {
            }

            if (hamburgerMenu == null)
            {
                // Desktop option
                Driver.FindElement(By.XPath(string.Format(LocatorTemplateMenuItemDesktop, menuItemText))).Click();
            }
            else
            {
                // Mobile option
                hamburgerMenu.Click();
                Driver.FindElement(By.XPath(string.Format(LocatorTemplateMenuItemMobile, menuItemText))).Click();
            }
        }
        #endregion
    }
}
