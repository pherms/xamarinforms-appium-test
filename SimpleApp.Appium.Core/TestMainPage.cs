using System;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

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
            // appiumDriver.CloseApp();
            appiumDriver.LaunchApp();
        }

        [Test()]
        public void TestLogin()
        {
            GetElementByName("Login");

            // By XPath:
            // appiumDriver.FindElement(By.XPath("//*[@content-desc='UserName']")).SendKeys("user@email.com");
            // Or by AccessibilityID (AutomationID property in the XAML file
            if (IsUwp)
            {
                appiumDriver.FindElementByAccessibilityId("UserName").SendKeys("user@email.com");
                appiumDriver.FindElementByAccessibilityId("Password").SendKeys("password");
            }
            else
            {
                GetElementByName("UserName").SendKeys("user@email.com");
                GetElementByName("Password").SendKeys("password");
            }
  
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
            GetElementByName("Browse").Click();

            // appiumDriver.FindElement(By.Id("AddToolbarItem")).Click();
            // appiumDriver.FindElement(By.XPath("//*[@content-desc='AddToolbarItem']")).Click();
            if (IsUwp)
            {
                appiumDriver.FindElementByAccessibilityId("MoreButton").Click();
            }
            else
            {
                GetElementByName("AddToolbarItem").Click();
            }
   
            // var itemNameField = appiumDriver.FindElement(By.Id("ItemNameEntry"));
            var itemNameField = appiumDriver.FindElementByAccessibilityId("ItemNameEntry");
            itemNameField.SendKeys("todo");

            // var itemDesriptionField = appiumDriver.FindElement(By.Id("ItemDescriptionEntry"));
            var itemDesriptionField = appiumDriver.FindElementByAccessibilityId("ItemDescriptionEntry");
            itemDesriptionField.SendKeys("todo description");
            
            // appiumDriver.FindElement(By.Id("SaveToolbarItem")).Click();
            GetElementByName("SaveToolbarItem").Click();
        }

        [Test()]
        public void TestAbout()
        {
            // appiumDriver.FindElement(By.XPath("//*[@content-desc='About']")).Click();
            // if (IsUwp)
            // {
            //     appiumDriver.FindElementByName("About").Click();
            // } else
            // {
            //     appiumDriver.FindElementByAccessibilityId("About").Click();
            // }
            GetElementByName("About").Click();
        }

        [TearDown()]
        public void TestCleanup()
        {
            appiumDriver.CloseApp();
        }

        private W GetElementByName(string elementName)
        {            
            switch (Platform)
            {
                case "iOS":
                    return appiumDriver.FindElementByAccessibilityId(elementName);
                case "Android":
                    return appiumDriver.FindElementByAccessibilityId(elementName);
                case "Windows":
                    return appiumDriver.FindElementByName(elementName);
                default:
                    return default(W);
            }
        }
    }
}
