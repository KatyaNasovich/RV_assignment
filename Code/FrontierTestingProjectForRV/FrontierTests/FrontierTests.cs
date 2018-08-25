using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using FrontierPages.Pages;

namespace FrontierTests
{
    [TestFixture]
    public class FrontierTests
    {
        private IWebDriver driver;

        private static readonly string baseURL = ConfigurationManager.AppSettings["url"];
        private static readonly string browser = ConfigurationManager.AppSettings["browser"];

        #region Initialize & Cleanup

        [SetUp]
        public void BeforeEachTest()
        {
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser '{browser}'!");
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL);
        }

        [TearDown]
        public void AfterEachTest()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        #endregion

        [Description("This test covers TC1 and TC3 functionality: verifies that user is able to click through all links located at the very top of the header - auxiliary navigation menu - then go back by clicking browser arrow or Frontier logo")]
        [Category("AuxiliaryMenuLinks")]
        [Test]
        public void CheckLinksOnAuxiliaryNavigationMenu()
        {
            var auxiliaryMenu = new AuxiliaryNavigationMenu(driver);
            var businessPage = auxiliaryMenu.GoToBusinessPage();
            Assert.IsTrue(driver.Title.Contains("Business"), "Incorrect page title!");
            businessPage.GoBackClickingOnLogo();

            var existingCustomersPage = auxiliaryMenu.GoToExistingCustomersPage();
            Assert.IsTrue(driver.Title.Contains("Customer Service"), "Incorrect page title!");
            existingCustomersPage.GoBackClickingOnLogo();

            var myAccountPage = auxiliaryMenu.GoToMyAccountPage();
            Assert.IsTrue(driver.Title.Contains("Sign Into"), "Incorrect page title!");
            driver.Navigate().Back();

            var espanolPage = auxiliaryMenu.GoToEspanolPage();
            Assert.IsTrue(driver.Title.Contains("Español"), "Incorrect page title!");
        }

        [Description("This test covers TC4 functionality: verifies that user is able to scroll down to the footer and still see header section since its position remains fixed")]
        [Category("AuxiliaryMenuLinks")]
        [Test]
        public void VerifyHeaderIsVisibleWhenScrolling()
        {
            var landingPage = new LandingPage(driver);
            landingPage.VerifyScrollingToFooter();
        }

        [Description("This test covers TC5 functionality: verifies that sections with phone numbers have links which prompt a user to call a number while clicking on these links.")]
        [Category("General")]
        [Test]
        public void VerifyPhoneLinksPresenceInSections()
        {
            var bannerSection = new BannerSection(driver);
            var moreThanInternetSection = new MoreThanInternetSection(driver);
            var mastFootRedSection = new MasterFooterRedSection(driver);

            Assert.AreEqual(bannerSection.GetValueFromPhoneLinkOnBanner(), moreThanInternetSection.GetValueFromPhoneLinkOnAdSection());
            Assert.AreEqual(bannerSection.GetValueFromPhoneLinkOnBanner(), mastFootRedSection.GetValueFromLinkOnFootSection());
        }

        [Description("This test covers TC6 and TC7 step 5 functionality: verifies that all legal information are displayed (annotations/disclaimers/term, etc.) and user is able to click to 'legal' links on the footer")]
        [Category("Legal")]
        [Test]
        public void VerifyLegalInformationPresence()
        {
            var landingPage = new LandingPage(driver);
            Assert.IsTrue(landingPage.VerifyLogoPresence(), "Frontier logo is not displayed on home page!");

            landingPage.VerifyScrollingToFooter();
            var footer = new Footer(driver);
            Assert.IsTrue(footer.VerifyCopyrightSignPresence(), "Frontier copyright sing is not displayed!");

            var privacyPolicyPage = footer.GoToPrivacyPolicyPage();
            driver.Navigate().Back();

            var termsConditionsPage = footer.GoToTermsConditionsPage();
            driver.Navigate().Back();

            var accessibilityPage = footer.GoToAccessibilityPage();
            driver.Navigate().Back();
        }

        
        [Description("This test covers TC8 functionality: verifies that user is able to view services/shop by clicking on services/products shopping links")]
        [Category("Services/Shopping")]
        [Test]
        public void VerifyServicesAndProductsLinks()
        {
            var landingPage = new LandingPage(driver);
            landingPage.ScrollToProductsOfferingsSection();

            var productsOfferingsSection = new ProductsOfferingsSection(driver);
            var internetServicePage = productsOfferingsSection.GoToInternetServicePage();
            driver.Navigate().Back();

            var phoneServicePage = productsOfferingsSection.GoToPhoneServicePage();
            driver.Navigate().Back();

            var tvServicePage = productsOfferingsSection.GoToTvServicePage();
            driver.Navigate().Back();

            var bundlesPage = productsOfferingsSection.GoToBundlesPage();
            driver.Navigate().Back();
        }


        [Description("This test covers TC2 functionality (except steps 3 and 4 - re-deirect is coverd in previous tests, works the same here): verifies drop-downs on top nav menu appear on mouse hover event")]
        [Category("Services/Shopping")]
        [Test]
        public void VerifyTopMenuDropDownsAppearOnMouseHover()
        {
            var mainNavMenu = new MainNavigationMenu(driver);
            mainNavMenu.CheckDropDownAppearOnHover();
        }
    }
}
