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
            var footer = driver.FindElement(By.ClassName("mastfoot"));
            ScrollToElement(footer);
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("nav-legal__copyright")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("masthead")));
        }

        public bool VerifyLogoPresence()
        {
            try
            {
                if (!(driver.FindElement(By.ClassName("masthead__logo")).Displayed))
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
            var productsOfferingsSection = driver.FindElement(By.CssSelector("section.section--products-cta"));
            ScrollToElement(productsOfferingsSection);
        }
    }
}
