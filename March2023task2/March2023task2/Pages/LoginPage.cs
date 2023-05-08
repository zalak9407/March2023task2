using March2023task2.Utilities;
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
       
       
            
            public void SignInButton()
            {
                signinbtn.Click();


            }
            public void Email()
            {

                idtextbox.Click();
                idtextbox.SendKeys("jeelpatel508@gmail.com");

            }
            public void Password()
            {

                passtxtbox.Click();
                passtxtbox.SendKeys("Zalak9407");

            }
            public void Login()
            {
            loginbtn.Click();
            }
           

           
        }
    }

