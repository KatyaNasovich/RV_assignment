using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class MainNavigationMenu : BasePage

    {
        public MainNavigationMenu(IWebDriver driver) : base(driver)
        {
        }

        #region Locators values

        private const string LocatorPlansPricing = "//div//ul[@id = 'menu-primary']/li/a[contains(text(), 'Plans & Pricing')]";
        private const string LocatorInternet = "//div//ul[@id = 'menu-primary']/li/a[contains(text(), 'Internet')]";
        private const string LocatorTv = "//div//ul[@id = 'menu-primary']/li/a[contains(text(), 'TV')]";
        private const string LocatorAllPlans = "//a[contains(text(), 'All Plans')]";
        private const string LocatorBundles = "//a[contains(text(), 'Bundles')]";
        private const string LocatorFiOsBundles = "//a[contains(text(), 'Frontier FiOS Bundles')]";
        private const string LocatorHighSpeedInternet = "//a[contains(text(), 'High Speed')]";
        private const string LocatorFiOsInternet = "//a[contains(text(), 'FiOS Internet')]";
        private const string LocatorWirelessServices = "//a[contains(text(), 'Wireless Services')]";
        private const string LocatorFiOsTv = "//a[contains(text(), 'FiOS TV')]";
        private const string LocatorVantageTv = "//a[contains(text(), 'Vantage TV')]";
        private readonly List<string> xpathListForPlansPricingDropDownLinks = new List<string>(new string[] { LocatorAllPlans, LocatorBundles, LocatorFiOsBundles });
        private readonly List<string> xpathListForInternetDropDownLinks = new List<string>(new string[] { LocatorHighSpeedInternet, LocatorFiOsInternet, LocatorWirelessServices });
        private readonly List<string> xpathListForTvDropDownLinks = new List<string>(new string[] { LocatorFiOsTv, LocatorVantageTv });

        #endregion


        #region Methods

        public void CheckDropDownAppearOnHover()
        {
            CheckDropDownLinksPresence(LocatorPlansPricing, xpathListForPlansPricingDropDownLinks);
            CheckDropDownLinksPresence(LocatorInternet, xpathListForInternetDropDownLinks);
            CheckDropDownLinksPresence(LocatorTv, xpathListForTvDropDownLinks);
        }

        private void CheckDropDownLinksPresence(string locator, List<string> xpathForLinks)
        {
            var elementPlansPricing = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));

            Actions action = new Actions(driver);
            action.MoveToElement(elementPlansPricing).Perform();

            foreach (var item in xpathForLinks)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(item)));
            }
        }

        public bool CheckShopButtonColor()
        {
            string shopOnlineButtonDefaultColor = driver.FindElement(By.CssSelector("a#js-track-nav-shop-online")).GetCssValue("color");
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.CssSelector("a#js-track-nav-shop-online"))).Perform();
            var shopOnlineButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a#js-track-nav-shop-online")));
            string shopOnlineButtonActivatedColor = shopOnlineButton.GetCssValue("color");

            if (shopOnlineButtonDefaultColor == shopOnlineButtonActivatedColor)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
