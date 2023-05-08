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
    public class ShareSkill_test:CommonDriver
    {
        LoginPage loginobj;
        ProfilePage profileobj;
        ShareSkill createobj;
        
        public ShareSkill_test()
        {
            loginobj = new LoginPage();
            profileobj = new ProfilePage();
            createobj = new ShareSkill();
            //IWebDriver driver = new ChromeDriver();
        }
        [Test, Order(1)]
        public void shareskillaction()
        {
            loginobj.SignInButton();
            loginobj.Email();
            loginobj.Password();
            loginobj.Login();
            profileobj.ShareSkillButton();
            createobj.Title();
            createobj.Description();
            createobj.Category();
            createobj.SubCatagory();
            createobj.Tags();
            createobj.ServiceTypeRB();
            createobj.LocationTypeRB();
            createobj.Days();
            createobj.Enddate();
            createobj.skilltradeaction();
            createobj.skillexchangeaction();
            createobj.worksamples();
            createobj.activeaction();
            createobj.saveaction();


        }
        //[Test, Order(2)]
        //public void Editsteps()
        //{
        //    homeobj.GoToTmPage(driver);
        //    //tmobj.EditTm(driver);
        //}

    }
}
