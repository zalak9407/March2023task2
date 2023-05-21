using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using March2023task2.Utilities.Reports;
using NUnit.Framework.Interfaces;
using System.ComponentModel;

namespace March2023task2.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        
        protected Broswer Broswer;
       
        [SetUp]

        
        public void StartWebsite()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");

            Broswer = new Broswer(driver);
        }


        [TearDown]
        public void CloseBrowser()
        {
            EndTest();
            ExtentReporting.EndReporting();
            driver.Quit();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogScreenShot("Ending test", Broswer.GetScreenShot());
        }
    }

}

