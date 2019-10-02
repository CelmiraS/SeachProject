using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using Nest;
using System.Threading;

namespace InfiniteScroll_NUnitTestProject
{
    // class to interact and manipulate the HTML Page
    class InfiniteScrollClass
    {
        
        IJavaScriptExecutor js;

        //perform the scroll process
        public bool PerformScrollDownUp(IWebDriver driver)
        {

            IWebElement titleElement = driver.FindElement(By.CssSelector("#content > div > h3"));
            js = (IJavaScriptExecutor)driver;
            var initialOffset = (long)js.ExecuteScript("return window.pageYOffset;");

            Highlight(titleElement);
            Thread.Sleep(3000);
            Unhighlight(titleElement);
            Thread.Sleep(1000);
            // first scroll to bottom
            ScrollOnce(driver,titleElement);
            // second scroll to bottom
            ScrollTwice(driver);
            //Scroll to up and compare the positions (before start the scroll VS after scroll to ups)
            long finalOffset = ScrollToUp(driver);
            if (initialOffset == finalOffset)
              return true;
            return false;
        }

        public void ScrollOnce(IWebDriver driver, IWebElement titleElement)
        {

            js.ExecuteScript($"window.scrollTo({0}, {titleElement.Location.Y + 900 })");

            Thread.Sleep(3000);





        }

        public void ScrollTwice(IWebDriver driver)
        {

            IWebElement footerElement = driver.FindElement(By.CssSelector("#page-footer > div > div > a"));
            Highlight(footerElement);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", footerElement);
            Thread.Sleep(2000);
            Unhighlight(footerElement);

        }

        public long ScrollToUp(IWebDriver driver)
        {

            
            long finalOffset = -1;
            js.ExecuteScript($"window.scrollTo({0}, {0})");
            var finalOffsetTemp =(long)js.ExecuteScript("return window.pageYOffset;");
            finalOffset = finalOffsetTemp;

            Thread.Sleep(2000);

            return finalOffset;



        }

        public void Highlight(IWebElement titleElement)
        {
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", titleElement, "color: black; border: 4px solid red;");

        }

        public void Unhighlight(IWebElement element)
        {
            js.ExecuteScript("arguments[0].style.border='0px'", element);
        }

        
        public IWebElement GetTitleContent (IWebDriver driver)
        {
            IWebElement titleElement = null;
            titleElement = driver.FindElement(By.CssSelector("#content > div > h3"));
            
            return titleElement;

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
