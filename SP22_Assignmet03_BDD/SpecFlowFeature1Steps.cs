using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SP22_Assignmet03_BDD
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        IWebDriver driver = new ChromeDriver();

        [Given(@"I have entered FirstName in the (.*) field")]
        public void GivenIHaveEnteredFirstNameInTheField(string FirstName)
        {
            
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/automation-practice-form";
            driver.FindElement(By.Id("firstName")).SendKeys(FirstName);
        }
        
        [Given(@"I have entered LastName in the (.*) field")]
        public void GivenIHaveEnteredLastNameInTheField(string LastName)
        {
            driver.FindElement(By.Id("lastName")).SendKeys(LastName);

        }

        [Given(@"I have entered Email in the (.*) field")]
        public void GivenIHaveEnteredEmailInTheField(string Email)
        {
            IWebElement element = driver.FindElement(By.Id("userEmail"));
            element.SendKeys(Email);
            string isEmailRequired = element.GetAttribute("Required");
        }

        [Given(@"I have selected my Gender")]
        public void GivenIHaveSelectedMyGender()
        {
            driver.FindElement(By.CssSelector("#genterWrapper > div.col-md-9.col-sm-12 > div:nth-child(2)")).Click();
        }

        [Given(@"I have entered MobileNumber in the (.*) field")]
        public void GivenIHaveEnteredMobileNumberInTheField(string MobileNumber)
        {
            IWebElement element1 = driver.FindElement(By.Id("userNumber"));
            element1.SendKeys(MobileNumber);
            string isMobNumEntered = element1.GetAttribute("required");
        }

        [Given(@"I have selected my DOB from the date picker")]
        public void GivenIHaveSelectedMyDOBFromTheDatePicker()
        {
            driver.FindElement(By.Id("dateOfBirthInput")).Click();
            var month = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            var selectMonth = new SelectElement(month);
            selectMonth.SelectByText("September");
            var year = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            var selectYear = new SelectElement(year);
            selectYear.SelectByText("1996");
            driver.FindElement(By.CssSelector("#dateOfBirth > div.react-datepicker__tab-loop > div.react-datepicker-popper > div > div > div.react-datepicker__month-container > div.react-datepicker__month > div:nth-child(1) > div.react-datepicker__day.react-datepicker__day--001")).Click();
        }
        
        [Given(@"I have selected Subject to study")]
        public void GivenIHaveSelectedSubjectToStudy()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");

            var subject = driver.FindElement(By.Id("subjectsInput"));
            subject.SendKeys("English");
            // subject.SendKeys("English , Computer Science"); FORM GETTING SUBMITTED??
            subject.SendKeys(Keys.ArrowDown);
            subject.SendKeys(Keys.Enter);
            subject.SendKeys("Maths");
            subject.SendKeys(Keys.ArrowDown);
            subject.SendKeys(Keys.Enter);
        }
        
        [Given(@"I have selected my Hobbies")]
        public void GivenIHaveSelectedMyHobbies()
        {
            driver.FindElement(By.CssSelector("#hobbiesWrapper > div.col-md-9.col-sm-12 > div:nth-child(3) > label")).Click();
        }

        [Given(@"I have uploaded my Picture")]
        public void GivenIHaveUploadedMyPicture()
        {
            driver.FindElement(By.Id("uploadPicture")).SendKeys("C:\\Users\\faroosaf\\Downloads\\methodology.png");
        }
        
        [Given(@"I have entered CurrentAddress in the (.*) field")]
        public void GivenIHaveEnteredCurrentAddressInTheField(string CurrentAddress)
        {
            driver.FindElement(By.Id("currentAddress")).SendKeys(CurrentAddress);
        }

        [Given(@"I have selected my State")]
        public void GivenIHaveSelectedMyState()
        {
            // To zoom out 3 times
            ((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.transform='scale(0.6)';");

            //JavascriptExecutor js = (JavascriptExecutor) driver;
            //js.executeScript(“document.body.style.zoom =’” +level + “%’”);
            
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => d.FindElement(By.XPath("//input[@id='react-select-3-input']"))).SendKeys("NCR");
            //new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => d.FindElement(By.XPath("")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => d.FindElement(By.XPath("//input[@id='react-select-3-input']"))).SendKeys(Keys.Enter);
        }
        
        [Given(@"I have selected my City")]
        public void GivenIHaveSelectedMyCity()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => d.FindElement(By.XPath("//input[@id='react-select-4-input']"))).SendKeys("Delhi");
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => d.FindElement(By.XPath("//input[@id='react-select-4-input']"))).SendKeys(Keys.Enter);
        }
        
        [When(@"I click the Sumit button")]
        public void WhenIClickTheSumitButton()
        {
            driver.FindElement(By.Id("submit")).Click();
        }

        [Then(@"Validation (.*) should be displayed")]
        public void ThenValidationShouldBeDisplayed(string Message)
        {
            try
            {
                string text = driver.FindElement(By.CssSelector("#example-modal-sizes-title-lg")).Text;
                Assert.AreEqual(text, "Thanks for submitting the form");
            }
            catch
            {
                string text = driver.FindElement(By.CssSelector("#app > div > div > div.pattern-backgound.playgound-header > div")).Text;
                Assert.AreEqual(text, "Practice Form");

            }

            driver.Close();
        }
    }
}
