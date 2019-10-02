using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;
using System.Linq;
using System.Data.SqlTypes;

namespace KeyPresses_NUnitTestProject
{
    public class KeyPressesClass
    {

        InputSimulator sim = new InputSimulator();
       

        // Compare the keys
        public bool CompareKeys(IWebDriver driver )
        {

            bool equal = false;
            var randomKey = RandomKey<VirtualKeyCode>();
            string key = (randomKey).ToString();
            
            //represent thestring that should be showed according with the dictionary method
            string keyToSend=  GetKeydictionary(key);
            // if the key of dictionary  method have value , its should be compared with what was displayed
            if (keyToSend != "")
            {
                Sendkey(driver, keyToSend);
                Wait(driver,2000);
                string keyDisplayed = GetKeyDisplayed(driver);
                if (keyToSend == keyDisplayed)
                    return true;
                
                else
                    return false;

            }
            
            else if (GetKeyDisplayed(driver)== "SPACE")
            {
                Sendkey(driver, " ");
                return true;
            }

            //if the dictionary method dont return a value , the random string should be showed in order to allow future improvements
            string fKey = ""+key+ "";
            Sendkey(driver, fKey);
            return false;
            


            



        }

        // fill the key that was generated randomly
        public void Sendkey(IWebDriver driver, string keyValue)
        {
            //key.GetHashCode();

            driver.FindElement(By.Id("target")).SendKeys(keyValue);
            
        }

        // randon keys generator
        public T RandomKey<T>()
        {

            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));

        }

        //method that represent the key displaed  when the user press a key
        public string  GetKeyDisplayed (IWebDriver driver)
        {
            string result = "";

             IWebElement output =  driver.FindElement(By.Id("result"));
             result =  output.Text.ToString().Trim();
            if (result!= "")
             result= result.Substring(13);
            return result;


        }


        // represent the keyboard dictionaty
   
        public string GetKeydictionary(string key)
      {


            String subKey = key.Substring(0, 3);
            String subKey2 = key.Remove(0);

            if (subKey== "VK_" && key.Length==4)
            {
                subKey = key.Substring(3).ToUpper();
                return subKey;
            }


            else if ((subKey2 == "F" && key.Length == 2) || (subKey2 == "F" && key.Length == 3))
            {
                
                return subKey;
            }


            else
            {

                switch(key)
                {
                


                    case "MULTIPLY":
                 

                    return "";


                    case "ADD":
                    
                        return "";

                    
                    case "SUBTRACT":
                    return "";

                    case "DIVIDE":
                   
                    return "";

                    case "OEM_COMMA":
                    return ",";


                    case "OEM_PERIOD":
                        return ".";


                    case "OEM_MINUS":
                        return "-";



                    case "OPEN_BRACKET":
                    case "OEM_7":
                        return "'";



                    case "SPACE":
                       return " ";

                    
        

                    default:
                    return "";
                }

            }

        }

        



        //implicit wait method
        public void Wait(IWebDriver driver, int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }

 
    }
}
