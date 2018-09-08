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
            var phoneNumberOnSmall = Driver.FindElement(By.CssSelector("a.section--mastfoot__button__phone"));
            if (phoneNumberOnSmall.Displayed)
            {
                return phoneNumberOnSmall.GetAttribute("href");
            }
            return Driver.FindElement(By.CssSelector("div.section--mastfoot__phone a")).GetAttribute("href");
        }
    }
}
