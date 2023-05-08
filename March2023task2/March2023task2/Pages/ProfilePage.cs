using March2023task2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023task2.Pages
{
    public class ProfilePage:CommonDriver
    {
        private IWebElement shareskillbtn => driver.FindElement(By.XPath("//*[@class=\"ui basic green button\"]"));
        private IWebElement managelistingbtn => driver.FindElement(By.XPath("//*[@class=\"ui eight item menu\"]/a[3]"));

        public void ShareSkillButton()
        {
            Wait.WaitToBeClickable("XPath", 2, "//*[@class=\"ui basic green button\"]");
            shareskillbtn.Click();
        }

        public void ManageListing()
        {
            Wait.WaitToBeClickable("XPath", 5, "//*[@class=\"ui eight item menu\"]/a[3]");
            managelistingbtn.Click();
        }

    }
}
