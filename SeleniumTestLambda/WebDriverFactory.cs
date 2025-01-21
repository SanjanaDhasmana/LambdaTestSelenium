using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using static System.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace SeleniumTestLambda
{
    public  class WebDriverFactory
    {
       
        public  ICapabilities browserCapabilities(string browserName)
        {
            String LT_USERNAME = GetEnvironmentVariable("LT_USERNAME");
            String LT_ACCESS_KEY = GetEnvironmentVariable("LT_ACCESS_KEY");
            switch (browserName.ToLower())
            {
                case "chrome":

                    ChromeOptions chrome = new ChromeOptions();            
                    chrome.BrowserVersion = "128.0";
                    chrome.PlatformName = "Windows 10";

                    Dictionary<string, object> chromeltOptions = new Dictionary<string, object>();
                    chromeltOptions.Add("username", LT_USERNAME);
                    chromeltOptions.Add("accessKey", LT_ACCESS_KEY);
                    chrome.AddAdditionalOption("LT:Options", chromeltOptions);
                    //return new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub/"), chrome);
                    return chrome.ToCapabilities();


                case "firefox":
                    FirefoxOptions firefox = new FirefoxOptions();
                    firefox.BrowserVersion = "130.0";
                    firefox.PlatformName = "Windows 11";

                    Dictionary<string, object> firefoxltOptions = new Dictionary<string, object>();
                    firefoxltOptions.Add("username", LT_USERNAME);
                    firefoxltOptions.Add("accessKey", LT_ACCESS_KEY);
                    firefox.AddAdditionalOption("LT:options", firefoxltOptions);

                    //return new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub/"), firefox);
                    return firefox.ToCapabilities();
                case "edge":

                    EdgeOptions edge = new EdgeOptions();
                    edge.BrowserVersion = "127.0";
                    edge.PlatformName = "macOS Ventura";
                    Dictionary<string, object> edgeltOptions = new Dictionary<string, object>();
                    edgeltOptions.Add("username", LT_USERNAME);
                    edgeltOptions.Add("accessKey", LT_ACCESS_KEY);
                    edge.AddAdditionalOption("LT:options", edgeltOptions);

                   // return new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub/"), edge);
                   return edge.ToCapabilities();

                case "Internet Explorer":
                    InternetExplorerOptions internetExplorer = new InternetExplorerOptions();
                    internetExplorer.BrowserVersion = "11.0";
                    internetExplorer.PlatformName = "Windows10";
                    Dictionary<string, object> ieltOptions = new Dictionary<string, object>();
                    ieltOptions.Add("username", LT_USERNAME);
                    ieltOptions.Add("accessKey", LT_ACCESS_KEY);
                    internetExplorer.AddAdditionalOption("LT:options", ieltOptions);

                   // return new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub/"), internetExplorer);
                   return internetExplorer.ToCapabilities();
                default:
                    throw new ArgumentException("Browser not found exception");
            }
        }
    }
}
