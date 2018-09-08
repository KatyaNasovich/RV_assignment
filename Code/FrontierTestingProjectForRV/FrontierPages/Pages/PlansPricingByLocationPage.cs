using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class PlansPricingByLocationPage : BasePage
    {
        public PlansPricingByLocationPage(IWebDriver driver) : base(driver)
        {
        }

        #region Locators

        private const string LocatorCurrentLocationByZip = "div.hero__location h3";
        
        #endregion

        #region Methods

        public string GetLocationTextValue()
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorCurrentLocationByZip))).Text;
        }

        #endregion
    }
}
