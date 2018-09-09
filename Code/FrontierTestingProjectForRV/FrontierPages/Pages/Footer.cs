using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class Footer : BasePage
    {
        public Footer(IWebDriver driver) : base(driver)
        {
        }

        #region Locators

        private const string LocatorPrivacyPolicy = "//ul[@class='nav-legal__links']//a[contains(text(), 'Privacy')]";
        private const string LocatorTermsConditionsLink = "//ul[@class='nav-legal__links']//a[contains(text(), 'Terms')]";
        private const string LocatorAccessibility = "//ul[@class='nav-legal__links']//a[contains(text(), 'Accessibility')]";

        private const string LocatorPrivacyPolicyHeadline = "//h1[contains(text(), 'Privacy')]";
        private const string LocatorTermsConditionsHeadline = "//h1[contains(text(), 'Terms')]";
        private const string LocatorAccessibilityHeadline = "//h1[contains(text(), 'Accessibility')]";

        #endregion

        #region Methods

        public bool VerifyCopyrightSignPresence()
        {
            try
            {
                if (!(Driver.FindElement(By.ClassName("nav-legal__copyright")).Displayed))
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
            Driver.FindElement(By.XPath(LocatorPrivacyPolicy)).Click();

            // verification that correct page appears
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorPrivacyPolicyHeadline)));
            return new PrivacyPolicyPage(Driver);
        }

        public TermsConditionsPage GoToTermsConditionsPage()
        {
            Driver.FindElement(By.XPath(LocatorTermsConditionsLink)).Click();

            // verification that correct page appears
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorTermsConditionsHeadline)));
            return new TermsConditionsPage(Driver);
        }

        public AccessibilityPage GoToAccessibilityPage()
        {
           Driver.FindElement(By.XPath(LocatorAccessibility)).Click();

            // verification that correct page appears
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorAccessibilityHeadline)));
            return new AccessibilityPage(Driver);
        }

        #endregion
    }
}
