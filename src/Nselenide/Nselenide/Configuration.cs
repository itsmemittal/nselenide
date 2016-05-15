using System.Diagnostics;

namespace NSelenide.Impl
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Safari;

    //public class Configuration
    //{
    //    private static Configuration instance = new Configuration();

    //    private static IWebDriver webdriver;

    //    private static Dictionary<string, string> configs = new Dictionary<string, string>();

    //    public static int ElementDefaultWait
    //    {
    //        get
    //        {
    //            return TryIntEnviornmentVariable("config.element_timeout", "4000");
    //        }
    //    }

    //    public static int Pooling
    //    {
    //        get
    //        {
    //            return TryIntEnviornmentVariable("config.pooling", "200");
    //        }
    //    }

    //    public static string BrowserName
    //    {
    //        get
    //        {
    //            return TryGetEnviornmentVariable("config.browser_name", "firefox");
    //        }

    //        set
    //        {
    //            TrySetEnviornmentVariable("config.browser_name", value);
    //        }
    //    }

    //    public static string ApplicationUrl
    //    {
    //        get
    //        {
    //            return TryGetEnviornmentVariable("config.application_url", "https://localhost/ExamDev/");
    //        }
    //    }

    //    public static bool AllowRemote
    //    {
    //        get
    //        {
    //            return TryBoolEnviornmentVariable("config.remote_automation", "false");
    //        }
    //    }

    //    public static string RemoteHubUrl
    //    {
    //        get
    //        {
    //            var remote = TryGetEnviornmentVariable("config.remote_ip", string.Empty);
    //            var port = TryGetEnviornmentVariable("config.remote_port", string.Empty);
    //            return string.Format("http://{0}:{1}/wd/hub", remote, port);
    //        }
    //    }

    //    public static int ImplicitWait
    //    {
    //        get
    //        {
    //            return TryIntEnviornmentVariable("config.implicit_wait", "60");
    //        }
    //    }

    //    public static int PageLoadTimeout
    //    {
    //        get
    //        {
    //            return TryIntEnviornmentVariable("config.pageload_timeout", "60");
    //        }
    //    }

    //    public static int ScriptExecutionTimeout
    //    {
    //        get
    //        {
    //            return TryIntEnviornmentVariable("config.script_timeout", "60");
    //        }
    //    }

    //    public static string TemplateDirectory
    //    {
    //        get
    //        {
    //            var termplateDir = string.Format("{0}{1}", GetTestAutomationFolderPath(), "templates");
    //            return Directory.Exists(termplateDir) ? termplateDir : string.Empty;
    //        }
    //    }

    //    public string DriverExePath
    //    {
    //        get
    //        {
    //            var driverexeDir = string.Format("{0}{1}", GetTestAutomationFolderPath(), "drivers");
    //            return Directory.Exists(driverexeDir) ? driverexeDir : string.Empty;
    //        }
    //    }

    //    public static IWebDriver CreateDriver()
    //    {
    //        IWebDriver driver;
    //        switch (BrowserName)
    //        {
    //            case BrowserTypes.IE:
    //                {
    //                    driver = instance.CreateIEDriver();
    //                    break;
    //                }

    //            case BrowserTypes.Firefox:
    //                {
    //                    driver = instance.CreateFireFoxDriver();
    //                    break;
    //                }

    //            case BrowserTypes.Chrome:
    //                {
    //                    driver = instance.CreateChromeDriver();
    //                    break;
    //                }

    //            case BrowserTypes.Safari:
    //                {
    //                    driver = instance.CreateSafariDriver();
    //                    break;
    //                }

    //            default:
    //                {
    //                    driver = instance.CreateFireFoxDriver();
    //                    break;
    //                }
    //        }

    //        return driver;
    //    }

    //    protected IWebDriver CreateFireFoxDriver()
    //    {
    //        if (AllowRemote)
    //        {
    //            webdriver = this.CreateRemoteDriver(DesiredCapabilities.Firefox());
    //            return webdriver;
    //        }

    //        if (webdriver == null && !(webdriver is FirefoxDriver))
    //        {
    //            webdriver = new FirefoxDriver();
    //            SetDriverConfiguration(webdriver);
    //        }

    //        return webdriver;
    //    }

    //    //protected IWebDriver CreateCustomDriver()
    //    //{
    //    //    var pr = Process.GetProcessesByName(string.Format("{0}\",DriverExePath))};
    //    //    if (AllowRemote)
    //    //    {
    //    //        webdriver = this.CreateRemoteDriver(DesiredCapabilities.Firefox());
    //    //        return webdriver;
    //    //    }

    //    //    if (webdriver == null && !(webdriver is FirefoxDriver))
    //    //    {
    //    //        webdriver = new FirefoxDriver();
    //    //        SetDriverConfiguration(webdriver);
    //    //    }

    //    //    return webdriver;
    //    //}


    //    protected IWebDriver CreateIEDriver()
    //    {
    //        if (AllowRemote)
    //        {
    //            webdriver = this.CreateRemoteDriver(DesiredCapabilities.InternetExplorer());
    //            return webdriver;
    //        }

    //        if (webdriver == null && !(webdriver is InternetExplorerDriver))
    //        {
    //            InternetExplorerOptions options = new InternetExplorerOptions
    //                { IgnoreZoomLevel = true, EnableNativeEvents = false };
    //            webdriver = new InternetExplorerDriver(this.DriverExePath, options);
    //            webdriver.Navigate().GoToUrl(Configuration.ApplicationUrl);
    //            SetDriverConfiguration(webdriver);
    //            webdriver.FindElement(By.Id("overridelink")).Click();
    //        }

    //        return webdriver;
    //    }

    //    protected IWebDriver CreateChromeDriver()
    //    {
    //        if (AllowRemote)
    //        {
    //            webdriver = this.CreateRemoteDriver(DesiredCapabilities.Chrome());
    //            return webdriver;
    //        }

    //        if (webdriver == null && !(webdriver is ChromeDriver))
    //        {
    //            ChromeOptions chromeOptions = new ChromeOptions();
    //            chromeOptions.AddArgument("--disable-extensions");
    //            webdriver = new ChromeDriver(this.DriverExePath,chromeOptions);
    //            SetDriverConfiguration(webdriver);
    //        }

    //        return webdriver;
    //    }

    //    protected IWebDriver CreateSafariDriver()
    //    {
    //        if (AllowRemote)
    //        {
    //            webdriver = this.CreateRemoteDriver(DesiredCapabilities.Safari());
    //            return webdriver;
    //        }

    //        if (webdriver == null && !(webdriver is SafariDriver))
    //        {
    //            webdriver = new SafariDriver();
    //            SetDriverConfiguration(webdriver);
    //        }

    //        return webdriver;
    //    }

    //    private static void SetDriverConfiguration(IWebDriver driver)
    //    {
    //        driver.Manage().Timeouts().ImplicitlyWait(
    //            TimeSpan.FromSeconds(TryIntEnviornmentVariable("config.implicit_wait", "0")));
    //        driver.Manage().Timeouts().SetPageLoadTimeout(
    //            TimeSpan.FromSeconds(TryIntEnviornmentVariable("config.pageload_timeout", "60")));
    //        driver.Manage().Timeouts().SetScriptTimeout(
    //            TimeSpan.FromSeconds(TryIntEnviornmentVariable("config.script_timeout", "0")));
    //    }

    //    private static string TryGetEnviornmentVariable(string key, string defaultValue)
    //    {
    //        var value = Environment.GetEnvironmentVariable(key);

    //        if (string.IsNullOrEmpty(value))
    //        {
    //            Environment.SetEnvironmentVariable(key, defaultValue);
    //            value = defaultValue;
    //        }

    //        return value;
    //    }

    //    private static bool TryBoolEnviornmentVariable(string key, string defaultValue)
    //    {
    //        var value = Environment.GetEnvironmentVariable(key);
    //        if (string.IsNullOrEmpty(value))
    //        {
    //            Environment.SetEnvironmentVariable(key, defaultValue);
    //            value = defaultValue;
    //        }
    //        bool result;
    //        bool.TryParse(value, out result);
    //        return result;
    //    }

    //    private static int TryIntEnviornmentVariable(string key, string defaultValue)
    //    {
    //        var value = Environment.GetEnvironmentVariable(key);
    //        if (string.IsNullOrEmpty(value))
    //        {
    //            Environment.SetEnvironmentVariable(key, defaultValue);
    //            value = defaultValue;
    //        }
    //        int result;
    //        int.TryParse(value, out result);
    //        return result;
    //    }

    //    private static string GetTestAutomationFolderPath()
    //    {
    //        const string TestAutomationFolder = @"TestAutomation\";
    //        var basDir = AppDomain.CurrentDomain.BaseDirectory;
    //        var root = basDir.Substring(0, basDir.LastIndexOf(TestAutomationFolder, StringComparison.InvariantCulture));
    //        return string.Format("{0}{1}", root, TestAutomationFolder);
    //    }

    //    private static void TrySetEnviornmentVariable(string key, string value)
    //    {
    //        Environment.SetEnvironmentVariable(key, value);
    //    }

    //    private IWebDriver CreateRemoteDriver(DesiredCapabilities capabilities)
    //    {
    //        webdriver = new RemoteWebDriver(new Uri(RemoteHubUrl), capabilities);
    //        SetDriverConfiguration(webdriver);
    //        return webdriver;
    //    }
    //}

    public static class Settings
    {
        public static string BaseUrl
        {
            get
            {
                return GetEnviornmentVariable("nselenide.baseUrl", "http://localhost:8080");  
            }
        }

        public static int Timeout
        {
            get
            {
                return int.Parse(GetEnviornmentVariable("nselenide.timeout", "4000"));
            }
        }

        public static int Pooling
        {
            get
            {
                return int.Parse(GetEnviornmentVariable("nselenide.pooling", "100"));
            }
        }

        public static string Browser
        {
            get
            {
                return GetEnviornmentVariable("nselenide.browser", "firefox");
            }
        }

        public static string Remote
        {
            get
            {
                return GetEnviornmentVariable("nselenide.remote", null);
            }
        }

        public static bool StartMaximize
        {
            get
            {
                bool outValue;
                bool.TryParse(GetEnviornmentVariable("nselenide.start-maximized", "false"), out outValue);
                return outValue;
            }
        }

        public static string ClickViaJs
        {
            get
            {
                return GetEnviornmentVariable("nselenide.click-via-js", "false");
            }
        }

        public static string ScreenShots
        {
            get
            {
                return GetEnviornmentVariable("nselenide.screenshots", "true");
            }
        }

        public static bool MockDialogs
        {
            get
            {
                bool outValue;
                bool.TryParse(GetEnviornmentVariable("nselenide.mockdialog", "false"), out outValue);
                return outValue;
            }
        }

        public static bool FastSet
        {
            get
            {
                bool outValue;
                bool.TryParse(GetEnviornmentVariable("nselenide.mockdialog", "false"), out outValue);
                return outValue;
            }
        }

        public static bool ReopenBrowserOnFail
        {
            get
            {
                bool outValue;
                bool.TryParse(GetEnviornmentVariable("nselenide.reopenBrowserOnFail", "true"), out outValue);
                return outValue;
            }
        }


        public static AssertionMode AssertionMode = AssertionMode.Strict;

        private static void SetEnviornmentVariable(string key, string value)
        {
            Environment.SetEnvironmentVariable(key, value);
        }

        private static string GetEnviornmentVariable(string key, string defaultValue)
        {
            var value = Environment.GetEnvironmentVariable(key);

            if (string.IsNullOrEmpty(value))
            {
                Environment.SetEnvironmentVariable(key, defaultValue);
                value = defaultValue;
            }

            return value;
        }
    }

    public enum AssertionMode
    {
        Strict,
        Soft
    }

    public class CustomRemoteWebDriver : RemoteWebDriver
    {
        public static bool newSession = false;

        public static string sessiodIdPath = @"C:\Users\Isu\Desktop\songs\NSelenide\NSelenide\NSelenideTest\sessions";

        public CustomRemoteWebDriver(Uri remoteAddress, DesiredCapabilities dd)
            : base(remoteAddress, dd)
        {


        }

        protected override Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            if (driverCommandToExecute == DriverCommand.NewSession)
            {
                if (!newSession)
                {

                    var sidText = File.ReadAllText(sessiodIdPath);


                    return new Response
                    {
                        SessionId = sidText,

                    };
                }
                else
                {
                    var response = base.Execute(driverCommandToExecute, parameters);
                    File.WriteAllText(sessiodIdPath, response.SessionId);
                    return response;
                }
            }
            else
            {
                var response = base.Execute(driverCommandToExecute, parameters);
                return response;
            }
        }
    }


}