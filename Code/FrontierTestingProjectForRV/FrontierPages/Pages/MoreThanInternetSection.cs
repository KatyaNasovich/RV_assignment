using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class MoreThanInternetSection : BasePage
    {
        public MoreThanInternetSection(IWebDriver driver) : base(driver)
        {
        }

        public string GetValueFromPhoneLinkOnAdSection()
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.link-phone.show-for-large-up a"))).GetAttribute("href");
        }
    }
}
