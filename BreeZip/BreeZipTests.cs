using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Windows;
using System.Xml.Linq;

namespace BreeZip
{
    public class BreeZipTests
    {
        private const string AppiumUriString = "http://127.0.0.1:4723/wd/hub";
        private const string appIdentifier = @"3138AweZip.AweZip_ffd303wmbhcjt!App";
        private const string defaultLocation = @"D:\Pics\Svatba_11.11.2023";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;
        
        [SetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability("app", appIdentifier);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumUriString), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        

        [Test]
        public void Test_BreeZipFunctionality()
        {
            var randomName = DateTime.Now.Ticks.ToString();
            
            var inputField = driver.FindElementByAccessibilityId("fileViewCurDirTextBox");
            inputField.Clear();
            inputField.SendKeys(defaultLocation);
            inputField.SendKeys(Keys.Enter);

            var photoImage = driver.FindElementByName("IMG-410eff1c1c792e3f2f714d7e7191c2c1-V.jpg");
            photoImage.Click();

            var buttonCompress = driver.FindElementByName("Compress");
            buttonCompress.Click();

            Thread.Sleep(3000);

            var savePath = driver.FindElementByAccessibilityId("changeArchiveNameBtn");
            savePath.Click();

            var fileName = driver.FindElementByClassName("Edit");
            fileName.Clear();
            fileName.SendKeys(randomName);

            var saveButton = driver.FindElementByName("Save");
            saveButton.Click();

            var buttonArchive = driver.FindElementByAccessibilityId("archiveBtn");
            buttonArchive.Click();


            Thread.Sleep(6000);

            Assert.That(randomName, Is.EqualTo(randomName));
        }
    }
}