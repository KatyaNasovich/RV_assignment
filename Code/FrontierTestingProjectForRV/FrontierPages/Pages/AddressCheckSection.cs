using System;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class AddressCheckSection : BasePage
    {
        public AddressCheckSection(IWebDriver driver) : base(driver)
        {
        }

        #region Locators

        private const string LocatorZipInputField = "(//form[@id= 'form-address-check'])[1]//input";
        private const string LocatorCurrentLocation = "div.hero__location";
        private const string LocatorButtonCheckAvailability = "button#js-track-form-check-availability";
        private const string LocatorErrorMessage = "//p[contains(text(), 'Address is required')]";

        #endregion

        #region Methods

        public PlansPricingByLocationPage ShowPlansByLocation(string zipCode)
        {
            var inputField = Driver.FindElement(By.XPath(LocatorZipInputField));
            inputField.SendKeys(zipCode + Keys.Enter);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorCurrentLocation)));
            return new PlansPricingByLocationPage(Driver);
        }

        public bool VerifyErrorsAppearOnBlankSubmission()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorZipInputField))).Clear();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(LocatorButtonCheckAvailability))).Click();

            if (!Driver.FindElement(By.XPath(LocatorErrorMessage)).Displayed)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
