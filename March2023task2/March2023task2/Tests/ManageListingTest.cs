using March2023task2.Pages;
using March2023task2.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023task2.Tests
{
   
        [TestFixture]
        [Parallelizable]
        public class ManageListingTest : CommonDriver
        {
            LoginPage loginobj;
            ProfilePage profileobj;
            ManageListing managelistingobj;

            public ManageListingTest()
            {
                loginobj = new LoginPage();
                profileobj = new ProfilePage();
                managelistingobj = new ManageListing();
                //IWebDriver driver = new ChromeDriver();
            }
            [Test, Order(1)]
            public void ManageListingaction()
            {
                loginobj.SignInButton();
                loginobj.Email();
                loginobj.Password();
                loginobj.Login();
                profileobj.ManageListing();
                managelistingobj.active();
                managelistingobj.editML();


            }
        }
}
