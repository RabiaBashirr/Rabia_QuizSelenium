using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;

namespace Rabia_QuizSelenium
{
    [TestClass]
    public class Base
    {
        GenericMethods GM = new GenericMethods();
        RegistrationPOM RP = new RegistrationPOM();
        LoginUserPOM LP = new LoginUserPOM();
        ScrollPOM SP = new ScrollPOM();

//        IWebDriver driver = GenericMethods.SeleniumBrowserInit("Chrome");

        string url = "https://automationexercise.com";


        /* ************************** 
         *      TEST CASE - 01
         * Registration Test Case 
         * ************************ */


        [TestMethod]
        public void RegisterUser()
        {
            IWebDriver driver = GenericMethods.SeleniumBrowserInit("Chrome");
            GenericMethods.Navigation(url);

            //string url = "https://automationexercise.com/test_cases";
            //driver.FindElement(By.PartialLinkText("Register")).Click();

            RP.NavigatetoSignup();
            RP.VerifySignUpHeading();
            RP.Signup("Rabia", "rabiaa.bashirr.2020@gmail.com");

            GM.IsPageReady(driver);
            RP.AccountInfo("Rabia-Quiz", "1", "August", "1991");
            RP.FillAddressInfo("Rabia", "Bashir", "Contour-Software", "Mughalpura", "Shalimar Link Road", "India", "Punjab", "Lahore", "54000", "03366656022");
        }

        [TestMethod]
        public void LoginUser()
        {
            IWebDriver driver = GenericMethods.SeleniumBrowserInit("Chrome");
            GenericMethods.Navigation(url);
            LP.NavigatetoSignin();
            LP.loginUser("rabia.bashir@live.co.uk", "Rabia-Quiz");
        }


        /* *********************************
         *      TEST CASE - 02
         * Register User with existing email
        ********************************** */

        [TestMethod]
        public void RegisterWithExistingEmail()
        {
            // Launch browser
            IWebDriver driver = GenericMethods.SeleniumBrowserInit("Chrome");

            // Navigate to URL 
            GenericMethods.Navigation(url);

            // Verify that home page is visible successfully    
            GM.IsPageReady(driver);

            // Verify 'New User Signup!' is visible
            RP.VerifySignUpLinkVisible();

            //Verify Text of the sign up Link
            RP.VerifySignUpLink("Signup / Login");

            // Verify 'New User Signup!' is visible
            RP.NavigatetoSignup();

            // Enter name and already registered email address and Click Signup
            RP.Signup("Rabia", "rabia.bashir@live.co.uk");

            // Verify error 'Email Address already exist!' is visible
            RP.VerifyExistingUserErrorMessage("Email Address already exist!");
        }



        /* ****************************************
         *      TEST CASE - 02
         * Verify Scroll Up without 'Arrow' button 
         * and Scroll Down functionality
        ***************************************** */

        [TestMethod]
        public void Scrolling()
        {
            // Launch browser
            IWebDriver driver = GenericMethods.SeleniumBrowserInit("Chrome");

            // Navigate to URL
            GenericMethods.Navigation(url);

            // Verify that home page is visible successfully
            GM.IsPageReady(driver);

            // Scroll down page to bottom
            SP.ScrollDown();

            // Verify 'SUBSCRIPTION' is visible

            try
            {
                bool e = SP.SubscriptionVisibility();                                
            }
            catch { 
                Screenshot DemoForms = ((ITakesScreenshot)driver).GetScreenshot();
                DemoForms.SaveAsFile("D:\\ContourSoftwareAutomation\\Subscription\\QuizScreenshot.png", ScreenshotImageFormat.Png);
                
            // Scroll up page to top
                SP.ScrollTop();
            }     

            // Verify that page is scrolled up and 'Full-Fledged practice website for Automation Engineers' text is visible on screen


        }


    }
}

