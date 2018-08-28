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

        #region Tests

        [Description("This test covers TC1 and TC5 functionality: verifies that user is able to click through all links located at the very top of the header - auxiliary navigation menu - then go back by clicking browser arrow or Frontier logo.")]
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


        [Description("This test covers TC3 except steps 3: re-deirect is coverd in previous tests, works same here. Test verifies drop-downs on top nav menu appear on mouse hover and links in them are clickable.")]
        [Category("Navigation")]
        [Test]
        public void VerifyTopMenuDropDownsAppearOnMouseHover()
        {
            var mainNavMenu = new MainNavigationMenu(driver);
            mainNavMenu.CheckDropDownAppearOnHover();
        }


        [Description("This test covers TC4: checks that Shop Online button is activated on hover - changes its color.")]
        [Category("General")]
        [Test]
        public void VerifyShopButtonIsActivatedOnHover()
        {
            var mainNavMenu = new MainNavigationMenu(driver);
            Assert.IsTrue(mainNavMenu.CheckShopButtonColor(), "Shop Online button color remains the same on hover.");
        }


        [Description("This test covers TC6 functionality: verifies that user is able to scroll down to the footer and still see header section since its position remains fixed.")]
        [Category("AuxiliaryMenuLinks")]
        [Test]
        public void VerifyHeaderIsVisibleWhenScrolling()
        {
            var landingPage = new LandingPage(driver);
            landingPage.VerifyScrollingToFooter();
        }


        [Description("This test covers T7 functionality: verifies that sections with phone numbers have links which prompt a user to call a number while clicking on these links. In this test do not click on links, sice its implemetation depends on device/browser settings.")]
        [Category("Calling")]
        [Test]
        public void VerifyPhoneLinksPresenceInSections()
        {
            var bannerSection = new BannerSection(driver);
            var moreThanInternetSection = new MoreThanInternetSection(driver);
            var mastFootRedSection = new MasterFooterRedSection(driver);

            Assert.AreEqual(bannerSection.GetValueFromPhoneLinkOnBanner(), moreThanInternetSection.GetValueFromPhoneLinkOnAdSection());
            Assert.AreEqual(bannerSection.GetValueFromPhoneLinkOnBanner(), mastFootRedSection.GetValueFromLinkOnFootSection());
        }


        [Description("This test covers TC8 but step 2 functionality: verifies that all legal information are displayed (annotations/disclaimers/term, etc.) and user is able to click to 'legal' links on the footer")]
        [Category("Legal")]
        [Test]
        public void VerifyLegalInformationPresence()
        {
            var landingPage = new LandingPage(driver);
            Assert.IsTrue(landingPage.VerifyLogoPresence(), "Frontier logo is not displayed on home page!");

            var footer = new Footer(driver);
            Assert.IsTrue(footer.VerifyCopyrightSignPresence(), "Frontier copyright sing is not displayed!");

            var privacyPolicyPage = footer.GoToPrivacyPolicyPage();
            driver.Navigate().Back();

            var termsConditionsPage = footer.GoToTermsConditionsPage();
            driver.Navigate().Back();

            var accessibilityPage = footer.GoToAccessibilityPage();
        }


        [Description("This test covers TC8 Step 2: checks that annotation sign near the price on the left has a corresponding disclaimer in footer section")]
        [Category("Legal")]
        [Test]
        public void VerifyLegalDisclaimersOnLandingPage()
        {
            var landingPage = new LandingPage(driver);
            landingPage.VerifyDisclaimers();
        }


        [Description("This test covers TC10 functionality: verifies that user is able to view services/shop by clicking on services/products shopping links")]
        [Category("Services/Shopping")]
        [Test]
        public void VerifyServicesAndProductsLinks()
        {
            var landingPage = new LandingPage(driver);

            var productsOfferingsSection = new ProductsOfferingsSection(driver);
            var internetServicePage = productsOfferingsSection.GoToInternetServicePage();
            Assert.IsTrue(driver.Title.Contains("Internet"), "Incorrect page title!");
            driver.Navigate().Back();

            var phoneServicePage = productsOfferingsSection.GoToPhoneServicePage();
            Assert.IsTrue(driver.Title.Contains("Phone"), "Incorrect page title!");
            driver.Navigate().Back();

            var tvServicePage = productsOfferingsSection.GoToTvServicePage();
            Assert.IsTrue(driver.Title.Contains("TV"), "Incorrect page title!");
            driver.Navigate().Back();

            var bundlesPage = productsOfferingsSection.GoToBundlesPage();
            Assert.IsTrue(driver.Title.Contains("Bundles"), "Incorrect page title!");
        }


        [Description("This test covers TC11 and verifies address checker functionslity.")]
        [Category("Services/Shopping")]
        [Test]
        public void VerifyAddressChecker()
        {
            var addressCheckSection = new AddressCheckSection(driver);
            string zipToCheck = "60610";
            var plansPricingByLocationPage = addressCheckSection.ShowPlansByLocation(zipToCheck);
            Assert.IsTrue(plansPricingByLocationPage.GetLocationTextValue().Contains(zipToCheck), "Page displays available plans for incorrect location.");
            driver.Navigate().Back();
           
            Assert.IsTrue(addressCheckSection.VerifyErrorsAppearOnBlankSubmission(), "Error message does not appear if trying to submit without entering ZIP code!");
        }

        #endregion
    }
}
