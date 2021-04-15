using System;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SimpleApp.Appium.UITests.AppiumExtensions;

namespace SimpleApp.Appium.Core
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
            appiumDriver.FindElementByAccessibilityId("Login");

            // By XPath:
            // appiumDriver.FindElement(By.XPath("//*[@content-desc='UserName']")).SendKeys("user@email.com");
            // Or by AccessibilityID (AutomationID property in the XAML file
            appiumDriver.FindElementByAccessibilityId("UserName").SendKeys("user@email.com");

            appiumDriver.FindElementByAccessibilityId("Password").SendKeys("password");
            appiumDriver.FindElementByAccessibilityId("LoginButton").Click();

            var text = appiumDriver.FindElementByAccessibilityId("StatusLabel").Text;

            // string resultText = text.Text;

            Assert.IsNotNull(text);
            Assert.IsTrue(text.StartsWith("Logging in", StringComparison.CurrentCulture));  
        }

        [Test()]
        public void TestAddItem()
        {
            // appiumDriver.FindElement(By.Id("Browse")).Click();
            // appiumDriver.FindElement(By.XPath("//*[@content-desc='Browse']")).Click();
            appiumDriver.FindElementByAccessibilityId("Browse").Click();
            // appiumDriver.FindElement(By.Id("AddToolbarItem")).Click();
            // appiumDriver.FindElement(By.XPath("//*[@content-desc='AddToolbarItem']")).Click();
            appiumDriver.FindElementByAccessibilityId("AddToolbarItem").Click();
            // var itemNameField = appiumDriver.FindElement(By.Id("ItemNameEntry"));
            var itemNameField = appiumDriver.FindElementByAccessibilityId("ItemNameEntry");
            itemNameField.SendKeys("todo");

            // var itemDesriptionField = appiumDriver.FindElement(By.Id("ItemDescriptionEntry"));
            var itemDesriptionField = appiumDriver.FindElementByAccessibilityId("ItemDescriptionEntry");
            itemDesriptionField.SendKeys("todo description");

            // appiumDriver.FindElement(By.Id("SaveToolbarItem")).Click();
            appiumDriver.FindElementByAccessibilityId("SaveToolbarItem").Click();
        }

        [Test()]
        public void TestAbout()
        {
            // appiumDriver.FindElement(By.XPath("//*[@content-desc='About']")).Click();
            if (IsUwp)
            {
                appiumDriver.FindElementByName("About").Click();
            } else
            {
                appiumDriver.FindElementByAccessibilityId("About").Click();
            }           
        }

        [TearDown()]
        public void TestCleanup()
        {
            appiumDriver.CloseApp();
        }
    }
}
