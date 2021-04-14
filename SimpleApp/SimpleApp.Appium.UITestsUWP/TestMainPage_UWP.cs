using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;

namespace SimpleApp.Appium.UITestsUWP
{
    [TestFixture]
    public class TestMainPage_UWP: TestMainPage<WindowsDriver<WindowsElement>, WindowsElement>
    {
        public TestMainPage_UWP() : base("MainPageTests") {}

        protected override WindowsDriver<WindowsElement> GetDriver()
        {
           return new WindowsDriver<WindowsElement>(driverUri, appiumOptions);
        }

        protected override void InitAppiumOptions(AppiumOptions appiumOptions)
        {
            private const string packageNmae = "SimpleApp.UWP";
            protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

            protected WindowsDriver<WindowsElement> App;
            protected WindowsDriver<WindowsElement> DesktopSession;

            var appCapabilities = new DesiredCapabilities();

            App = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            appCapabilities.SetCapability("app", packageName);

            

            // appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "pixel_2_pie_9_0_-_api_28");
            // appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus_5_API_24");
            // appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            // appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            // appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.simpleapp");
            // appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc64d6c8ffab200b6dd1.MainActivity");
            // appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "md57f24161a4fad3f027b401a142d1bd9c4.MainActivity");
        }
    }
}