using CompetitionTask.Utilites;
using March2023task2.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
//using ReportUtils.Reports;
using OpenQA.Selenium;
using March2023task2.Utilities;
using March2023task2.Utilities.Reports;

namespace March2023task2.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Testing : CommonDriver
    {
        LoginPage loginobj;
        ProfilePage profileobj;
        ShareSkill createobj;
        ManageListing managelistingobj;

        

        public Testing()
        {
            loginobj = new LoginPage();
            profileobj = new ProfilePage();
            createobj = new ShareSkill();
            managelistingobj = new ManageListing();
        }

        [Test, Order(1)]
        public void ShareSkillAddition()
        {
            //Extent Report Start
            ExtentReporting.LogInfo("Share Skills Action");

            // Login to Mars Portal 
            ExcelLib.PopulateInCollection(@"C:\Users\jeelp\OneDrive\Desktop\March2023task2\March2023task2\March2023task2\March2023task2\XLFiles\Login data.xlsx", "Sheet1");
            loginobj.SignInFunction(ExcelLib.ReadData(1, "Username"),
                                        ExcelLib.ReadData(1, "Password"));

            profileobj.ShareSkillButton();

            //Fill in all fields in Share Skill Form and Save
            ExcelLib.PopulateInCollection(@"C:\Users\jeelp\OneDrive\Desktop\March2023task2\March2023task2\March2023task2\March2023task2\XLFiles\Shareskill Test Data (1).xlsx", "Sheet1");
            //Pass Parameters String EnterTitle,String EnterDescription, string EnterCategory, string EnterSubCategory, string EnterTag, string EnterSkillExchange, string EnterWorkSamplesLink
            createobj.ShareskillAdd(ExcelLib.ReadData(1, "Title"),
                                                            ExcelLib.ReadData(1, "Description"),
                                                            ExcelLib.ReadData(1, "Category"),
                                                            ExcelLib.ReadData(1, "SubCategory"),
                                                            ExcelLib.ReadData(1, "Tag"),
                                                            ExcelLib.ReadData(1, "Service Type"),
                                                            ExcelLib.ReadData(1, "Location Type"),
                                                            ExcelLib.ReadData(1, "StartDate"),
                                                            ExcelLib.ReadData(1, "EndDate"),
                                                            ExcelLib.ReadData(1, "Skill Trade"),
                                                            ExcelLib.ReadData(1, "Skill-Exchange"),
                                                            ExcelLib.ReadData(1, "Credit"),
                                                            ExcelLib.ReadData(1, "WorkSamples"),
                                                         ExcelLib.ReadData(1, "Active"));
            Thread.Sleep(200);
            profileobj.ManageListing();
            Thread.Sleep(200);
           
            //Pass Parameters String EnterTitle,String EnterDescription, string EnterCategory, string EnterSubCategory, string EnterTag, string EnterSkillExchange, string EnterWorkSamplesLink
            createobj.shareskillassert(ExcelLib.ReadData(1, "Title"),
                                                                ExcelLib.ReadData(1, "Description"),
                                                                ExcelLib.ReadData(1, "CategoryDescription"),
                                                                ExcelLib.ReadData(1, "Service Type"));
        }
        [Test, Order(2)]
        public void ShareSkillEdit()
        {

            //Extent Report Start
             ExtentReporting.LogInfo("Share Skills update");

            // Login to Mars Portal
            ExcelLib.PopulateInCollection(@"C:\Users\jeelp\OneDrive\Desktop\March2023task2\March2023task2\March2023task2\March2023task2\XLFiles\Login data.xlsx", "Sheet1");
            loginobj.SignInFunction(ExcelLib.ReadData(1, "Username"),
                                        ExcelLib.ReadData(1, "Password"));

            //Go To Share Skill Entry Form
            profileobj.ManageListing();
            //Fill in all fields in Share Skill Form and Save
            ExcelLib.PopulateInCollection(@"C:\Users\jeelp\OneDrive\Desktop\March2023task2\March2023task2\March2023task2\March2023task2\XLFiles\ManageListing Data (1).xlsx", "Sheet1");
            //Pass Parameters String EnterTitle,String EnterDescription, string EnterCategory, string EnterSubCategory, string EnterTag, string EnterSkillExchange, string EnterWorkSamplesLink
            managelistingobj.UpdateShareSkill(ExcelLib.ReadData(1, "Title"),
                                                            ExcelLib.ReadData(1, "Description"),
                                                            ExcelLib.ReadData(1, "Category"),
                                                            ExcelLib.ReadData(1, "SubCategory"),
                                                            ExcelLib.ReadData(1, "Tag"),
                                                            ExcelLib.ReadData(1, "ServiceType"),
                                                            ExcelLib.ReadData(1, "LocationType"),
                                                            ExcelLib.ReadData(1, "StartDate"),
                                                            ExcelLib.ReadData(1, "EndDate"),
                                                             ExcelLib.ReadData(1, "Skill Trade"),
                                                            ExcelLib.ReadData(1, "Skill-Exchange"),
                                                            ExcelLib.ReadData(1, "Credit"),
                                                            ExcelLib.ReadData(1, "WorkSamples"),
                                                            ExcelLib.ReadData(1, "Active"));


           profileobj.ManageListing();

            
            managelistingobj.EditSkillAssertion(ExcelLib.ReadData(1, "Title"),
                                                            ExcelLib.ReadData(1, "Description"),
                                                            ExcelLib.ReadData(1, "CategoryDescription"),
                                                            ExcelLib.ReadData(1, "ServiceType"));
        


        }
        [Test, Order(3)]
        public void ShareSkillDelete()
        {
            //Extent Report Start
           ExtentReporting.LogInfo("Share Skills delete");

            // Login to Mars Portal
            ExcelLib.PopulateInCollection(@"C:\Users\jeelp\OneDrive\Desktop\March2023task2\March2023task2\March2023task2\March2023task2\XLFiles\Login data.xlsx", "Sheet1");
            loginobj.SignInFunction(ExcelLib.ReadData(1, "Username"),
                                        ExcelLib.ReadData(1, "Password"));

            //Go To Share Skill Entry Form
            profileobj.ManageListing();
            
            ExcelLib.PopulateInCollection(@"C:\Users\jeelp\OneDrive\Desktop\March2023task2\March2023task2\March2023task2\March2023task2\XLFiles\ManageListing Data (1).xlsx", "Sheet1");
           
            managelistingobj.DeleateListing();
            managelistingobj.DeleteSkillAssertion(ExcelLib.ReadData(1, "Title"));
        }



    }

}
