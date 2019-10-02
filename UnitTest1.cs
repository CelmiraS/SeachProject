using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace InfiniteScroll_NUnitTestProject
{

    //class of the testcase described on the document
    public class Tests
    {
        IWebDriver driver;


        //method that run before each testcase (to alow open the browser)
        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/infinite_scroll");

        }

        //Scenario to simulate scroll down twice and then scroll up and check that  the page title have correct info. and correct offset
        [Test(), Order(1)]

        public void IsPerformedScrollProcess()
        {
            string titleContent = "";
            InfiniteScrollClass infiniteScroll = new InfiniteScrollClass();
            //Perfom scroll down and then up
            bool performedScroll = infiniteScroll.PerformScrollDownUp(driver);
            // Get the element that have the page title content
            IWebElement elementObtained = infiniteScroll.GetTitleContent(driver);
             if (elementObtained != null)
                titleContent = elementObtained.Text.ToString();
             
            Assert.IsTrue(performedScroll && (elementObtained.Displayed) &&(titleContent.Contains("Infinite Scroll")));
        }
    }
}