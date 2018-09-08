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
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='banner__container']//a"))).GetAttribute("href");
        }
    }
}
