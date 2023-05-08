using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace March2023task2.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        [SetUp]
        public void Loginstep()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //turnup portal
            driver.Navigate().GoToUrl("http://localhost:5000/");


        }

    }
}
