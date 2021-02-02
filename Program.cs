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
        static void Main(string[] args) {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";
            //Console.WriteLine("Hello World!");
        }
    }
}
