using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class ProductsOfferingsSection : BasePage
    {
        private const string LocatorInternet = "a#js-track-home-shop-internet";
        private const string LocatorTvService = "a#js-track-home-shop-tv";
        private const string LocatorPhoneService = "a#js-track-home-shop-plans";
        private const string LocatorBundlesService = "a#js-track-home-shop-bundles";

        public ProductsOfferingsSection(IWebDriver driver) : base(driver)
        {
        }

        public InternetServicePage GoToInternetServicePage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorInternet))).Click();
            return new InternetServicePage(driver);
        }

        public TvServicePage GoToTvServicePage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorTvService))).Click();
            return new TvServicePage(driver);
        }

        public PhoneServicePage GoToPhoneServicePage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorPhoneService))).Click();
            return new PhoneServicePage(driver);
        }

        public BundlesPage GoToBundlesPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorBundlesService))).Click();
            return new BundlesPage(driver);
        }
    }
}
