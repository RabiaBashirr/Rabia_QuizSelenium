using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabia_QuizSelenium
{
    
    public class ScrollPOM
    {
        By Subscription = By.XPath("//div[text()='Subscription']");
        By heading = By.XPath("//div/span/[text()='Automation'");


        GenericMethods GM = new GenericMethods();

        public void ScrollDown()
        {
            GM.ScrolltoBottom();
            
        }

        public bool SubscriptionVisibility()
        {            
            return GM.IsElementVisible(Subscription);            
        }

        public void ScrollTop()
        {
            GM.ScrollToTop();
        }

        public void subscriptionScroll()
        {
            GM.ScrollToElement(Subscription);
        }

        /*
        public void heading()
        {
            
        }

        */



    }
}
