using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Rabia_QuizSelenium
{
    [TestClass]
    public class Base
    {
        GenericMethods GM = new GenericMethods();
        RegistrationPOM RP = new RegistrationPOM();
        LoginUserPOM LP = new LoginUserPOM();

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

            //  SignupHeading.GetAttribute("New User Signup!");
            //   driver.FindElement().SendKeys("");
            //    Console.WriteLine("SignupHeading: " + s);eady(driver));
            
            //    Assert.AreEqual(true, GM.IsPageR
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
            RP.VerifySignUpLink("Signup / Login");

            // Verify 'New User Signup!' is visible
            RP.NavigatetoSignup();

            // Enter name and already registered email address and Click Signup
            RP.Signup("Rabia", "rabia.bashir@live.co.uk");

            // Verify error 'Email Address already exist!' is visible
            RP.VerifyExistingUserErrorMessage("Email Address already exist!");
        }
    }
}

