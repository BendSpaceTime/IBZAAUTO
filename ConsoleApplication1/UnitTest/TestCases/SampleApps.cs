using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.TestCases;
using OpenQA.Selenium;
using Azure.Automation.Selenium.Extensions;
using System;
using UnitTest.Extensions;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1 : TestClass
    {
        [ClassInitialize()]
        public static void TestMethod1(TestContext testContext)
        {
            Console.WriteLine("Test Class Initialized");
            TestClass.TestInitial();
            TestClass.Login();
        }

        [TestCleanup()]
        public void TestsCleanup()
        {
            TestClass.MoveToHome();
            Console.WriteLine("Move to home page");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //TestClass.driver.Close();
        }

        [TestMethod]
        [TestCategory(TestCategory.Demo_APP)]
        public void CreateSimpleApp()
        {
            //Click MarketPlace
            TestClass.driver.FindElementAndClick(By.CssSelector("div[class='msportalfx-fill ext-gallery-startboard-tile ext-gallery-startboard-tile-normal']"));

            //Click Web Apps
            driver.FindElementAndClick(By.XPath("//div[@class='msportalfx-text-header ext-gallery-menu-item'][contains(.,'Web Apps')]"));

            //Click ASP.NET Empty Web App
            driver.FindElementAndClick(By.XPath("//div[@class='ext-gallery-featured-gallery-control-item ext-gallery-item'][contains(.,'ASP.NET Empty Web App')]"));

            //Click Create
            driver.FindElementAndClick(By.XPath("//button[@class='fxcontrol-actionBarBase-button fxcontrol-createActionBar-okButton fxcontrol-base fxcontrol-button azc-control azc-button azc-button-default azc-btn-primary']"));

            //Send URL to the URL edit box
            //testaspnetemptysite
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")), "");
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).SendKeys("testaspnetemptysiteas");

            //Click App service plan
            driver.FindElementAndClick(By.XPath("//span[.='App Service plan']"));

            //Create new App service plan
            driver.FindElementAndClick(By.XPath("//a[.='Or create new']"));
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='fxcontrol-selector-createnew-container']//input")), "");
            driver.FindElement(By.XPath("//div[@class='fxcontrol-selector-createnew-container']//input")).SendKeys("teststartersiteplan");

            //Select Pricing tiger
            driver.FindElementAndClick(By.XPath("//span[.='Pricing tier']"));
            //Click See All
            driver.FindElementAndClick(By.XPath("//span[.='View all']"));
            //Select Free
            driver.FindElementAndClick(By.XPath("//span[.='Free']"));
            //Click Create
            driver.RepeatClickElementSeveralTimes(By.XPath("//button[@data-bind='pcButton: func._selectButton, visible: data.showSelectButton']"));

            //Create new Resource group
            driver.FindElementAndClick(By.XPath("//a[.='Or create new']"));
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='fxcontrol-selector-createnew-container']//input")), "");
            driver.FindElements(By.XPath("//div[@class='fxcontrol-selector-createnew-container']//input"))[1].SendKeys("newresourcea");

            //Create this app
            driver.RepeatClickElementSeveralTimes(By.XPath("//section[@class='fxs-mode-locked fxs-blade-locked fxs-blade-paired-smallmaster fxs-blade fx-rightClick fxs-stacklayout-child fxs-bladestyle-create fxs-theme-context-create fxs-bladesize-small']//button[contains(.,'Create')]"));
            //Action<IWebElement> action = IbzPortal.Someting.Delegate.Click;
            //driver.RepeatActionUntilElementDisappear(action, driver.FindElement(By.XPath("//section[@class='fxs-mode-locked fxs-blade-locked fxs-blade-paired-smallmaster fxs-blade fx-rightClick fxs-stacklayout-child fxs-bladestyle-create fxs-theme-context-create fxs-bladesize-small']//button[contains(.,'Create')]")));
        }

        [TestMethod]
        [TestCategory(TestCategory.MySQL_APP)]
        public void Joomla()
        {
            //Click MarketPlace
            TestClass.driver.FindElementAndClick(By.CssSelector("div[class='msportalfx-fill ext-gallery-startboard-tile ext-gallery-startboard-tile-normal']"));

            //Click Web Apps
            driver.FindElementAndClick(By.XPath("//div[@class='msportalfx-text-header ext-gallery-menu-item'][contains(.,'Web Apps')]"));
            
            //Select Joomla and Click
            driver.FindElementAndClick(By.XPath("//div[.='Joomla']"));
            driver.FindElementAndClick(By.XPath("//button[@class='fxcontrol-actionBarBase-button fxcontrol-createActionBar-okButton fxcontrol-base fxcontrol-button azc-control azc-button azc-button-default azc-btn-primary']"));
            
            //Resource Group
            //Here use default resource group
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")), "");
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).Clear();
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).SendKeys("testjoomla");

            //Configure Web App
            driver.FindElementAndClick(By.XPath("//span[.='Web app']"));
            //inner Web App Configure
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"),1), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[1].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[1].SendKeys("testjoomlaportal");

            //Create new app service plan
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 2), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[2].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[2].SendKeys("joomla");

            //Select Pricing tiger
            driver.FindElementAndClick(By.XPath("//span[.='Pricing tier']"));
            //Click See All
            driver.FindElementAndClick(By.XPath("//span[.='View all']"));
            //Select Free
            driver.FindElementAndClick(By.XPath("//span[.='Free']"));
            //Click Create
            driver.RepeatClickElementSeveralTimes(By.XPath("//button[@data-bind='pcButton: func._selectButton, visible: data.showSelectButton']"));

            //Config Web app Settings
            driver.FindElementAndClick(By.XPath("//span[.='Web app Settings']"));
            //Website Name
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 3), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[3].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[3].SendKeys("Test Joomla");
            //Site Administrator Name
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 4), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[4].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[4].SendKeys("JoomlaAdmin");
            //Administrator password
            driver.WaitUntil(() => driver.HasElement(By.XPath("//input[@type='password']"), 0), "");
            driver.FindElements(By.XPath("//input[@type='password']"))[0].SendKeys("Pass@word1");

            //Confirm Administrator password
            driver.WaitUntil(() => driver.HasElement(By.XPath("//input[@type='password']"), 1), "");
            driver.FindElements(By.XPath("//input[@type='password']"))[1].SendKeys("Pass@word1");

            //Administrator Email
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 5), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[5].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[5].SendKeys("admin@admin.com");

            //Click OK
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"), 1);
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"));

            //Configure Database
            driver.FindElementAndClick(By.XPath("//span[.='Database']"));
            //Database name //div[@data-bind='formElement: databaseName']//input
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@data-bind='formElement: databaseName']//input")), "");
            driver.FindElement(By.XPath("//div[@data-bind='formElement: databaseName']//input")).Click();
            driver.FindElement(By.XPath("//div[@data-bind='formElement: databaseName']//input")).SendKeys("TestJoomlaDb");

            //Configure pricing Tier
            driver.FindElementAndClick(By.XPath("//span[.='Pricing Tier']"));
            //Select Mercury
            driver.FindElementAndClick(By.XPath("//span[.='Mercury']"));
            driver.RepeatClickElementSeveralTimes(By.XPath("//button[@data-bind='pcButton: func._selectButton, visible: data.showSelectButton']"));

            //Legal Terms
            driver.FindElementAndClick(By.XPath("//span[.='Legal Terms']"));
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"), 1);
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"));
        
            //Create this app
            driver.RepeatClickElementSeveralTimes(By.XPath("//section[@class='fxs-mode-locked fxs-blade-locked fxs-blade-paired-smallmaster fxs-blade fx-rightClick fxs-stacklayout-child fxs-bladestyle-create fxs-theme-context-create fxs-bladesize-small']//button[contains(.,'Create')]"));
        }

        [TestMethod]
        [TestCategory(TestCategory.SQL_APP)]
        public void Umbraco()
        {
            //Click MarketPlace
            TestClass.driver.FindElementAndClick(By.CssSelector("div[class='msportalfx-fill ext-gallery-startboard-tile ext-gallery-startboard-tile-normal']"));

            //Click Web Apps
            driver.FindElementAndClick(By.XPath("//div[@class='msportalfx-text-header ext-gallery-menu-item'][contains(.,'Web Apps')]"));

            //Select Joomla and Click
            driver.FindElementAndClick(By.XPath("//div[.='Umbraco CMS']"));
            driver.FindElementAndClick(By.XPath("//button[@class='fxcontrol-actionBarBase-button fxcontrol-createActionBar-okButton fxcontrol-base fxcontrol-button azc-control azc-button azc-button-default azc-btn-primary']"));

            //Resource Group
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")), "");
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).Clear();
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).SendKeys("testjoomla");

            //Configure Web App
            driver.FindElementAndClick(By.XPath("//span[.='Web app']"));
            //inner Web App Configure
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 1), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[1].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[1].SendKeys("umbracocmsapstest");

            //Create new app service plan
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 2), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[2].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[2].SendKeys("umbracotest");

            //Select Pricing tiger
            driver.FindElementAndClick(By.XPath("//span[.='Pricing tier']"));
            //Click See All
            driver.FindElementAndClick(By.XPath("//span[.='View all']"));
            //Select Free
            driver.FindElementAndClick(By.XPath("//span[.='Free']"));
            //Click Create
            driver.RepeatClickElementSeveralTimes(By.XPath("//button[@data-bind='pcButton: func._selectButton, visible: data.showSelectButton']"));

            //Config Web app Settings
            driver.FindElementAndClick(By.XPath("//span[.='Web app Settings']"));

            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 3), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[3].Clear();
            //Admin username
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[3].SendKeys("umbracouserName");

            //Admin password
            driver.WaitUntil(() => driver.HasElement(By.XPath("//input[@type='password']"), 0), "");
            driver.FindElements(By.XPath("//input[@type='password']"))[0].SendKeys("Pass@word1");

            //Confirm Admin password
            driver.WaitUntil(() => driver.HasElement(By.XPath("//input[@type='password']"), 1), "");
            driver.FindElements(By.XPath("//input[@type='password']"))[1].SendKeys("Pass@word1");

            //Click OK
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"), 1);
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"));

            //Configure Database
            driver.FindElementAndClick(By.XPath("//span[.='Database']"));

            //Create a new Database
            driver.FindElementAndClick(By.XPath("//span[.='Create a new database']"));
            
            //send database name
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@data-formelement='formElement: databaseNameTextField']//input")), "");
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: databaseNameTextField']//input")).SendKeys("testUmbracodb");

            //Pricing tier
            driver.FindElementAndClick(By.XPath("//span[.='Pricing Tier']"));

            //Select Basic tier
            driver.WaitUntil(() => driver.HasElement(By.XPath("//span[.='Basic']")), "");
            driver.FindElementAndClick(By.XPath("//span[.='Basic']"));
            //Confire pricing tier
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='Select']"),1);

            //Configure Server
            driver.FindElementAndClick(By.XPath("//span[.='SERVER']"));
            //DB Server Name
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@data-formelement='formElement: serverName']//input")), "");
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: serverName']//input")).SendKeys("umbracoserver");

            //server admin login
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: serverAdminLogin']//input")).SendKeys("umbracoadmin");
            //password
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: passwordViewModel']//input")).SendKeys("Pass@word1");
            //confirm password
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: confirmPasswordViewModel']//input")).SendKeys("Pass@word1");
            //click ok
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"), 1);
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"));

            //Create this app
            driver.RepeatClickElementSeveralTimes(By.XPath("//section[@class='fxs-mode-locked fxs-blade-locked fxs-blade-paired-smallmaster fxs-blade fx-rightClick fxs-stacklayout-child fxs-bladestyle-create fxs-theme-context-create fxs-bladesize-small']//button[contains(.,'Create')]"));
        }

        [TestMethod]
        [TestCategory(TestCategory.MySQL_APP)]
        public void ECCUBE()
        {
            //Click MarketPlace
            TestClass.driver.FindElementAndClick(By.CssSelector("div[class='msportalfx-fill ext-gallery-startboard-tile ext-gallery-startboard-tile-normal']"));

            //Click Web Apps
            driver.FindElementAndClick(By.XPath("//div[@class='msportalfx-text-header ext-gallery-menu-item'][contains(.,'Web Apps')]"));

            //Click ASP.NET Empty Web App
            driver.FindElementAndClick(By.XPath("//div[.='EC-CUBE']"));

            //Click Create
            driver.FindElementAndClick(By.XPath("//button[@class='fxcontrol-actionBarBase-button fxcontrol-createActionBar-okButton fxcontrol-base fxcontrol-button azc-control azc-button azc-button-default azc-btn-primary']"));

            //Configure Web App
            driver.FindElementAndClick(By.XPath("//span[.='Web app']"));
            //inner Web App Configure
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 1), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[1].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[1].SendKeys("eccubeapstest");

            //Create new app service plan
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 2), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[2].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[2].SendKeys("eccubetest");

            //Select Pricing tiger
            driver.FindElementAndClick(By.XPath("//span[.='Pricing tier']"));
            //Click See All
            driver.FindElementAndClick(By.XPath("//span[.='View all']"));
            //Select Free
            driver.FindElementAndClick(By.XPath("//span[.='Free']"));
            //Click Select
            driver.RepeatClickElementSeveralTimes(By.XPath("//button[@data-bind='pcButton: func._selectButton, visible: data.showSelectButton']"));
            //Click Ok
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"));

            //Configure Database
            driver.FindElementAndClick(By.XPath("//span[.='Database']"));
            //Database name //div[@data-bind='formElement: databaseName']//input
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@data-bind='formElement: databaseName']//input")), "");
            driver.FindElement(By.XPath("//div[@data-bind='formElement: databaseName']//input")).Click();
            driver.FindElement(By.XPath("//div[@data-bind='formElement: databaseName']//input")).SendKeys("TesteccubeDb");

            //Configure pricing Tier
            driver.FindElementAndClick(By.XPath("//span[.='Pricing Tier']"));
            //Select Mercury
            driver.FindElementAndClick(By.XPath("//span[.='Mercury']"));
            driver.RepeatClickElementSeveralTimes(By.XPath("//button[@data-bind='pcButton: func._selectButton, visible: data.showSelectButton']"));

            //Legal Terms
            driver.FindElementAndClick(By.XPath("//span[.='Legal Terms']"));
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"), 1);
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"));

            //Configure resource group
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")), "");
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).Clear();
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).SendKeys("testeccube");
            
            //Create this app
            driver.RepeatClickElementSeveralTimes(By.XPath("//section[@class='fxs-mode-locked fxs-blade-locked fxs-blade-paired-smallmaster fxs-blade fx-rightClick fxs-stacklayout-child fxs-bladestyle-create fxs-theme-context-create fxs-bladesize-small']//button[contains(.,'Create')]"));
        }

        [TestMethod]
        [TestCategory(TestCategory.SQL_APP)]
        public void Incentive()
        {
            //Click MarketPlace
            TestClass.driver.FindElementAndClick(By.CssSelector("div[class='msportalfx-fill ext-gallery-startboard-tile ext-gallery-startboard-tile-normal']"));

            //Click Web Apps
            driver.FindElementAndClick(By.XPath("//div[@class='msportalfx-text-header ext-gallery-menu-item'][contains(.,'Web Apps')]"));

            //Click ASP.NET Empty Web App
            driver.FindElementAndClick(By.XPath("//div[.='Incentive']"));

            //Click Create
            driver.FindElementAndClick(By.XPath("//button[@class='fxcontrol-actionBarBase-button fxcontrol-createActionBar-okButton fxcontrol-base fxcontrol-button azc-control azc-button azc-button-default azc-btn-primary']"));

            //Resource Group
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")), "");
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).Clear();
            driver.FindElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input")).SendKeys("testIncentive");

            //Configure Web App
            driver.FindElementAndClick(By.XPath("//span[.='Web app']"));
            //inner Web App Configure
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 1), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[1].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[1].SendKeys("eccubeapstest");

            //Create new app service plan
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 2), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[2].Clear();
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[2].SendKeys("eccubetest");

            //Select Pricing tiger
            driver.FindElementAndClick(By.XPath("//span[.='Pricing tier']"));
            //Click See All
            driver.FindElementAndClick(By.XPath("//span[.='View all']"));
            //Select Free
            driver.FindElementAndClick(By.XPath("//span[.='Free']"));
            //Click Select
            driver.RepeatClickElementSeveralTimes(By.XPath("//button[@data-bind='pcButton: func._selectButton, visible: data.showSelectButton']"));
            
            //Config Web app Settings
            driver.FindElementAndClick(By.XPath("//span[.='Web app Settings']"));

            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"), 3), "");
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[3].Clear();
            //DB username
            driver.FindElements(By.XPath("//div[@class='msportalfx-form msportalfx-form-create']//div[@class='azc-textBox-wrapper']/input"))[3].SendKeys("IncentiveDbUserName");

            //DB password
            driver.WaitUntil(() => driver.HasElement(By.XPath("//input[@type='password']"), 0), "");
            driver.FindElements(By.XPath("//input[@type='password']"))[0].SendKeys("Pass@word1");

            //Confirm DB password
            driver.WaitUntil(() => driver.HasElement(By.XPath("//input[@type='password']"), 1), "");
            driver.FindElements(By.XPath("//input[@type='password']"))[1].SendKeys("Pass@word1");

            //click ok
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"), 1);
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"));

            //Configure Database
            driver.FindElementAndClick(By.XPath("//span[.='Database']"));

            //Create a new Database
            driver.FindElementAndClick(By.XPath("//span[.='Create a new database']"));

            //send database name
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@data-formelement='formElement: databaseNameTextField']//input")), "");
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: databaseNameTextField']//input")).SendKeys("testIncentive");

            //Pricing tier
            driver.FindElementAndClick(By.XPath("//span[.='Pricing Tier']"));

            //Select Basic tier
            driver.WaitUntil(() => driver.HasElement(By.XPath("//span[.='Basic']")), "");
            driver.FindElementAndClick(By.XPath("//span[.='Basic']"));
            //Confire pricing tier
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='Select']"), 1);

            //Configure Server
            driver.FindElementAndClick(By.XPath("//span[.='SERVER']"));
            //DB Server Name
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[@data-formelement='formElement: serverName']//input")), "");
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: serverName']//input")).SendKeys("incentiveserver");

            //server admin login
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: serverAdminLogin']//input")).SendKeys("incentiveadmin");
            //password
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: passwordViewModel']//input")).SendKeys("Pass@word1");
            //confirm password
            driver.FindElement(By.XPath("//div[@data-formelement='formElement: confirmPasswordViewModel']//input")).SendKeys("Pass@word1");
            //click ok
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"), 1);
            driver.RepeatClickElementSeveralTimes(By.XPath("//span[.='OK']"));

            //Create this app
            driver.RepeatClickElementSeveralTimes(By.XPath("//section[@class='fxs-mode-locked fxs-blade-locked fxs-blade-paired-smallmaster fxs-blade fx-rightClick fxs-stacklayout-child fxs-bladestyle-create fxs-theme-context-create fxs-bladesize-small']//button[contains(.,'Create')]"));
        }
    }
}
