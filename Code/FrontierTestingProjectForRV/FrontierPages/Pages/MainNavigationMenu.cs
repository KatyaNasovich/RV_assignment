using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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

        #endregion


        #region Methods

        public void CheckDropDownAppearOnHover()
        {
            CheckDropDownLinksPresenceForPlansPricing();
            CheckDropDownLinksPresenceForInternet();
            CheckDropDownLinksPresenceForTv();
        }

        private void CheckDropDownLinksPresenceForPlansPricing()
        {
            var elementPlansPricing = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorPlansPricing)));

            Actions action = new Actions(driver);
            action.MoveToElement(elementPlansPricing).Perform();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LocatorAllPlans)));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LocatorBundles)));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LocatorFiOsBundles)));
        }

        private void CheckDropDownLinksPresenceForInternet()
        {
            var elementInternet= wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorInternet)));

            Actions action = new Actions(driver);
            action.MoveToElement(elementInternet).Perform();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LocatorHighSpeedInternet)));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LocatorFiOsInternet)));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LocatorWirelessServices)));
        }

        private void CheckDropDownLinksPresenceForTv()
        {
            var elementTv = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorTv)));

            Actions action = new Actions(driver);
            action.MoveToElement(elementTv).Perform();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LocatorFiOsTv)));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LocatorVantageTv)));
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
