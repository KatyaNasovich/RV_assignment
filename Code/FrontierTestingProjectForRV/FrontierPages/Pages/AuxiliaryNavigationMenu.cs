using OpenQA.Selenium;


namespace FrontierPages.Pages
{
    public class AuxiliaryNavigationMenu : BasePage
    {
        public AuxiliaryNavigationMenu(IWebDriver driver) : base(driver)
        {
        }

        #region Locators values

        private const string LocatorTemplateMenuItem = "//div[@class = 'show-for-medium-up']//nav[@class= 'nav-aux']//a[contains(text(), '{0}')]";

        #endregion

        #region Methods
        public BusinessPage GoToBusinessPage()
        {
            Driver.FindElement(By.XPath(string.Format(LocatorTemplateMenuItem, "Business"))).Click();
            return new BusinessPage(Driver);
        }

        public ExistingCustomersPage GoToExistingCustomersPage()
        {
            Driver.FindElement(By.XPath(string.Format(LocatorTemplateMenuItem, "Customers"))).Click();
            return new ExistingCustomersPage(Driver);
        }

        public MyAccountPage GoToMyAccountPage()
        {
            Driver.FindElement(By.XPath(string.Format(LocatorTemplateMenuItem, "Account"))).Click();
            return new MyAccountPage(Driver);
        }

        public EspanolPage GoToEspanolPage()
        {
            Driver.FindElement(By.XPath(string.Format(LocatorTemplateMenuItem, "Espanol"))).Click();
            return new EspanolPage(Driver);
        }
        #endregion
    }
}
