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

            // verification that correct page appears
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorPrivacyPolicyHeadline)));
            return new PrivacyPolicyPage(driver);
        }

        public TermsConditionsPage GoToTermsConditionsPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorTermsConditionsLink))).Click();

            // verification that correct page appears
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorTermsConditionsHeadline)));
            return new TermsConditionsPage(driver);
        }

        public AccessibilityPage GoToAccessibilityPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorAccessibility))).Click();

            // verification that correct page appears
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LocatorAccessibilityHeadline)));
            return new AccessibilityPage(driver);
        }

        #endregion
    }
}
