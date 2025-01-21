using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestLambda
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
             driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/");

            IWebElement simpleFormDemoLink = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/section[2]/div/ul/li[34]/a"));
            simpleFormDemoLink.Click();

            string expected = "simple-form-demo";
            string actual = driver.Url;

            Assert.IsTrue(actual.Contains(expected));

            string inputText = "Welcome to LambdaTest";
            IWebElement enterMessageTxtBox = driver.FindElement(By.XPath("//input[@id=\"user-message\"]"));
            enterMessageTxtBox.SendKeys(inputText);

            IWebElement getCheckedValueBtn = driver.FindElement(By.XPath("//button[@id=\"showInput\"]"));
            getCheckedValueBtn.Click();

            IWebElement inputtedText = driver.FindElement(By.XPath("//*[@id=\"message\"]"));
            Assert.That(inputText,Is.EqualTo(inputtedText.Text));


        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}