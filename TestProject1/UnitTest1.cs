using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal.Execution;
using NUnit.Framework;

namespace JobApplication
{
    public class Tests
    {
        IWebDriver driver;
        string username = "vinhle@gmail.com";
        string password = "123456789";
        [SetUp]
        public void Setup()
        {
            //Launch browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            options.AddArgument("start-maximized");

            //navigate
            driver.Url = "http://localhost:5208/";
            driver.Navigate();

        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void ValidJobApplication()
        {

            // 1. Người dùng mở giao diện đăng nhập
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"navbarCollapse\"]/div[2]/div[1]/a")).Click();

            // 2. Nhập thông tin tài khoản đã đăng ký
            driver.FindElement(By.XPath("//*[@id=\"username\"]")).SendKeys(username);
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys(password);

            // 3. Nhấp vào nút đăng nhập
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();

            // 4. Nhấn xem công việc ở trang chủ
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"tab-1\"]/div[1]/div/div/div/a")).Click();

            // 5. Nhấn ứng tuyển ngay
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[1]/form/div/div/a")).Click();

            // 6. Tải CV và Cover Letter
            string CVfilePath = @"D:\\Downloads\\CV\\Thai Gia Bao - CV.docx";
            driver.FindElement(By.XPath("//*[@id=\"Cv\"]")).SendKeys(CVfilePath);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"CoverLetter\"]")).SendKeys(CVfilePath);

            // 7. Nhấn Gửi
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div[4]/button")).Click();


            Assert.Pass();
        }

        [Test]
        public void JobApplicationExpectCV()
        {
            // 1.Người dùng mở giao diện đăng nhập
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"navbarCollapse\"]/div[2]/div[1]/a")).Click();

            //2. Nhập thông tin tài khoản đã đăng ký
            driver.FindElement(By.XPath("//*[@id=\"username\"]")).SendKeys(username);
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys(password);

            //3. Nhấp vào nút đăng nhập
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();

            //4. Nhấn xem công việc ở trang chủ
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"tab-1\"]/div[1]/div/div/div/a")).Click();

            //5. Nhấn ứng tuyển ngay
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[1]/form/div/div/a")).Click();

            //6.Tải Cover Letter
            string CVfilePath = @"D:\Downloads\CV\Thai Gia Bao - CV.docx";
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"CoverLetter\"]")).SendKeys(CVfilePath);


            //7. Nhấn Gửi
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div[4]/button")).Click();

            IWebElement errorText = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div[1]/span"));
            Assert.That(errorText.Text == "The Cv field is required.");
        }

        [Test]
        public void JobApplicationExpectCoverLetter()
        {
            // 1.Người dùng mở giao diện đăng nhập
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"navbarCollapse\"]/div[2]/div[1]/a")).Click();

            //2. Nhập thông tin tài khoản đã đăng ký
            driver.FindElement(By.XPath("//*[@id=\"username\"]")).SendKeys(username);
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys(password);

            //3. Nhấp vào nút đăng nhập
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();

            //4. Nhấn xem công việc ở trang chủ
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"tab-1\"]/div[1]/div/div/div/a")).Click();

            //5. Nhấn ứng tuyển ngay
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[1]/form/div/div/a")).Click();

            //6.Tải CV
            string CVfilePath = @"D:\Downloads\CV\Thai Gia Bao - CV.docx";
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"Cv\"]")).SendKeys(CVfilePath);


            //7. Nhấn Gửi
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div[4]/button")).Click();

            IWebElement errorText = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div[2]/span"));
            Assert.That(errorText.Text == "The CoverLetter field is required.");

        }

        [Test]
        public void JobApplicationExpectCVnCoverLetter()
        {
            // 1.Người dùng mở giao diện đăng nhập
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"navbarCollapse\"]/div[2]/div[1]/a")).Click();

            //2. Nhập thông tin tài khoản đã đăng ký
            driver.FindElement(By.XPath("//*[@id=\"username\"]")).SendKeys(username);
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys(password);

            //3. Nhấp vào nút đăng nhập
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div/form/input[1]")).Click();

            //4. Nhấn xem công việc ở trang chủ
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"tab-1\"]/div[1]/div/div/div/a")).Click();

            //5. Nhấn ứng tuyển ngay
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[1]/form/div/div/a")).Click();


            //6. Nhấn Gửi
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div[4]/button")).Click();

            IWebElement errorText1 = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div[1]/span"));
            Assert.That(errorText1.Text == "The Cv field is required.");
            IWebElement errorText2 = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[2]/form/div[2]/span"));
            Assert.That(errorText2.Text == "The CoverLetter field is required.");

        }

    }
}