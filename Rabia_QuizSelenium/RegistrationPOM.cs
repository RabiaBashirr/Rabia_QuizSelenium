using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Rabia_QuizSelenium
{
    public class RegistrationPOM
    {
        GenericMethods GM = new GenericMethods();
        By SignupLoginMenuItem = By.PartialLinkText("Signup");
        By SignUpText = By.XPath("//a[text()=' Signup / Login']");
        By SignUpHeading = By.XPath("//div/h2[text()='New User Signup!']");
        By UserName = By.Name("name");
        By SignupEmail = By.XPath("(//input[@name='email'])[2]");
        By SignupBtn = By.XPath("//button[text()='Signup']");
        By Gender = By.Id("id_gender2");
        By Password = By.Id("password");
        By Day = By.XPath("//select[@id='days']");
        By Month = By.XPath("//select[@id='months']");
        By Year = By.XPath("//select[@id='years']");
        By SignupNewsletter = By.Id("newsletter");
        By Offers = By.Id("optin");

        By FirstName = By.Id("first_name");
        By LastName = By.Id("last_name");
        By Company = By.Id("company");
        By Address1 = By.Id("address1");
        By Address2 = By.Id("address2");
        By Country = By.Id("country");        
        By State = By.Id("state");
        By City = By.Id("city");
        By ZipCode = By.Id("zipcode");
        By MobileNo = By.Id("mobile_number");
        By CreateAccountBtn = By.XPath("//button[text()='Create Account']");

        By ExistingUserError = By.XPath("//form/p[text()='Email Address already exist!']");
        

        public void NavigatetoSignup()
        {            
            GM.Element_Click(SignupLoginMenuItem);
        }

        public void VerifySignUpHeading()
        {
            IWebElement headingText = GM.LocateElement(SignUpHeading);            
            string s = headingText.Text;
//            Console.WriteLine(s);
            Assert.AreEqual("New User Signup!", s);
        }

        public void Signup(string name , string email)
        {            
            PopulateUsernamefield(name);
            PopulateEmailfield(email);
            SignupBtnClick();
        }
        public void PopulateUsernamefield(string name)
        {
            GM.SendInputData(UserName, name);            
        }
        public void PopulateEmailfield(string email)
        {
            GM.SendInputData(SignupEmail, email);
        }
        public void SignupBtnClick()
        {
            GM.Element_Click(SignupBtn);
        }

        // Sign up Account Info
        public void AccountInfo(string pwd, string day, string month, string year)
        {            
            GenderChecboxClick();
            PopulatePasswordfield(pwd);
            DateOfBirth(day, month, year);
            GM.ScrollToElement(SignupNewsletter);
            CheckNewsLetter();
            MarkOffersOption();            
        }

        public void GenderChecboxClick()
        {
            GM.Element_Click(Gender);
        }
        public void PopulatePasswordfield(string pwd)
        {
            GM.SendInputData(Password, pwd);
        }
        public void DateOfBirth(string day, string month, string year)
        {
            GM.SelectDropdpwnItem(Day, day);
            GM.SelectDropdpwnItem(Month, month);
            GM.SelectDropdpwnItem(Year, year);
        }
        public void CheckNewsLetter()
        {
            GM.Element_Click(SignupNewsletter);
        }
        public void MarkOffersOption()
        {
            GM.Element_Click(Offers);
        }

        public void FillAddressInfo(string fName, string lName, string company, string address, string address2, string country, string state, string city, string zip, string phoneNo)
        {
            PopulateFirstName(fName);
            PopulateLastName(lName);
            PopulateCompany(company);
            PopulateAddress(address);
            PopulateAddress2(address2);
            PopulateCountry(country);
            PopulateState(state);
            PopulateCity(city);
            PopulateZip(zip);
            PopulatePhoneNo(phoneNo);
            CreateAccount();
        }

        public void PopulateFirstName(string fName)
        {
            GM.SendInputData(FirstName, fName);
        }
        public void PopulateLastName(string lName)
        {
            GM.SendInputData(LastName, lName);
        }
        public void PopulateCompany(string company)
        {
            GM.SendInputData(Company, company);
        }
        public void PopulateAddress(string address)
        {
            GM.SendInputData(Address1, address);
        }
        public void PopulateAddress2(string address2)
        {
            GM.SendInputData(Address2, address2);
        }
        public void PopulateCountry(string country)
        {
            GM.SelectDropdpwnItem(Country, country);
        }
        public void PopulateState(string state)
        {
            GM.SendInputData(State, state);
        }
        public void PopulateCity(string city)
        {
            GM.SendInputData(City, city);
        }
        public void PopulateZip(string zip)
        {
            GM.SendInputData(ZipCode, zip);
        }
        public void PopulatePhoneNo(string phoneNo)
        {
            GM.SendInputData(MobileNo, phoneNo);
        }
        public void CreateAccount()
        {
            GM.Element_Click(CreateAccountBtn);
        }

        public void VerifyExistingUserErrorMessage(string ErrMsg)
        {
        //    IWebElement ExistingUserErrorElement = GM.LocateElement(ExistingUserError);
          //  string s = ExistingUserErrorElement.Text;
            //Assert.AreEqual(ErrMsg, ExistingUserError);
            GM.ElementTextAssertion(ErrMsg, ExistingUserError);
        }

        public void VerifySignUpLinkVisible()
        {
            GM.IsElementVisible(SignUpText);
            //GM.ElementTextAssertion("Signup / Login", SignUpText);
        }

        public void VerifySignUpLink(string text)
        {
            //GM.IsElementVisible(SignUpText);
            GM.ElementTextAssertion(text, SignUpText);
        }

    }
}
