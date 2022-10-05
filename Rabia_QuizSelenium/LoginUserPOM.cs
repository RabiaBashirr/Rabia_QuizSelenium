using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabia_QuizSelenium
{
    public class LoginUserPOM
    {
        GenericMethods GM = new GenericMethods();

        By MenuItem = By.PartialLinkText("Signup");
        By Email = By.XPath("//input[@name='email']");
        By Password = By.Name("password");
        By LoginBtn = By.XPath("//button[text()='Login']");

        public void NavigatetoSignin()
        {
            GM.Element_Click(MenuItem);
        }

        public void loginUser(string email, string pwd)
        {                             
            PopulateEmailfield(email);
            PopulatePasswordfield(pwd);
            LoginBtnClick();            
        }
        public void PopulateEmailfield(string email)
        {
            GM.SendInputData(Email, email);
        }
        public void PopulatePasswordfield(string pwd)
        {
            GM.SendInputData(Password, pwd);
        }
        public void LoginBtnClick()
        {
            GM.Element_Click(LoginBtn);
        }

    }
}
