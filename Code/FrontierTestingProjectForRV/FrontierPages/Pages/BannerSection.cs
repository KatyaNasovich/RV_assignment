using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrontierPages.Pages
{
    public class BannerSection : BasePage
    {
        public BannerSection(IWebDriver driver) : base(driver)
        {
        }

        public string GetValueFromPhoneLinkOnBanner()
        {
            var phoneNumberOnHeader = Driver.FindElement(By.XPath("//span[@class='masthead__phone-wrap']//a"));
            if (phoneNumberOnHeader.Displayed)
            {
                return phoneNumberOnHeader.GetAttribute("href");
            }

            return Driver.FindElement(By.XPath("//div[@class='banner__container']//a")).GetAttribute("href");
        }
    }
}
