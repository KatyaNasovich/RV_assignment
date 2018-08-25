using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class AuxiliaryNavigationMenu : BasePage
    {
        public AuxiliaryNavigationMenu(IWebDriver driver) : base(driver)
        {
        }

        #region String values for locators

        private const string LocatorBusiness = "(//nav[@class= 'nav-aux']//a[contains(text(), 'Business')])[1]";
        private const string LocatorExistingCustomers = "(//nav[@class= 'nav-aux']//a[contains(text(), 'Customers')])[1]";
        private const string LocatorMyAccount = "(//nav[@class= 'nav-aux']//a[contains(text(), 'Account')])[1]";
        private const string LocatorEspanol = "(//nav[@class= 'nav-aux']//a[contains(text(), 'Espanol')])[1]";

        #endregion

        #region Methods
        public BusinessPage GoToBusinessPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorBusiness))).Click();
            return new BusinessPage(driver);
        }

        public ExistingCustomersPage GoToExistingCustomersPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorExistingCustomers))).Click();
            return new ExistingCustomersPage(driver);
        }

        public MyAccountPage GoToMyAccountPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorMyAccount))).Click();
            return new MyAccountPage(driver);
        }

        public EspanolPage GoToEspanolPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorEspanol))).Click();
            return new EspanolPage(driver);
        }
        #endregion
    }
}
