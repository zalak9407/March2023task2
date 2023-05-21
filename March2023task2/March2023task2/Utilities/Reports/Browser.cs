using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;



namespace March2023task2.Utilities.Reports
{
    public class Broswer
    {
        private IWebDriver driver;

        public Broswer(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetScreenShot()
        {
            Thread.Sleep(200);
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;

            return img;
        }
    }
}

