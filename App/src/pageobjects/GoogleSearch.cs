using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace src 
{
    public class PageObject
    {
        WebDriver driver;
        public PageObject(WebDriver driver)
        {
            this.driver = driver;
            OpenQA.Selenium.Interactions.Actions action=new OpenQA.Selenium.Interactions.Actions(driver);
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(10));
        }
        
        //xml
        public static string GoogleSearch="/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input";
        public static string AllTab="/html/body/div[7]/div/div[4]/div/div[1]/div/div[1]/div/div[1]/span";
        public static string ImageTab="/html/body/div[7]/div/div[4]/div/div[1]/div/div[1]/div/div[5]/a";

        public void OpenGoogleURL()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
        }
        public void MoveToGoogleSearchtab()
        {   
            IWebElement GoogleSearchButton = driver.FindElement(By.XPath(GoogleSearch));
            OpenQA.Selenium.Interactions.Actions action=new OpenQA.Selenium.Interactions.Actions(driver);
            action.MoveToElement(GoogleSearchButton).Perform();
        }
        public void ClickOnGoogleSearchtab()
        {   
            IWebElement GoogleSearchButton = driver.FindElement(By.XPath(GoogleSearch));
            OpenQA.Selenium.Interactions.Actions action=new OpenQA.Selenium.Interactions.Actions(driver);
            action.Click(GoogleSearchButton).Perform();
        }
        public void SendKeysToGoogleSearchtab(string searchString)
        {   
            IWebElement GoogleSearchButton = driver.FindElement(By.XPath(GoogleSearch));
            OpenQA.Selenium.Interactions.Actions action=new OpenQA.Selenium.Interactions.Actions(driver);
            action.SendKeys(searchString).Perform();
            action.SendKeys(Keys.Enter).Perform();
        }
        public bool ValidateSearch()
        {   
            bool result=true;
            bool isAllTabAvailable = driver.FindElement(By.XPath(AllTab)).Displayed;
            OpenQA.Selenium.Interactions.Actions action=new OpenQA.Selenium.Interactions.Actions(driver);
            if(isAllTabAvailable)
            {
                return result;
            }
            else
            {
                return false;
            }
        }  
    }
}