using March2023task2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023task2.Pages
{
    public class LoginPage:CommonDriver
    {
        

        private IWebElement signinbtn => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement idtextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement passtxtbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));

        private IWebElement loginbtn => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        private IWebElement profileName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]"));


        public void SignInFunction(string emailAddress,
                               string loginPassword)
        {
            Thread.Sleep(1000);
            signinbtn.Click();
            //email.Click();
            idtextbox.SendKeys(emailAddress);
            //passowrd.Click();
            passtxtbox.SendKeys(loginPassword);
            loginbtn.Click();
            Thread.Sleep(5000);
            Assert.That(profileName.Text == "zeel pate1", "Login name and username match unsuccessful");
        }



    }
    }

