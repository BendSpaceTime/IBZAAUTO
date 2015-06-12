
using OpenQA.Selenium;
using Azure.Automation.Selenium.Extensions;
using OpenQA.Selenium.Firefox;

namespace UnitTest.TestCases
{
    public class TestClass
    {
        public static IWebDriver driver = null;

        public static void TestInitial()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("xx", "xx");
            driver = new FirefoxDriver(profile);
        }

        public static void MoveToHome()
        {
            TestClass.driver.FindElement(By.XPath("//div[.='Home']")).Click();
        }

        public static void Login()
        {
            string name = "hengzhangwei@hotmail.com";
            string pwd = "Inet@mgr.87";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://portal.azure.com");

            driver.WaitUntil(() => driver.HasElement(By.CssSelector("input[id='cred_userid_inputtext']")), "");
            driver.FindElement(By.CssSelector("input[id='cred_userid_inputtext']")).SendKeys(name);
            driver.FindElement(By.CssSelector("span[id='cred_continue_button']")).Click();

            driver.WaitUntil(() => driver.HasElement(By.CssSelector("input[aria-labelledby='idDiv_PWD_PasswordExample']")), "");
            driver.FindElement(By.CssSelector("input[aria-labelledby='idDiv_PWD_PasswordExample']")).SendKeys(pwd);
            driver.FindElement(By.CssSelector("input[id='idSIButton9']")).Click();
        }
    }
}
