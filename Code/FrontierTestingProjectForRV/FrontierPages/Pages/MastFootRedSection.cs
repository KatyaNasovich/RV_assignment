using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class MasterFooterRedSection : BasePage
    {
        public MasterFooterRedSection(IWebDriver driver) : base(driver)
        {
        }

        public string GetValueFromLinkOnFootSection()
        {
            var mastFootSection = driver.FindElement(By.CssSelector("div.section--mastfoot__phone"));
            ScrollToElement(mastFootSection);

            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.section--mastfoot__phone a"))).GetAttribute("href");
        }
    }
}
