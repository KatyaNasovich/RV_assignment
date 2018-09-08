using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class LandingPage : BasePage
    {
        public LandingPage(IWebDriver driver) : base(driver)
        {
        }

        public void VerifyScrollingToFooter()
        {
            var footer = Driver.FindElement(By.ClassName("mastfoot"));
            ScrollToElement(footer);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("nav-legal__copyright")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("masthead")));
        }

        public bool VerifyLogoPresence()
        {
            try
            {
                if (!(Driver.FindElement(By.ClassName("masthead__logo")).Displayed))
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

        public void ScrollToProductsOfferingsSection()
        {
            var productsOfferingsSection = Driver.FindElement(By.CssSelector("section.section--products-cta"));
            ScrollToElement(productsOfferingsSection);
        }
    }
}
