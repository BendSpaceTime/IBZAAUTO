

namespace IbzPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
            VirtualApps va = (VirtualApps) Activator.CreateInstance
                (Type.GetType("IbzPortal.Apps.WebApp"));

            IWebDriver driver = va.LoginPortal(((Browser)Activator.CreateInstance
                (Type.GetType("IbzPortal.Browsers.FireFox"))).getDriver());
            driver = va.CreatingApps(driver);
            driver = va.CleaningUp(driver);
            Console.WriteLine("Test finished");
             * **/
        }
    }
}
