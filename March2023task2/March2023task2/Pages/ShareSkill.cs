using March2023task2.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using AutoIt;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using AventStack.ExtentReports.Utils;
using Microsoft.CodeAnalysis.Text;

namespace March2023task2.Pages
{
    public class ShareSkill:CommonDriver
    {
        private IWebElement titletextbox => driver.FindElement(By.Name("title"));
        private IWebElement descritiontxtbox => driver.FindElement(By.Name("description"));
        private IWebElement categorydropdown => driver.FindElement(By.XPath("//*[@name=\"categoryId\"]"));
        private IWebElement subcatdropdown => driver.FindElement(By.Name("subcategoryId"));

        private IWebElement tagtextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

        private IWebElement servicetypeRB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));

        private IWebElement locationtypeRB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        private IWebElement dayCB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
        //*[@id="service-listing-section"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input
        //*[@id="service-listing-section"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input
        private IWebElement enddate => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
        private IWebElement skilltradeRB => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @tabindex=\"0\" and @value=\"true\"]"));
        private IWebElement skillexchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        private IWebElement worksample => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        private IWebElement activeHidenRB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        private IWebElement cancelButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[2]"));
        

        public void Title()
        {
            //Title
            Wait.WaitToBeClickable("Name", 2, "title");
            titletextbox.SendKeys("QA");

        }
        public void Description()
        {
            //Description
            Wait.WaitToBeClickable("Name", 2, "description");
            descritiontxtbox.SendKeys("Software Testing");
        }
        public void Category()
        {
            //Category
            SelectElement categorySelect = new SelectElement(categorydropdown);
            categorySelect.SelectByValue("6");
        }
        public void SubCatagory()
        {
            //Subcategory
            Wait.WaitToBeClickable("Name", 5, "subcategoryId");
            SelectElement subcategory = new SelectElement(subcatdropdown);
            subcategory.SelectByValue("4");
        }
        public void Tags()
        {
            //Tags
            Wait.WaitToBeClickable("XPath", 2, "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input");
            tagtextbox.SendKeys("Learner" + "\n");
        }
        public void ServiceTypeRB()
        {
            // hourly basis Service Type Radio Button
            servicetypeRB.Click();
        }
        public void LocationTypeRB()
        {
            //Location Type
             locationtypeRB.Click();
        }
        public void Days()
        {
            dayCB.Click();
            dayCB.SendKeys("10/05/2023");
        }
        public void Enddate()
        {
            enddate.Click();
            enddate.SendKeys("15/05/2023");
        }
        public void skilltradeaction()
        {
            skilltradeRB.Click();
        }
        public void skillexchangeaction()
        {
            skillexchange.SendKeys("Reader" + "\n");
            skillexchange.SendKeys("Writer" + "\n");
            skillexchange.SendKeys("expert" + "\n");

        }
       public void worksamples()
        {
            //Work Samples
            // Identify the Work Samples and click the plus button to upload photo
            //  Max file size is 2 MB and supported file types are gif / jpeg / png / jpg / doc(x) / pdf / txt / xls(x
            Thread.Sleep(3000);
             worksample.Click();
            Thread.Sleep(500);
             AutoItX3 autoIt = new AutoItX3();
            Thread.Sleep(500);
            autoIt.WinActivate("Open");
            Thread.Sleep(500);
            autoIt.Send(@"C:\Users\jeelp\Downloads\download.jpg");
            Thread.Sleep(500);
            autoIt.Send("{ENTER}");
            Thread.Sleep(500);
        }

        public void activeaction()
        {
            activeHidenRB.Click();
        }
        public void saveaction()
        {
            saveButton.Click();
        }
    }
}
