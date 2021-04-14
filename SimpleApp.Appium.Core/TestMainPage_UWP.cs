using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;


namespace SimpleApp.Appium.Core
{
    [TestFixture]
    public class TestMainPage_UWP : TestMainPage<WindowsDriver<WindowsElement>, WindowsElement>
    {
        public TestMainPage_UWP() : base("MainPageTests") {}

        protected override WindowsDriver<WindowsElement> GetDriver()
        {
            return new WindowsDriver<WindowsElement>(driverUri, appiumOptions);
        }

        protected override void InitAppiumOptions(AppiumOptions appiumOptions)
        {
            appiumOptions.AddAdditionalCapability("app", "8a9ae5b0-b586-4d14-afb8-03d7b022fda2_atyx71xy9s7q0!App");
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");

        }
    }
}
