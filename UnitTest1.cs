using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace KeyPresses_NUnitTestProject
{
    public class Tests
    {

        IWebDriver driver;
        KeyPressesClass keyClass;

        //method that run before each testcase (to alow open the browser)
        [OneTimeSetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/key_presses");
    

        }

        // Simulate when the user fill the key and according the keyboard dictionary return True, if in all iterations the keys submeted and expected are the same
        [Test(), Order(1)]
        public void isSameKey()
        {
            keyClass = new KeyPressesClass();

            //Repeat the request  4 times
            int round = 0;
            bool isAlwaysSameKey = true;
            while (round<5)
            {
                round = round + 1;

                bool isvalid = keyClass.CompareKeys(driver);
                Thread.Sleep(2000);
                if (isvalid.Equals(false))
                    isAlwaysSameKey = false;
            
            }
            Assert.IsTrue(isAlwaysSameKey);

            driver.Close();
        }

      
    }
}