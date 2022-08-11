using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using src;
using NUnit.Framework;

namespace Test
{
    public class TestGoogle
    {
        private WebDriver? driver;
        private PageObject? pageObj;
        
        [SetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions(); 
            options.BinaryLocation = @"/usr/bin/google-chrome";
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-setuid-sandbox");
            options.AddArgument("--remote-debugging-port=9222");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--headless");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu") ;
            options.AddArgument("start-maximized"); 
            options.AddArgument("disable-infobars");
            driver=new ChromeDriver(options);
            pageObj=new PageObject(driver);
        }

        [Test]
        public void Test()
        {
            pageObj?.OpenGoogleURL();
            pageObj?.MoveToGoogleSearchtab();
            pageObj?.ClickOnGoogleSearchtab();
            pageObj?.SendKeysToGoogleSearchtab("C# coding");
            bool? result=pageObj?.ValidateSearch();
            Assert.IsTrue(result,"Google Search Result NOT succesful");
        }

        [TearDown]
        public void CloseBrowser()
        {
            if(null != driver) driver.Quit();
        }
    }
}