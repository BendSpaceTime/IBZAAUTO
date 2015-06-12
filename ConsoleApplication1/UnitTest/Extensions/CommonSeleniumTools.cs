using OpenQA.Selenium;
using Azure.Automation.Selenium.Extensions;
using System;
using System.Collections.ObjectModel;

namespace UnitTest.Extensions
{
    public static class CommonSeleniumTools
    {
        public static void selectGivenAppServicePlan(IWebDriver driver, String appServiceName)
        {
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[.='Use existing App Service plan']")), "");
            ReadOnlyCollection<IWebElement> services = driver.FindElements(By.XPath("//div[@class='fxcontrol-base Formatter FormatterHtmlBindings Focusable ResizableColumn Selectable RightClickableRow azc-control azc-grid-focusableRow azc-grid-resizableColumn azc-grid-selectableRow azc-grid-activateableRow azc-grid-rightClickableRow azc-grid']//tr"));
            foreach (IWebElement element in services)
            {
                if (appServiceName == element.FindElement(By.XPath("//div[@class='msportalfx-text-header-regular msportalfx-text-ellipsis']")).Text)
                    element.Click();
            }
            
        }

        [System.Obsolete("Not Stable", true)]
        public static void selectGivenResourceGroup(IWebDriver driver, String resourceGroup)
        {
            driver.WaitUntil(() => driver.HasElement(By.XPath("//div[.='Use an existing resource group']")), "");
            ReadOnlyCollection<IWebElement> services = driver.FindElements(By.XPath("//div[@class='fxcontrol-base Formatter FormatterHtmlBindings Focusable ResizableColumn Selectable RightClickableRow azc-control azc-grid-focusableRow azc-grid-resizableColumn azc-grid-selectableRow azc-grid-activateableRow azc-grid-rightClickableRow azc-grid']//tr"));
            foreach (IWebElement element in services)
            {
                if (resourceGroup == element.FindElement(By.XPath("//div[@class='msportalfx-text-header-regular msportalfx-text-ellipsis msportalfx-tooltip-overflow']")).Text)
                    element.Click();
            }

        }
    }
}
