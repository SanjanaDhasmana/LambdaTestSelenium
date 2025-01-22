using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestLambda
{
    public class Tests
    {
        IWebDriver driver;
        string hubUrl = "https://hub.lambdatest.com/wd/hub/";
        WebDriverFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new WebDriverFactory();
            string browsername = TestContext.CurrentContext.Test.Arguments[0].ToString();
            driver = new RemoteWebDriver(new Uri(hubUrl), factory.browserCapabilities(browsername));
            //driver = new ChromeDriver();
        }

        [Test]
        [TestCase("chrome")]
        [TestCase("firefox")]
        [TestCase("edge")]
        [TestCase("internet explorer")]
        public void Scenario1(string browser)
        {
            Console.WriteLine("Browse name is " + TestContext.CurrentContext.Test.Arguments[0].ToString());
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
            Assert.That(inputText, Is.EqualTo(inputtedText.Text));
        }

        [Test]
        [TestCase("chrome")]
        [TestCase("firefox")]
        [TestCase("edge")]
        [TestCase("internet explorer")]
        public void Scenario2(string browser)
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/");
            IWebElement dndSliderLink = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/section[2]/div/ul/li[13]/a"));
            dndSliderLink.Click();

            IWebElement slider = driver.FindElement(By.XPath("//*[@id=\"slider3\"]/div/input"));

            int desiredValue = 95;
            int sliderWidth = slider.Size.Width;
            Console.WriteLine(sliderWidth.ToString());

            Actions action = new Actions(driver);
            action.ClickAndHold(slider).MoveByOffset(215, 0).Perform();
            Thread.Sleep(3000);

            IWebElement selectedRange = driver.FindElement(By.XPath("//*[@id=\"rangeSuccess\"]"));

            Console.WriteLine(selectedRange.Text);
            Assert.That("95", Is.EqualTo(selectedRange.Text));
        }

        [Test]
        [TestCase("chrome")]
        [TestCase("firefox")]
        [TestCase("edge")]
        [TestCase("internet explorer")]
        public void Scenario3(string browser)
        {
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/");

            IWebElement inputFormSubmitLink = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/section[2]/div/ul/li[20]/a"));
            inputFormSubmitLink.Click();

            IWebElement nameTxtBox = driver.FindElement(By.XPath("//*[@id=\"name\"]"));
            IWebElement submitBtn = driver.FindElement(By.XPath("//*[@id=\"seleniumform\"]/div[6]/button"));
            submitBtn.Click();

            String tooltip = driver.FindElement(By.XPath("//*[@id=\"name\"]")).GetAttribute("validationMessage");

            Console.WriteLine(tooltip);

            Assert.That("Please fill out this field.", Is.EqualTo(tooltip));


            IWebElement emailTxtBox = driver.FindElement(By.XPath("//*[@id=\"inputEmail4\"]"));
            IWebElement pswdTxtBox = driver.FindElement(By.XPath("//*[@id=\"inputPassword4\"]"));
            IWebElement companyTxtBox = driver.FindElement(By.XPath("//*[@id=\"company\"]"));
            IWebElement websiteTxtBox = driver.FindElement(By.XPath("//*[@id=\"websitename\"]"));
            IWebElement cityTxtBox = driver.FindElement(By.XPath("//*[@id=\"inputCity\"]"));
            IWebElement Addr1TxtBox = driver.FindElement(By.XPath("//*[@id=\"inputAddress1\"]"));
            IWebElement Addr2TxtBox = driver.FindElement(By.XPath("//*[@id=\"inputAddress2\"]"));
            IWebElement StateTxtBox = driver.FindElement(By.XPath("//*[@id=\"inputState\"]"));
            IWebElement zipCodeTxtBox = driver.FindElement(By.XPath("//*[@id=\"inputZip\"]"));
            IWebElement countryTxtBox = driver.FindElement(By.XPath("//*[@id=\"seleniumform\"]/div[3]/div[1]/select"));

            nameTxtBox.SendKeys("LambdaTest");
            emailTxtBox.SendKeys("labd@gmail.com");
            pswdTxtBox.SendKeys("lambda");
            companyTxtBox.SendKeys("lambda");
            websiteTxtBox.SendKeys("lambda");
            cityTxtBox.SendKeys("Chicago");
            Addr1TxtBox.SendKeys("F 145");
            Addr2TxtBox.SendKeys("Bouvelard ");
            StateTxtBox.SendKeys("Chicago");
            zipCodeTxtBox.SendKeys("124578");

            SelectElement selectCountry = new SelectElement(countryTxtBox);
            selectCountry.SelectByText("United States");
            submitBtn.Click();
            Thread.Sleep(2000);
            IWebElement successMessage = driver.FindElement(By.XPath("//p[@class='success-msg hidden']"));

            Console.WriteLine(successMessage.Text);
            Assert.That(successMessage.Text, Is.EqualTo("Thanks for contacting us, we will get back to you shortly."));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}