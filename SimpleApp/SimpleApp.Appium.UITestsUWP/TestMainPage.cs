using System;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace SimpleApp.Appium.UITestsUWP
{
    public class TestMainPage<T, W>: AppiumTest<T, W>
        where T : AppiumDriver<W>
        where W : IWebElement
    {
        public TestMainPage(string testName): base(testName)
        {
        }

        protected override T GetDriver()
        {
            // Implemented by platform specific class
            throw new NotImplementedException();
        }

        protected override void InitAppiumOptions(AppiumOptions appiumOptions)
        {
            // Implemented by platform specific class
            throw new NotImplementedException();
        }

        [SetUp()]
        public void SetupTest()
        {
            appiumDriver.CloseApp();
            appiumDriver.LaunchApp();
        }

        [Test()]
        public void TestLogin()
        {
            // appiumDriver.FindElement(By.XPath("//button@id='LoginTabAID'")).Click();
            appiumDriver.FindElement(By.XPath("//*[@content-desc='Login']")).Click();
            // appiumDriver.FindElement(By.Id("com.companyname.simpleapp:id/UserName")).SendKeys("user@email.com");
            // appiumDriver.FindElement(By.Id("UserName")).SendKeys("user@email.com");
            appiumDriver.FindElement(By.XPath("//*[@content-desc='UserName']")).SendKeys("user@email.com");
            appiumDriver.FindElement(By.XPath("//*[@content-desc='Password']")).SendKeys("password");
            appiumDriver.FindElement(By.XPath("//*[@content-desc='LoginButton']")).Click();
            // var text = GetElementText("StatusLabel"); // Android is "text"
            // var text = appiumDriver.FindElement(By.XPath("//*[@content-desc='StatusLabel']")).ToString().Trim();       
            // var text = appiumDriver.FindElement(By.XPath("//*[@content-desc='StatusLabel']"));
            var text = appiumDriver.FindElement(By.XPath("//*[@content-desc='StatusLabel']"));

            string resultText = text.Text;

            Assert.IsNotNull(resultText);
            Assert.IsTrue(resultText.StartsWith("Logging in", StringComparison.CurrentCulture));  
        }

        [Test()]
        public void TestAddItem()
        {
            // appiumDriver.FindElement(By.Id("Browse")).Click();
            appiumDriver.FindElement(By.XPath("//*[@content-desc='Browse']")).Click();
            // appiumDriver.FindElement(By.Id("AddToolbarItem")).Click();
            appiumDriver.FindElement(By.XPath("//*[@content-desc='AddToolbarItem']")).Click();
            // var itemNameField = appiumDriver.FindElement(By.Id("ItemNameEntry"));
            var itemNameField = appiumDriver.FindElement(By.XPath("//*[@content-desc='ItemNameEntry']"));
            itemNameField.SendKeys("todo");

            // var itemDesriptionField = appiumDriver.FindElement(By.Id("ItemDescriptionEntry"));
            var itemDesriptionField = appiumDriver.FindElement(By.XPath("//*[@content-desc='ItemDescriptionEntry']"));
            itemDesriptionField.SendKeys("todo description");

            // appiumDriver.FindElement(By.Id("SaveToolbarItem")).Click();
            appiumDriver.FindElement(By.XPath("//*[@content-desc='SaveToolbarItem']")).Click();
        }

        [Test()]
        public void TestAbout()
        {
            if (IsAndroid == true)
            {
                // appiumDriver.FindElement(By.Id("AboutTabAID")).Click();
                appiumDriver.FindElement(By.XPath("//*[@content-desc='About']")).Click();
            } else
            {
                appiumDriver.FindElement(By.XPath("//*[content-desc='About']")).Click(); // works for iOS
            }
            
        }

        [TearDown()]
        public void TestCleanup()
        {
            appiumDriver.CloseApp();
        }
    }
}
