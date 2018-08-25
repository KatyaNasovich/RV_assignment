using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class Footer : BasePage
    {
        public Footer(IWebDriver driver) : base(driver)
        {
        }

        #region String values for locators

        private const string LocatorPrivacyPolicy = "//ul[@class='nav-legal__links']//a[contains(text(), 'Privacy')]";
        private const string LocatorTermsConditions = "//ul[@class='nav-legal__links']//a[contains(text(), 'Terms')]";
        private const string LocatorAccessibility = "//ul[@class='nav-legal__links']//a[contains(text(), 'Accessibility')]";

        #endregion

        #region Methods

        public bool VerifyCopyrightSignPresence()
        {
            try
            {
                if (!(driver.FindElement(By.ClassName("nav-legal__copyright")).Displayed))
                {
                    return false;
                }
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public PrivacyPolicyPage GoToPrivacyPolicyPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorPrivacyPolicy))).Click();
            return new PrivacyPolicyPage(driver);
        }

        public TermsConditionsPage GoToTermsConditionsPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorTermsConditions))).Click();
            return new TermsConditionsPage(driver);
        }

        public AccessibilityPage GoToAccessibilityPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorAccessibility))).Click();
            return new AccessibilityPage(driver);
        }

        #endregion
    }
}
