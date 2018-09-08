using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class ProductsOfferingsSection : BasePage
    {
        private const string LocatorTemplateItem = "a#js-track-home-shop-{0}";

        public ProductsOfferingsSection(IWebDriver driver) : base(driver)
        {
        }

        public InternetServicePage GoToInternetServicePage()
        {
            Driver.FindElement(By.CssSelector(string.Format(LocatorTemplateItem, "internet"))).Click();
            return new InternetServicePage(Driver);
        }

        public TvServicePage GoToTvServicePage()
        {
            Driver.FindElement(By.CssSelector(string.Format(LocatorTemplateItem, "tv"))).Click();
            return new TvServicePage(Driver);
        }

        public PhoneServicePage GoToPhoneServicePage()
        {
            Driver.FindElement(By.CssSelector(string.Format(LocatorTemplateItem, "plans"))).Click();
            return new PhoneServicePage(Driver);
        }

        public BundlesPage GoToBundlesPage()
        {
            Driver.FindElement(By.CssSelector(string.Format(LocatorTemplateItem, "bundles"))).Click();
            return new BundlesPage(Driver);
        }
    }
}
