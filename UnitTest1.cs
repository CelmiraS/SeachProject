using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace LoginV2_NUnitTestProject
{
    //class of the testcases described on the document
    // Each testcase represents scenario
    public class Tests
    {
        IWebDriver driver;
        string username = "tomsmith";
        string password = "SuperSecretPassword!";

        //method that run before each testcase (to alow open the browser)
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
        }

        // Possible scenario to generate a submition of credentials with a invalid username
        [Test(), Order(1)]
        public void IsincorrectUsername()
        {
            string incorrectUsername = username.ToUpper();
            string messageObtained = "";

            LoginClass loginClass = new LoginClass();
            loginClass.FillUsername(driver, incorrectUsername);
            loginClass.FillPassword(driver, password);
            loginClass.Wait(driver, 3000);
            loginClass.SubmitCredentials(driver);
            Thread.Sleep(2000);
            messageObtained = loginClass.GetMessage(driver);
            Assert.IsTrue((messageObtained.Contains("Your username is invalid!")));
            loginClass.CloseDriver(driver);
         }

        // Possible scenario to generate a submition of credentials with a invalid password

        [Test(), Order(2)]
        public void IsincorrectPassword()
        {
            string incorrectPassword = password.ToLower();
            string messageObtained = "";

            LoginClass loginClass = new LoginClass();
            loginClass.FillUsername(driver,username );
            loginClass.FillPassword(driver, incorrectPassword);
            loginClass.Wait(driver, 3000);
            loginClass.SubmitCredentials(driver);
            Thread.Sleep(2000);
            messageObtained = loginClass.GetMessage(driver);
            Assert.IsTrue((messageObtained.Contains("Your password is invalid!")));
            loginClass.CloseDriver(driver);
        }


        // Scenario to generate a submition of valid credentials and then a logout process

       [Test(), Order(3)]
        public void IsexecutedLoginAndLogout()
        {
            
            string messageObtained = "";
            string messageObtained2 = "";

            LoginClass loginClass = new LoginClass();
            loginClass.FillUsername(driver, username);
            loginClass.FillPassword(driver, password);
            loginClass.Wait(driver, 3000);
            loginClass.SubmitCredentials(driver);
            Thread.Sleep(2000);
            messageObtained = loginClass.GetMessage(driver);
            Thread.Sleep(5000);
            loginClass.Logout(driver);
            loginClass.Wait(driver,2000);
            messageObtained2 = loginClass.GetMessage(driver);
            Thread.Sleep(2000);
            Assert.IsTrue((messageObtained.Contains("You logged into a secure area!")) && messageObtained2.Contains("You logged out of the secure area!"));


            loginClass.CloseDriver(driver);
        }



    }
}
