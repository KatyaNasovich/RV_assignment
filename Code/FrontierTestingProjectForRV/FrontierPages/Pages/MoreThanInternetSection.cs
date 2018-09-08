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
            var phoneNumberOnMediumDown = Driver.FindElement(By.CssSelector("div.button-phone.hide-for-large-up a"));
            if (phoneNumberOnMediumDown.Displayed)
            {
                return phoneNumberOnMediumDown.GetAttribute("href");
            }

            return Driver.FindElement(By.CssSelector("div.link-phone.show-for-large-up a")).GetAttribute("href");
        }
    }
}
