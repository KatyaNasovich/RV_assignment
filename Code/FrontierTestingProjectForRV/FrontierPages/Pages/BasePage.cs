using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Linq;

namespace FrontierPages.Pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        protected IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        protected WebDriverWait Wait
        {
            get
            {
                return wait;
            }
        }

        public void GoBackClickingOnLogo()
        {
            Driver.FindElement(By.XPath("//a[@id = 'js-track-logo']")).Click();
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void VerifyDisclaimers()
        {
            var annotations = Driver.FindElements(By.XPath("//*[@data-legal-annotation]"))
                .Select(e => e.Text);

            foreach (var annotation in annotations)
            {
                var disclaimerSelector = $"//*[@class='body-legal' and contains(text(), '{annotation}')]";
                try
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(disclaimerSelector)));
                }
                catch (NoSuchElementException)
                {
                    Assert.Fail($"Disclaimer {annotation} not found in legal section");
                }
            }
        }
    }
}
