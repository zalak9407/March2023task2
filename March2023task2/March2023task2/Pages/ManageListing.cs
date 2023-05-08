using March2023task2.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023task2.Pages
{
    public class ManageListing:CommonDriver
    {
       private IWebElement activeoption => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[7]/div/input"));
        //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr/td[7]/div/input
        //tr[1]/td[7]/div/input[@name=\"isActive\"]
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
        private IWebElement dayCB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input"));
        //*[@id="service-listing-section"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input
        private IWebElement skilltradeRB => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @tabindex=\"0\" and @value=\"true\"]"));
        private IWebElement skillCreditRb => driver.FindElement(By.XPath("//*[@name=\"skillTrades\" and @tabindex=\"0\" and @value=\"false\"]"));
        private IWebElement creditPerHour => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/input"));
        private IWebElement skillexchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        private IWebElement worksample => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        private IWebElement activeHidenRB => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        private IWebElement activeActiveRb => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        private IWebElement del => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));

        private IWebElement tagremove => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span/a"));
        //private IWebElement del => driver.FindElement(By.XPath(""));
        private IWebElement valuetextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/label/text()"));
        public void active()
        {
            Thread.Sleep(1000);
           // Wait.WaitToBeClickable("XPath",10, "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[7]/div/input");
           activeoption.Click();
            Thread.Sleep(100);
        }

        public void editML()
        {
            Thread.Sleep(1000);

            edit.Click();
            Thread.Sleep(100);

            titletextbox.Click();
            titletextbox.Clear();
            titletextbox.SendKeys("QQAA");

            descritiontxtbox.Click();
            descritiontxtbox.Clear();
            descritiontxtbox.SendKeys("Testing testing");

            SelectElement categorySelect = new SelectElement(categorydropdown);
            categorySelect.SelectByValue("5");

            Wait.WaitToBeClickable("Name", 5, "subcategoryId");
            SelectElement subcategory = new SelectElement(subcatdropdown);
            subcategory.SelectByValue("3");

            Thread.Sleep(1000);

            Wait.WaitToBeClickable("XPath", 10, "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input");
            tagremove.Click();
            tagtextbox.SendKeys("Writing" +"\n");
            Thread.Sleep(100);


            servicetypeonoff.Click();
//            Console.WriteLine(value);
         //   if ( valuetextbox.Text == "On-site")
          //  {
               // locationtypeonlineRB.Click();
              //  locationtypeonsiteRB.Click();
           // }
           //  else
           // {
                locationtypeonsiteRB.Click();
           // }
            skillCreditRb.Click();
            creditPerHour.Click();
            creditPerHour.Clear();
            creditPerHour.SendKeys("10");
            activeActiveRb.Click();
            saveButton.Click();

        }
    }
}
