﻿using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace March2023task2.Utilities.Reports
{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;


        private static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\Result\";

            if (extentReports == null)
            {
                Directory.CreateDirectory(path);

                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(path);

                extentReports.AttachReporter(htmlReporter);
            }
            return extentReports;
        }

        public static void CreateTest(string testName)

        {
            extentTest = StartReporting().CreateTest(testName);
        }

        public static void EndReporting()
        {
            StartReporting().Flush();
        }

        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }

        public static void LogScreenShot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}
