using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace Rabia_QuizSelenium
{
    public class GenericMethods
    {
        public static IWebDriver driver;

        public static IWebDriver SeleniumBrowserInit(String browserName)
        {
            if (browserName != null)
            {
                if (browserName == "Chrome")
                {
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                }

                else if (browserName == "MsEdge")
                    driver = new EdgeDriver();
            }
            return driver;
        }

        public static void Navigation(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void IsPageReady(IWebDriver driver)
        {
            try
            {
                bool PageReady = ((IJavaScriptExecutor)driver)
                 .ExecuteScript("return document.readyState")
                 .Equals("complete");
                Assert.IsTrue(PageReady);
            }
            catch
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            }
        }

        /* ******** Locator Methods (locate, SendKeys, Click) ******* */
        #region Locators

        // FindElement(locator) method
        public IWebElement LocateElement(By path)
        {
            return driver.FindElement(path);
        }

        // Send data to locators
        public void SendInputData(By path, string input)
        {
            IWebElement element = LocateElement(path);
            element.SendKeys(input);
        }

        // Click to element
        public void Element_Click(By locator)
        {
            LocateElement(locator).Click();
        }
        #endregion

        public void ImplicitWaits(int timespan)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timespan);
        }

        // Select item from Dropdown
        public void SelectDropdpwnItem(By locator, string text )
        {
            var element = LocateElement(locator);         
            var SelectElementitem = new SelectElement(element);
            SelectElementitem.SelectByText(text);
        }

        public void RemoveBanner(By locator)
        {
            IWebElement ad = LocateElement(locator);            
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].remove();", ad);
        }

        public void ScrollToElement(By locator)
        {
            IWebElement e = LocateElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", e);
        }

        public bool IsElementVisible(By locator)
        {
            if (driver.FindElement(locator)
               .Displayed || driver.FindElement(locator).Enabled)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }


        public void ElementTextAssertion(string Expected, By  locator)
        {
            string Actual = GetAttributeByText(locator);
            Assert.AreEqual(Expected, Actual);
        }
        public string GetAttributeByText(By locator)
        {
            string text = null;
            try
            {
                text = LocateElement(locator).Text;
            }
            catch
            {
                try
                {
                    text = LocateElement(locator).GetAttribute("value");
                }
                catch
                {
                    LocateElement(locator).GetAttribute("innerHTML");
                }
            }
            return text;
        }


        public void ScrolltoBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
           // js.ExecuteScript("window.scrollTo(0, document." + "Body" + ".scrollHeight);");
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight || document.documentElement.scrollHeight);");
        }


        public void ScrollToTop()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document." + "head" + ".scrollHeight);");
        }

        public void CloseBrowser()
        {
            driver.Close();
        }


    }
}
