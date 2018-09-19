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

        private const string LocatorTemplateForFooterLinks = "//ul[@class='nav-legal__links']//a[contains(text(), '{0}')]";
        private const string LocatorTermsConditionsLink = "//ul[@class='nav-legal__links']//a[contains(text(), 'Terms')]";
        private const string LocatorAccessibility = "//ul[@class='nav-legal__links']//a[contains(text(), 'Accessibility')]";

        private const string LocatorTemplateForHeadline = "//h1[contains(text(), '{0}')]";
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
            Driver.FindElement(By.XPath(string.Format(LocatorTemplateForFooterLinks, "Privacy"))).Click();

            // verification that correct page appears
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(LocatorTemplateForHeadline, "Privacy"))));
            return new PrivacyPolicyPage(Driver);
        }

        public TermsConditionsPage GoToTermsConditionsPage()
        {
            Driver.FindElement(By.XPath(string.Format(LocatorTemplateForFooterLinks, "Terms"))).Click();

            // verification that correct page appears
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(LocatorTemplateForHeadline, "Terms"))));
            return new TermsConditionsPage(Driver);
        }

        public AccessibilityPage GoToAccessibilityPage()
        {
           Driver.FindElement(By.XPath(string.Format(LocatorTemplateForFooterLinks, "Accessibility"))).Click();

            // verification that correct page appears
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(LocatorTemplateForHeadline, "Accessibility"))));
            return new AccessibilityPage(Driver);
        }

        #endregion
    }
}
