using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SimpleApp.Appium.UITests.AppiumExtensions
{
    public static class AppiumExtensions
    {
        public static W GetElementByName<W>(this AppiumDriver<W> webElement, string elementName) where W : IWebElement
        {
            var devicePlatform = DeviceInfo.Platform.ToString();
            switch (devicePlatform)
            {
                case "iOS":
                    return webElement.FindElementByAccessibilityId(elementName);
                case "Android":
                    return webElement.FindElementByAccessibilityId(elementName);
                case "UWP":
                    return webElement.FindElementByName(elementName);
                default:
                    return default(W);
            }
        }
    }
}
