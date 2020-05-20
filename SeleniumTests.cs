using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Cas30SeleniumTests
{
    class SeleniumTests
    {
        IWebDriver driver;
        WebDriverWait wait;

        private string Test_Data_Email = "perica@gmail.com";
        private string Test_Data_Pass = "Perica1979";
        private string Test_Data_User = "perica";

        string url = "http://shop.qa.rs/";
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test]
        [Category("SC")]
        public void TestRegistration()
        {
            IWebElement registerLink = wait.Until(EC.ElementIsVisible(By.XPath("//div[@class='col-sm-6 text-center'][2]/a")));
            if (registerLink.Displayed && registerLink.Enabled)
            {
                registerLink.Click();
            }

            try
            {
                IWebElement registerBtn = wait.Until(EC.ElementToBeClickable(By.Name("register")));
                if (registerBtn.Displayed && registerBtn.Enabled)
                {
                    IWebElement firstName = driver.FindElement(By.Name("ime"));
                    if (firstName.Displayed && firstName.Enabled)
                    {
                        firstName.SendKeys("Pera");
                    }

                    IWebElement lastName = driver.FindElement(By.Name("prezime"));
                    if (lastName.Displayed && lastName.Enabled)
                    {
                        lastName.SendKeys("Peric");
                    }

                    IWebElement email = driver.FindElement(By.Name("email"));
                    if (email.Displayed && email.Enabled)
                    {
                        email.SendKeys(Test_Data_Email);
                    }

                    IWebElement username = driver.FindElement(By.Name("korisnicko"));
                    if (username.Displayed && username.Enabled)
                    {
                        username.SendKeys(Test_Data_User);
                    }

                    IWebElement password = driver.FindElement(By.Name("lozinka"));
                    if (password.Displayed && password.Enabled)
                    {
                        password.SendKeys(Test_Data_Pass);
                    }

                    IWebElement passConfirm = driver.FindElement(By.Name("lozinkaOpet"));
                    if (passConfirm.Displayed && passConfirm.Enabled)
                    {
                        passConfirm.SendKeys(Test_Data_Pass);
                    }

                    registerBtn.Click();
                    Assert.Pass();
                }
            }catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Test]
        [Category("SC")]
        public void TestLogIn()
        {
            IWebElement loginLink = driver.FindElement(By.XPath("//ul[@class='nav navbar-nav navbar-right']/li/a"));
            if (loginLink.Displayed && loginLink.Enabled)
            {
                loginLink.Click();
            }

            try
            {
                IWebElement login = wait.Until(EC.ElementIsVisible(By.Name("login")));
                if (login.Displayed && login.Enabled)
                {

                    IWebElement loginUser = driver.FindElement(By.Name("username"));
                    if (loginUser.Displayed && loginUser.Enabled)
                    {
                        loginUser.SendKeys(Test_Data_User);
                    }

                    IWebElement loginPass = driver.FindElement(By.Name("password"));
                    if (loginPass.Displayed && loginPass.Enabled)
                    {
                        loginPass.SendKeys(Test_Data_Pass);
                    }
                    
                    login.Click();
                    Assert.Pass();
                }
            }catch (WebDriverTimeoutException)
            {
                Assert.Fail();
            }
        }
    }
}
