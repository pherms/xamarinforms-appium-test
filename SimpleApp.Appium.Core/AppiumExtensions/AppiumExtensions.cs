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
        public static W GetElementByName<W>(this AppiumDriver<W> webElement, string elementName, AppiumOptions options) where W : IWebElement
        {            
            switch (options.PlatformName)
            {
                case "iOS":
                    return webElement.FindElementByAccessibilityId(elementName);
                case "Android":
                    return webElement.FindElementByAccessibilityId(elementName);
                case "Windows":
                    return webElement.FindElementByName(elementName);
                default:
                    return default(W);
            }
        }
    }
}
