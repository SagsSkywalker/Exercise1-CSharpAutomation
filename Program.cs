using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

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
        #region Interactive Methods
        public void Click(IWebElement element) {
            element.Click();
        }
        public void SendText(IWebElement element, string value) {
            element.SendKeys(value);
        }
        #endregion
        #region WebElements
        By FacebookText = By.XPath("//h2[contains(text(),'Connect with friends and the world around you on F')]");
        By CreateAccountFB = By.XPath("//a[@id='u_0_2']");
        By FirstName = By.XPath("//input[@name='firstname']");
        By LastName = By.XPath("//input[@name='lastname']");
        By Number = By.XPath("//input[@name='reg_email__']");
        By Password = By.XPath("//input[@name='reg_passwd__']");
        By PasswordFake = By.XPath("//input[@name='reg_passwdasdasd__']");
        By TermsLink = By.XPath("//a[@id='terms-link']");
        By TosTitle = By.XPath("//h2[contains(text(),'Terms of Service')]");
        By MenuFather = By.XPath("//div[@id='u_0_c']");
        By Menu1 = By.XPath("//div._1-qq[role='presentation']");
        By Menu2 = By.XPath("//div._1-qr[role='presentation']");
        By Menu3 = By.XPath("//div._1-qt[role='presentation']");
        By Menu4 = By.XPath("//div._1-qu[role='presentation']");
        By Menu5 = By.XPath("//div._1-r8[role='presentation']");
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
            program.Click(Browser.FindElement(program.CreateAccountFB));
            program.SendText(Browser.FindElement(program.FirstName), "TestName");
            program.SendText(Browser.FindElement(program.LastName), "TestLastName");
            program.SendText(Browser.FindElement(program.Number), "4771234567");
            program.SendText(Browser.FindElement(program.Password), "Password01!");

            //Do the following
            //In the first test case:
            //Declare an element that does not exist.
            //Use exception handler to catch the exception and display a customized message for elements that do not exist.
            try {
                Assert.IsTrue(Browser.FindElement(program.PasswordFake) != null);
            }
            catch (Exception e) {
                Console.WriteLine("This element maybe doesn't exist, here are some details \n" + e.Message);
            }

            //2nd Test Case
            //Click on Terms of Services
            //Validate following title exists
            //Terms of Service
            //Validate that following elements exist: Menu from 1 to 5
            program.Click(Browser.FindElement(program.TermsLink));
            Assert.IsTrue(program.TosTitle != null);
            Assert.IsTrue(program.MenuFather != null);
            Assert.IsTrue(program.Menu1 != null);
            Assert.IsTrue(program.Menu2 != null);
            Assert.IsTrue(program.Menu3 != null);
            Assert.IsTrue(program.Menu4 != null);
            Assert.IsTrue(program.Menu5 != null);

            //In the second test case:
            //Create a list and print the text of the following elements
            //Facebook Ads Controls
            //Privacy Basics
            //Cookies Policy
            //Data Policy
            //More Resources > View a Printable version of the ToS
            IList<IWebElement> selectElements = Browser.FindElements(By.CssSelector("i ~ div"));
            foreach (var item in selectElements) {
                Console.WriteLine(item.Text);
            }
        }
    }
}
