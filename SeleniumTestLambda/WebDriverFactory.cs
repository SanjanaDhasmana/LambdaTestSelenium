using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using static System.Environment;

namespace SeleniumTestLambda
{
    public class WebDriverFactory
    {
        public ICapabilities browserCapabilities(string browserName)
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
                    chromeltOptions.Add("visual", true);
                    chromeltOptions.Add("video", true);
                    chromeltOptions.Add("network", true);
                    chrome.AddAdditionalOption("LT:Options", chromeltOptions);
                    return chrome.ToCapabilities();


                case "firefox":
                    FirefoxOptions firefox = new FirefoxOptions();
                    firefox.BrowserVersion = "130.0";
                    firefox.PlatformName = "Windows 11";

                    Dictionary<string, object> firefoxltOptions = new Dictionary<string, object>();
                    firefoxltOptions.Add("username", LT_USERNAME);
                    firefoxltOptions.Add("accessKey", LT_ACCESS_KEY);
                    firefoxltOptions.Add("visual", true);
                    firefoxltOptions.Add("video", true);
                    firefoxltOptions.Add("network", true);
                    firefox.AddAdditionalOption("LT:options", firefoxltOptions);
                    return firefox.ToCapabilities();
                case "edge":

                    EdgeOptions edge = new EdgeOptions();
                    edge.BrowserVersion = "127.0";
                    edge.PlatformName = "macOS Ventura";
                    Dictionary<string, object> edgeltOptions = new Dictionary<string, object>();
                    edgeltOptions.Add("username", LT_USERNAME);
                    edgeltOptions.Add("accessKey", LT_ACCESS_KEY);
                    edgeltOptions.Add("visual", true);
                    edgeltOptions.Add("video", true);
                    edgeltOptions.Add("network", true);
                    edge.AddAdditionalOption("LT:options", edgeltOptions);
                    return edge.ToCapabilities();

                case "internet explorer":
                    InternetExplorerOptions internetExplorer = new InternetExplorerOptions();
                    internetExplorer.BrowserVersion = "11.0";
                    internetExplorer.PlatformName = "Windows10";
                    Dictionary<string, object> ieltOptions = new Dictionary<string, object>();
                    ieltOptions.Add("username", LT_USERNAME);
                    ieltOptions.Add("accessKey", LT_ACCESS_KEY);
                    ieltOptions.Add("visual", true);
                    ieltOptions.Add("video", true);
                    ieltOptions.Add("network", true);
                    internetExplorer.AddAdditionalOption("LT:options", ieltOptions);
                    return internetExplorer.ToCapabilities();
                default:
                    throw new ArgumentException("Browser not found exception");
            }
        }
    }
}
