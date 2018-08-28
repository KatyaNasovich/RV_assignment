using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Linq;

namespace FrontierPages.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void GoBackClickingOnLogo()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@id = 'js-track-logo']"))).Click();
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void VerifyDisclaimers()
        {
            var annotations = driver.FindElements(By.XPath("//*[@data-legal-annotation]"))
                .Select(e => e.Text);

            foreach (var annotation in annotations)
            {
                var disclaimerSelector = $"//*[@class='body-legal' and contains(text(), '" + annotation + "')]";
                try
                {
                    driver.FindElement(By.XPath(disclaimerSelector));
                }
                catch (NoSuchElementException)
                {
                    Assert.Fail("Disclaimer '" + annotation + "' not found in legal section");
                }
            }
        }
    }
}
