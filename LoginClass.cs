using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using Nest;

namespace LoginV2_NUnitTestProject
{
    // login class that interact with elements of the login page
    class LoginClass
    {

        // fill the username field
        public void FillUsername(IWebDriver driver , string username )
        {
            driver.FindElement(By.Id("username")).SendKeys(username);
        }

        // fill the password field
        public void FillPassword(IWebDriver driver, string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        // method to click on login button
        public void SubmitCredentials(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("#login > button > i")).Click();
        }

        // method to click on logout button
        public void Logout (IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("#content > div > a")).Click();
        }

        // method to obtain the message generated
        public string  GetMessage (IWebDriver driver)
        {
            IWebElement messageField = driver.FindElement(By.Id("flash-messages"));
            string messageContent = messageField.Text.ToString();
            return messageContent;
        }


        //implicit wait method
        public void Wait(IWebDriver driver, int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }

        // method to close the browser
        public void CloseDriver(IWebDriver driver)
        {
            Wait(driver, 9000);
            driver.Close();
        }
    }
}
