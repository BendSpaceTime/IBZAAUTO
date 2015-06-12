namespace Azure.Automation.Selenium.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Threading;

    public static class WebDriverExtensions
    {
        private static TimeSpan defaultWaitTime = TimeSpan.FromSeconds(180);
        public static WebDriverWait Wait(this IWebDriver driver, int timeoutSeconds, bool ignoreSearchExceptions = false, int pollingInterval = 1, string message = null)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.PollingInterval = TimeSpan.FromSeconds(pollingInterval);

            if (!string.IsNullOrEmpty(message))
            {
                wait.Message = message;
            }

            if (ignoreSearchExceptions)
            {
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            }

            return wait;
        }

        public static IWebElement WaitFindElement(this IWebDriver driver, By locator, int timeoutSeconds, bool expectVisible = false, string errorMessage = null, bool failOnTimeout = true)
        {
            return driver.WaitFindElement(driver, locator, timeoutSeconds, expectVisible, errorMessage, failOnTimeout);
        }

        public static IWebElement WaitFindElement(this ISearchContext context, IWebDriver driver, By locator, int timeoutSeconds, bool expectVisible = false, string errorMessage = null, bool failOnTimeout = true)
        {
            var wait = driver.Wait(timeoutSeconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(IndexOutOfRangeException));

            if (!string.IsNullOrEmpty(errorMessage))
            {
                wait.Message = errorMessage;
            }

            try
            {
                return wait.Until(d =>
                {
                    var element = context.FindElement(locator);
                    return !expectVisible || element.Displayed ? element : null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                if (failOnTimeout)
                {
                    throw;
                }

                return null;
            }
        }

        public static void WaitForPageToLoad(this IWebDriver driver, int seconds = 30)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(seconds);
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
            {
                throw new ArgumentException("driver", "Driver must support javascript execution");
            }

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    // Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    // Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public static bool HasElement(this ISearchContext context, By by)
        {
            try
            {
                context.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        public static bool HasElement(this ISearchContext context, By by, int index)
        {
            try
            {
                IWebElement element = context.FindElements(by)[index];

            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        public static void WaitForURLChange(this IWebDriver driver, Action action, int seconds = 30)
        {
            var currentUrl = driver.Url;

            action();

            var wait = driver.Wait(seconds);

            // Ignore stale element reference exceptions
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            wait.Message = "Navigation did not trigger a change in the page Url";
            wait.Until(d => d.Url != currentUrl);

            driver.WaitForPageToLoad(seconds);
        }

        public static void RepeatActionUntilUrlChangesAndWaitForDocumentLoad(this IWebDriver driver, Action action, int seconds = 30)
        {
            var currentUrl = driver.Url;

            var wait = driver.Wait(seconds);
            wait.Message = "Navigation did not trigger a change in the page Url";

            wait.Until(d =>
            {
                action();

                return d.Url != currentUrl;
            });

            driver.WaitForPageToLoad(seconds);
        }

        public static TResult WaitUntil<TResult>(this IWebDriver webDriver, Func<TResult> condition, string errorMessage)
        {
            return WaitUntil(webDriver, condition, errorMessage, defaultWaitTime);
        }

        /// <summary>
        /// Waits until a condition is met with a specified timeout.
        /// </summary>
        /// <param name="webDriver">The web driver instance</param>
        /// <param name="condition">Condition function, returning anything other than null or false passes the condition.</param>
        /// <param name="errorMessage">Error message to display in the case of timeout.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition.</param>     
        /// <typeparam name="TResult">The delegate's expected return type.</typeparam>
        public static TResult WaitUntil<TResult>(this IWebDriver webDriver, Func<TResult> condition, string errorMessage, TimeSpan timeout)
        {
            var wait = new WebDriverWait(webDriver, timeout);

            // Ignore stale element reference exceptions
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));


            try
            {
                return wait.Until(driver => condition());
            }
            catch (Exception ex)
            {
                if (string.IsNullOrWhiteSpace(errorMessage))
                {
                    throw;
                }
                else
                {
                    throw new WebDriverException(errorMessage, ex);
                }
            }
        }

        [System.Obsolete("use RepeatClickElementSeveralTimes", true)]
        public static void RepeatActionUntilElementDisappear(this IWebDriver driver, Action<IWebElement> action, IWebElement element)
        {
            var wait = driver.Wait(defaultWaitTime.Seconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "dian si ni";

            wait.Until(d =>
            {
                try
                {
                    action(element);
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (WebDriverTimeoutException)
                {
                    return true;
                }
                return false;
            });
        }

        public static void RepeatClickElementSeveralTimes(this IWebDriver driver, By by, int index=0, int clickTimes = 5, int perTime=3)
        {
            for (int times = 0; times < clickTimes; times++)
            {
                Thread.Sleep(perTime * 1000);
                try
                {
                    driver.FindElements(by)[index].Click();
                    break;
                }
                catch (Exception) { continue; }
            }
        }

        public static void FindElementAndClick(this IWebDriver driver, By by)
        {
            driver.WaitUntil(() => driver.HasElement(by), "");
            driver.RepeatClickElementSeveralTimes(by);
        }
/*
        public static IWebElement WaitFindAvailableElement(this IWebDriver driver, By by)
        {
            driver.WaitUntil(() => driver.HasElement(by), "");
            return driver.FindElement(by);
        }
 * */

    }
}
