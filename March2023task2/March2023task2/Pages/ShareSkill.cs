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
using SeleniumExtras;
using MongoDB.Driver;
using Microsoft.Office.Interop.Excel;

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
        private IWebElement servicetypeonoff => driver.FindElement(By.XPath("//*[@name=\"serviceType\" and @tabindex=\"0\" and @value=\"1\"]"));
        private IWebElement locationtypeonsiteRB => driver.FindElement(By.XPath("//*[@name=\"locationType\" and @tabindex=\"0\" and @value=\"0\"]"));
        private IWebElement locationtypeonlineRB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
        private IWebElement dayCB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
        private IWebElement enddate => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
        private IWebElement skilltradeRB => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @tabindex=\"0\" and @value=\"true\"]"));
        private IWebElement skillexchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        private IWebElement worksample => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        private IWebElement cancelButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[2]"));
        private IWebElement titleQA => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
        private IWebElement descriptioncheck => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        private IWebElement categorycheck => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
        private IWebElement servicecheck => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[5]"));
        private IWebElement skillCreditRb => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @tabindex=\"0\" and @value=\"false\"]"));
        private IWebElement creditPerHour => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/input"));
        private IWebElement isActive => driver.FindElement(By.XPath("//*[@name=\"isActive\" and @tabindex=\"0\" and @value=\"true\"]"));
        private IWebElement isHidden => driver.FindElement(By.XPath("//*[@name=\"isActive\" and @tabindex=\"0\" and @value=\"false\"]"));

        public void ShareskillAdd(string EnterTitle,
                                  string EnterDescription,
                                  string EnterCategory,
                                  string EnterSubCategory,
                                  string EnterTag,
                                  string ServiceType,
                                  string LocationType,
                                  string SsStartDate,
                                  string SsEndDate,
                                  string EnterSkillTrade,
                                  string EnterSkillExchange,
                                  string SsCredit,
                                  string EnterWorkSamplesLink,
                                  string Active)
        {
            Thread.Sleep(300);
            //Title
            Wait.WaitToBeClickable("Name", 10, "title");
            titletextbox.SendKeys(EnterTitle);
            Thread.Sleep(300);

            //Description
            Wait.WaitToBeClickable("Name", 10, "description");
            descritiontxtbox.SendKeys(EnterDescription);
            Thread.Sleep(300);

            //Category
            SelectElement categorySelect = new SelectElement(categorydropdown);
            categorySelect.SelectByValue(EnterCategory);
            Thread.Sleep(300);

            //Sub Category
            Wait.WaitToBeClickable("Name", 10, "categoryId");
            SelectElement subCategorySelect = new SelectElement(subcatdropdown);
            subCategorySelect.SelectByValue(EnterSubCategory);
            Thread.Sleep(300);

            //Tags
            Wait.WaitToBeClickable("XPath", 10, "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input");
            tagtextbox.SendKeys(EnterTag + "\n");
            Thread.Sleep(300);
            
            if (ServiceType == "Hourly")
            {
                // hourly basis Service Type Radio Button
                servicetypeRB.Click();
            }
            else
            {
                servicetypeonoff.Click();
            }
            //Location Type online
            //locationtypeonlineRB.Click();
            if (LocationType == "Online")
            {
                //locationtypeonsiteRB.Click();
                locationtypeonlineRB.Click();
            }
            else
            {
                locationtypeonsiteRB.Click();
                // locationtypeonlineRB.Click();
            }
        

            //Start Date
            Thread.Sleep(300);

            dayCB.SendKeys(SsStartDate);

            //End Date
            if (SsEndDate != null)
            {
                enddate.SendKeys(SsEndDate);
            }
            Thread.Sleep(300);
            skilltradeRB.Click();
            Thread.Sleep(300);

            if (EnterSkillTrade == "Skill-exchange")
            {
                skillexchange.Click();
                skillexchange.SendKeys(EnterSkillExchange);
                skillexchange.SendKeys("\n");
            }
            else
            {
                creditPerHour.Click();
                creditPerHour.SendKeys(SsCredit);
                creditPerHour.SendKeys("\n");
            }
            Thread.Sleep(300);
            //Work Samples
            // Identify the Work Samples and click the plus button to upload photo
            //  Max file size is 2 MB and supported file types are gif / jpeg / png / jpg / doc(x) / pdf / txt / xls(x
            Thread.Sleep(300);
            worksample.Click();
            Thread.Sleep(500);
            AutoItX3 autoIt = new AutoItX3();
            Thread.Sleep(500);
            autoIt.WinActivate("Open");
            Thread.Sleep(500);
            autoIt.Send(EnterWorkSamplesLink);
            Thread.Sleep(500);
            autoIt.Send("{ENTER}");
            Thread.Sleep(500);

            //Active / Deactive
            if (Active == "Active")
            {
                isActive.Click();
            }
            else
            {
                isHidden.Click();
            }
          //  activeHidenRB.Click();

            //SaveButton
            Wait.WaitToBeClickable("XPath", 10, "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]");
            saveButton.Click();
        }
        public void shareskillassert(string EnterTitle,
                                                        string EnterDescription,
                                                        string EnterCategory,
                                                        string EnterServiceType)
        {
            Thread.Sleep(3000);
            Assert.That(titleQA.Text == EnterTitle, " Title match unsuccessful");
            Thread.Sleep(500);
            Assert.That(descriptioncheck.Text == EnterDescription, "Description match unsuccessful");
            Thread.Sleep(500);
            Assert.That(categorycheck.Text == EnterCategory, "Category match unsuccessful");
            Thread.Sleep(500);
            Assert.That(servicecheck.Text == EnterServiceType, "Service Type match unsuccessful");
        }
           

        







      
    }

}
