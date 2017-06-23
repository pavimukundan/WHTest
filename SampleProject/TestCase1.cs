using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;


namespace WilliamHillHorseRacing

{
    
    static class BrowserLaunch
    {
        // To open in Chrome browser
        static IWebDriver driver = new ChromeDriver();
        


        [STAThread]
       static void Main(string[] args)
        {
            try
            {
                //To Maximize browser window
                driver.Manage().Window.Maximize();

                // To open URL in the browser
                driver.Url = System.Configuration.ConfigurationManager.AppSettings["WebURL"];

                String ExpectedUrl = "https://www.williamhill.com.au/";
                String ActualUrl = driver.Url;

                Assert.AreEqual(ExpectedUrl, ActualUrl, true, "URL didn't match");

                BrowserLaunch.QuickBet();
            }
            catch (AssertFailedException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                  }
        }


        private static void QuickBet()
        {
            //To find and click on 'Racing' option from left Navigation bar
            IWebElement Racing = driver.FindElement(By.XPath("//Span[text()='Racing']")); 
            Racing.Click();

            //To find and click on 'Horses' category under 'Racing'
            IWebElement Horses = driver.FindElement(By.XPath("//Span[text()='Horses']"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Horses.Click();

            //To look up for the next Available Race (with Best Tote available container) and click
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement AvailableRacing = driver.FindElement(By.XPath(".//div[@class='RacingHome_available_2vW RacingHome_bestTote_2Of']")); 
            AvailableRacing.Click();
            
            //To locate and click on Fav button
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement favButton = driver.FindElement(By.XPath("//button[@class = 'BetButton_betButton_C1F BetButton_favourite_2eI']"));
            favButton.Click();
            
            //To click on 50c stake value
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement QuickBetStake50c = driver.FindElement(By.XPath("//div[text()='+50c']"));
            QuickBetStake50c.Click();

            //To click on $10 stake value
            IWebElement QuickBetStake10dlrs = driver.FindElement(By.XPath("//div[text()='+$10']"));
            QuickBetStake10dlrs.Click();

            //To click on 'Add to Bet Slip' button
            IWebElement AddToBetSlip = driver.FindElement(By.XPath("//button[text()='Add to Bet Slip']"));
            AddToBetSlip.Click();

        }

    }
}
