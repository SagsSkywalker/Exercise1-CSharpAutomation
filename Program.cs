using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Exercise1_CSharpAutomation
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver() {
            driver = new ChromeDriver(@"C:\Webdrivers\");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element) {
            element.Click();
        }

        public void SendText(IWebElement element, string value) {
            element.SendKeys(value);
        }
        #region WebElements
        By FacebookText = By.XPath("//h2[contains(text(),'Connect with friends and the world around you on F')]");
        #endregion
        static void Main(string[] args) {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            //1st Test Case
            //Go to facebook.com.
            Browser.Url = "https://www.facebook.com";
            //Verify following text is displayed:
            //Connect with friends and the world around you on Facebook.
            Assert.IsTrue(program.FacebookText != null);
            //Click on Create a new account
            //Fill Firstname, Lastname, Mobile Number and New Password

            //2nd Test Case
            //Click on Terms of Services
            //Validate following title exists
            //Terms of Service
            //Validate that following elements exist: Menu from 1 to 5

            //Do the following
            //In the first test case:
            //Declare an element that does not exist.
            //Use exception handler to catch the exception and display a customized message for elements that do not exist.

            //In the second test case:
            //Create a list and print the text of the following elements
            //Facebook Ads Controls
            //Privacy Basics
            //Cookies Policy
            //Data Policy
            //More Resources > View a Printable version of the ToS
        }
    }
}
