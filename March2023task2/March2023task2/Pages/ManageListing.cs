using AutoItX3Lib;
using March2023task2.Utilities;
using Microsoft.Office.Interop.Excel;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023task2.Pages
{
    public class ManageListing : CommonDriver
    {
        private IWebElement activeoption => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[7]/div/input"));
        private IWebElement view => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]"));
        private IWebElement edit => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]"));
        private IWebElement titletextbox => driver.FindElement(By.Name("title"));
        private IWebElement descritiontxtbox => driver.FindElement(By.Name("description"));
        private IWebElement categorydropdown => driver.FindElement(By.XPath("//*[@name=\"categoryId\"]"));
        private IWebElement subcatdropdown => driver.FindElement(By.Name("subcategoryId"));
        private IWebElement tagtextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        private IWebElement servicetypeRB => driver.FindElement(By.XPath("//*[@name=\"serviceType\" and @tabindex=\"0\" and @value=\"0\"]"));
        private IWebElement servicetypeonoff => driver.FindElement(By.XPath("//*[@name=\"serviceType\" and @tabindex=\"0\" and @value=\"1\"]"));
        private IWebElement locationtypeonlineRB => driver.FindElement(By.XPath("//*[@name=\"locationType\" and @tabindex=\"0\" and @value=\"1\"]"));
        private IWebElement locationtypeonsiteRB => driver.FindElement(By.XPath("//*[@name=\"locationType\" and @tabindex=\"0\" and @value=\"0\"]"));
        private IWebElement dayCB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div[1]/div[1]/div[2]/input"));
        private IWebElement enddate => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div[1]/div[1]/div[4]/input"));
        private IWebElement skilltradeRB => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @tabindex=\"0\" and @value=\"true\"]"));
        private IWebElement skillCreditRb => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @tabindex=\"0\" and @value=\"false\"]"));
        private IWebElement creditPerHour => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/input"));
        private IWebElement skillexchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        private IWebElement worksample => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        private IWebElement activeHidenRB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        private IWebElement activeActiveRb => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        private IWebElement del => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        private IWebElement acceptOrDecline => driver.FindElement(By.XPath("//*[@class=\"ui icon positive right labeled button\"]"));
        private IWebElement titltcompare => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
        private IWebElement tagremove => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span/a"));
        private IWebElement valuetextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/label/text()"));
        private IWebElement descriptioncompare => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        private IWebElement servicetypecompare => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[5]"));
        private IWebElement categorycompare => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
        
        public void active()
        {
            Thread.Sleep(1000);
            activeoption.Click();
            Thread.Sleep(100);
        }

        public void UpdateShareSkill(string EnterTitle,
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
            Thread.Sleep(1000);
            edit.Click();
            Thread.Sleep(100);

            Wait.WaitToBeClickable("Name", 10, "title");
            titletextbox.Click();
            titletextbox.Clear();
            titletextbox.SendKeys(EnterTitle);
            Thread.Sleep(200);

            //Description
            Wait.WaitToBeClickable("Name", 10, "description");
            descritiontxtbox.Click();
            descritiontxtbox.Clear();
            Thread.Sleep(200);
            descritiontxtbox.SendKeys(EnterDescription);
            Thread.Sleep(200);

            SelectElement categorySelect = new SelectElement(categorydropdown);
            categorySelect.SelectByValue(EnterCategory);
            Thread.Sleep(200);

            Wait.WaitToBeClickable("Name", 5, "subcategoryId");
            SelectElement subcategory = new SelectElement(subcatdropdown);
            subcategory.SelectByValue(EnterSubCategory);
            Thread.Sleep(200);

            Wait.WaitToBeClickable("XPath", 10, "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input");
            tagremove.Click();
            tagtextbox.SendKeys(EnterTag + "\n");
            Thread.Sleep(200);

            if (ServiceType == "Hourly")
            {
                servicetypeRB.Click();
            }
            else
            {
                servicetypeonoff.Click();
            }
            Thread.Sleep(200);

            //Location Type
            if (LocationType == "Online")
            {
                locationtypeonsiteRB.Click();
            }
            else
            {
                locationtypeonlineRB.Click();
            }
            Thread.Sleep(200);
            dayCB.Click();
            dayCB.SendKeys(SsStartDate);

            //End Date
            if (SsEndDate != null)
            {
                enddate.Click();
                enddate.SendKeys(SsEndDate);
            }

            Thread.Sleep(200);
            skillCreditRb.Click();
            Thread.Sleep(200);

            if (EnterSkillTrade == "Skill-Exchange")
            {
                skillexchange.Click();
                skillexchange.SendKeys(EnterSkillExchange);
                skillexchange.SendKeys("\n");
            }
            else
            {
                creditPerHour.Click();
                creditPerHour.Clear();
                creditPerHour.SendKeys(SsCredit);
            }

            Thread.Sleep(300);
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

            if (Active == "Active")
            {
                activeActiveRb.Click();
            }
            else
            {
                activeHidenRB.Click();
            }

            //SaveButton
            Wait.WaitToBeClickable("XPath", 10, "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]");
            saveButton.Click();



        }
        public void DeleateListing()
        {
            Wait.WaitToBeClickable("XPath", 5, "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i");
            del.Click();
            Thread.Sleep(200);
            acceptOrDecline.Click();
        }
        public void EditSkillAssertion(string EnterTitle,
                                      string EnterDescription,
                                      string EnterCategory,
                                      string EnterServiceType)
        {
            Thread.Sleep(1500);
            Assert.That(titltcompare.Text == EnterTitle, "title match unsucessfull");
            Console.WriteLine(titltcompare.Text);

            Thread.Sleep(2000);
            Assert.That(descriptioncompare.Text == EnterDescription, "description match unsucessfull");
            Console.WriteLine(descriptioncompare.Text);

            Thread.Sleep(2000);
            Assert.That(servicetypecompare.Text == EnterServiceType, "servicetype match unsucessfull");
            Console.WriteLine(servicetypecompare.Text);

            Thread.Sleep(2000);
            Assert.That(categorycompare.Text == EnterCategory, "servicetype match unsucessfull");
            Console.WriteLine(categorycompare.Text);
        }
        public void DeleteSkillAssertion(string EnterTitle)
        {
            Thread.Sleep(1500);
            Console.WriteLine(titltcompare.Text);
            Console.WriteLine(EnterTitle);
            Assert.That(titltcompare.Text != EnterTitle, "Deletion unsuccessful");
           
        }


       

       
       

      

       

        
        //public string AlertWindow()
        //{
        //    Thread.Sleep(1500);
        //    IWebElement confirmationAlert = driver.FindElement(By.CssSelector("[class=\"ns-box ns-growl ns-effect-jelly ns-type-success ns-show\"]"));
        //    return confirmationAlert.Text;
        //}

        //public string GetLastListing()
        //{
        //    Thread.Sleep(1500);
        //    IWebElement lastListing = driver.FindElement(By.XPath("//*[@class=\"ui striped table\"]/tbody/tr[1]/td[3]"));
        //    return lastListing.Text;
        //}
    }
    }
