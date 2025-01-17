﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;


namespace Presentation
{
  
    public  class WA 
    {
        

       
        public static IWebDriver driver;
        public static IWebDriver driver2;
        
        public bool driverstate;
        public bool driverstate2;
        public bool clickstate = false;
        public int preventblocktiming = 0;
        public int preventblocktiming2 = 0;


        



        //WHATSAPP SELECTORS

        private static string actualuser = Environment.UserName;
        public static string AttachPath = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[4]/div[1]/footer[1]/div[1]/div[1]/span[2]/div[1]/div[1]/div[2]/div[1]/div[1]/span[1]";
        public static string ContactSearchBoxPath = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]";
        public static string ContactSearchIconPath = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/button[1]/div[2]/span[1]";
        public static string DocumentAttachFilePath = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[4]/div[1]/footer[1]/div[1]/div[1]/span[2]/div[1]/div[1]/div[2]/div[1]/span[1]/div[1]/div[1]/ul[1]/li[4]/button[1]/input[1]";
        public static string ImageAttachFilePath = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[4]/div[1]/footer[1]/div[1]/div[1]/span[2]/div[1]/div[1]/div[2]/div[1]/span[1]/div[1]/div[1]/ul[1]/li[1]/button[1]/input[1]";
        public static string MessageBoxPath = "//body/div[@id='app']/div[1]/div[1]/div[4]/div[1]/footer[1]/div[1]/div[1]/span[2]/div[1]/div[2]/div[1]/div[1]/div[1]/p[1]/span[1]";
        public static string ImageMessageBoxPath = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[2]/span[1]/div[1]/span[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/div[2]/div[1]/div[2]";
        public static string VideoMessageBoxPath = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[2]/span[1]/div[1]/span[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/div[2]";
        public static string ContactOrChatBoxPath = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[1]";
        public static string SendIADButton = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[2]/span[1]/div[1]/span[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[1]/span[1]";
        public static string LogOutButton = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[1]/header[1]/div[2]/div[1]/span[1]/div[3]/div[1]/span[1]";
        public static string GroupHeaderContent = "//header/div[2]/div[2]";

        //GOOGLE SMS SELECTORS

        public static string SMSContactTextBox = "/html[1]/body[1]/mw-app[1]/mw-bootstrap[1]/div[1]/main[1]/mw-main-container[1]/div[1]/mw-new-conversation-container[1]/mw-new-conversation-sub-header[1]/div[1]/div[2]/mw-contact-chips-input[1]/div[1]/mat-chip-listbox[1]/span[1]/input[1]";
        public static string SMSChatTextBox = "/html[1]/body[1]/mw-app[1]/mw-bootstrap[1]/div[1]/main[1]/mw-main-container[1]/div[1]/mw-conversation-container[1]/div[1]/div[1]/div[1]/mws-message-compose[1]/div[1]/div[2]/div[1]/mws-autosize-textarea[1]/textarea[1]";
        public static string SMSContactSearchIconPath = "/html[1]/body[1]/mw-app[1]/mw-bootstrap[1]/div[1]/main[1]/mw-main-container[1]/div[1]/mw-main-nav[1]/div[1]/mw-fab-link[1]/a[1]/span[2]";

        public async Task LaunchBrowser()
        {
            
            

            await Task.Run(() =>
            {
                try
                {
                    string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tempfilesWAButt\\Chrome WA Profile\\Default\\";

                    var service = ChromeDriverService.CreateDefaultService(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tempfilesWAButt\\webdriver\\");
                    service.HideCommandPromptWindow = true;
                    ChromeOptions options = new ChromeOptions();

                    options.AddArguments("user-data-dir=" + userProfile);
                    options.AddArguments("--window-size=850,650");
                    		


                    driver = new ChromeDriver(service, options)
                    {
                        Url = ("https://web.whatsapp.com/")
                        
                    };
                    /*
                    IWebElement html = driver.FindElement(By.TagName("html"));
                    Actions action = new Actions(WA.driver);
                      action.SendKeys(html,Keys.Control +Keys.Add).Build().Perform();
                      */
                    /*
                    ICapabilities capabilities = ((ChromeDriver)driver).Capabilities;
                  
                    
                    WriteJSONToFile(Regex.Replace
                        (Regex.Replace
                        ((capabilities.GetCapability("chrome") 
                        as Dictionary<string, object>)["chromedriverVersion"].ToString(),
                        @"\(.*?\)", ""), @"\s+", string.Empty), "chromeversion.txt");
                        */

                    driverstate = true;




                }
                catch (WebDriverException ex)
                {

                    MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                

        

            });







        }
        private void WriteJSONToFile(string data, string filename)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tempfilesWAButt";

            DirectoryInfo di = Directory.CreateDirectory(path);

            File.WriteAllText(path + "\\" + filename, data);

        }

        public async Task LaunchBrowser2()
        {



            await Task.Run(() =>
            {

                try {
                    string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"\\tempfilesWAButt\\Chrome SMS Profile\\Default\\";

                    var service = ChromeDriverService.CreateDefaultService(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +"\\tempfilesWAButt\\webdriver\\");
                    service.HideCommandPromptWindow = true;
                    ChromeOptions options = new ChromeOptions();

                    options.AddArguments("user-data-dir=" + userProfile);
                    options.AddArguments("--window-size=850,650");
                    //options.AddArguments("--incognito");
                    driver2 = new ChromeDriver(service, options)
                    {
                        Url = ("https://messages.google.com/web/conversations")
                        //Url = ("https://google.com")



                    };
               

                    driverstate2 = true;



                }
                catch (WebDriverException ex)
                {

                    MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            });







        }
        public void ClickSearchIcon()
        {
            WA.driver.FindElement(By.XPath(ContactSearchIconPath)).Click();
        }
        public void ClickSearchIcon2()
        {
            WA.driver2.FindElement(By.XPath(SMSContactSearchIconPath)).Click();
        }


        public void ContactSearch(string tosearch)
        {

            try
            {
                

                if (FindElement(driver, By.XPath(ContactSearchBoxPath), 20))
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;


                    string _script1 = "document.evaluate" +"('"+ ContactSearchBoxPath + "', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.innerHTML='" + tosearch + "'";
                    string _script2 = "document.evaluate" +"('"+ ContactSearchBoxPath + "', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.innerHTML='" + tosearch + "'";


                    string title2 = (string)js.ExecuteScript(_script2);
                    string title = (string)js.ExecuteScript(_script1);

                }

               


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }







        }
        public void ContactSearch2(string tosearch)
        {

            try
            {

                if (FindElement(driver2, By.XPath(SMSContactTextBox), 20))
                {
                    driver2.FindElement(By.XPath(SMSContactTextBox)).SendKeys(tosearch);

                }

               



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }







        }

        public void CloseWDriver()
        {

          
            if (driverstate)
            {
                try
                {
                    
                    driver.Quit();
                   
                    /*
                    Process[] _proceses = null;
                    _proceses = Process.GetProcessesByName("chromedriver");

                    if (_proceses.Length != 0)
                    {
                        foreach (Process proces in _proceses)
                        {
                            proces.Kill();
                        }
                    }*/
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }





            }



        }
        public void CloseWDriver2()
        {
            

            if (driverstate2)
            {
                try
                {


                    driver2.Quit();
                    /*
                    Process[] _proceses = null;
                    _proceses = Process.GetProcessesByName("chromedriver");

                    if (_proceses.Length != 0)
                    {
                        foreach (Process proces in _proceses)
                        {
                            proces.Kill();
                        }
                    }*/
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }





            }



        }
      
       


        
        public static bool FindElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
            


        }

        public void ContactClick()
        {

            

            Actions action = new Actions(driver);
           
            if (FindElement(driver, By.XPath(ContactOrChatBoxPath), 6))
            {
                clickstate = true;
                action.SendKeys(Keys.Enter).Build().Perform();
                Console.WriteLine("contact or group founded");

            }
            else
            {

                clickstate = false;
                Console.WriteLine("not founded contact o group");
                ClickSearchIcon();

            }


            //action.MoveToElement(driver.FindElement(By.XPath("//body//div[@id='pane-side']//div//div//div//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//span[1]"))).Click().Perform();



        }
        public void ContactClick2()
        {

           

            try
            {
                Actions action = new Actions(driver2);
                action.SendKeys(Keys.Enter).Build().Perform();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            
            

        }
        public void ContactMessage(string totype)
        {
            

            try
            {
                

                if (FindElement(driver,By.XPath(MessageBoxPath),20))
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                
                    string _script2 = "document.evaluate" +
                    "('"+MessageBoxPath+"', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.innerHTML='" + totype + "'";


                
                    string title = (string)js.ExecuteScript(_script2);

                   
                    
                }
                


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
        public void ContactMessage2(string totype)
        {

            try
            {
                

                if (FindElement(driver2, By.XPath(SMSChatTextBox), 20))
                {
                    driver2.FindElement(By.XPath(SMSChatTextBox)).SendKeys(totype);
                }
                   

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
        public void ImageTextMessage(string imagedir,string totype)
        {



            try
            {

          

                if (FindElement(driver, By.XPath(AttachPath), 10))
                {
                    driver.FindElement(By.XPath(AttachPath)).Click();

                    if (FindElement(driver, By.XPath(ImageAttachFilePath), 10))
                    {

                        IWebElement uploadElement = driver.FindElement(By.XPath(ImageAttachFilePath));
                        uploadElement.SendKeys(imagedir);



                        Task.Delay(1000 + preventblocktiming).Wait();


                        if (FindElement(driver, By.XPath(ImageMessageBoxPath), 10))
                        {

                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                            string _script2 = "document.evaluate" +
                            "(' " + ImageMessageBoxPath + "', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.innerHTML='" + totype + "'";



                            string title = (string)js.ExecuteScript(_script2);

                        }
                    }

                   


                   


                }


             



            }
            catch (Exception ex)
            {


                Console.WriteLine(ex.Message);
            }

        }
        public void VideoTextMessage(string imagedir, string totype)
        {



            try
            {



                if (FindElement(driver, By.XPath(AttachPath), 10))
                {
                    driver.FindElement(By.XPath(AttachPath)).Click();

                    if (FindElement(driver, By.XPath(ImageAttachFilePath), 10))
                    {

                        IWebElement uploadElement = driver.FindElement(By.XPath(ImageAttachFilePath));
                        uploadElement.SendKeys(imagedir);



                        Task.Delay(1000 + preventblocktiming).Wait();


                        if (FindElement(driver, By.XPath(VideoMessageBoxPath), 10))
                        {

                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                            string _script2 = "document.evaluate" +
                            "(' " + VideoMessageBoxPath + "', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.innerHTML='" + totype + "'";



                            string title = (string)js.ExecuteScript(_script2);

                        }
                    }







                }






            }
            catch (Exception ex)
            {


                Console.WriteLine(ex.Message);
            }

        }
        public void ImageMessage(string imagedir)
        {



            try
            {



                if (FindElement(driver, By.XPath(AttachPath), 10))
                {
                    driver.FindElement(By.XPath(AttachPath)).Click();

                    if (FindElement(driver, By.XPath(ImageAttachFilePath), 10))
                    {

                        IWebElement uploadElement = driver.FindElement(By.XPath(ImageAttachFilePath));
                        uploadElement.SendKeys(imagedir);



                       
                    }




                }






            }
            catch (Exception ex)
            {


                Console.WriteLine(ex.Message);
            }

        }
       
        public void ContactFile(string filedir)
        {



            try
            {

           

                if (FindElement(driver, By.XPath(AttachPath), 10))
                {
                    driver.FindElement(By.XPath(AttachPath)).Click();

                    if (FindElement(driver, By.XPath(DocumentAttachFilePath), 10))
                    {
                        IWebElement uploadElement = driver.FindElement(By.XPath(DocumentAttachFilePath));
                        uploadElement.SendKeys(filedir);

                    }
                    
                    Task.Delay(2000 + preventblocktiming).Wait();
                }
               


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
        public void ContactFileAudio(string audiodir)
        {



            try
            {

               

                if (FindElement(driver, By.XPath(AttachPath), 10))
                {
                    driver.FindElement(By.XPath(AttachPath)).Click();
                    

                    if (FindElement(driver, By.XPath(ImageAttachFilePath), 10))
                    {
                        IWebElement uploadElement = driver.FindElement(By.XPath(ImageAttachFilePath));


                        uploadElement.SendKeys(audiodir);
                    }

                        




                }

               

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

        }
        public void ContactSend(By by)
        {
            if (FindElement(driver, By.XPath(SendIADButton), 10))
            {


                try
                {
                    new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }



            }
            
           

        }
        public void ContactActionEnter()
        {
            

                try
                {
                    new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }




        }
        public void ContactActionEnter2()
        {
            try
            {
                new Actions(driver2).SendKeys(Keys.Enter).Build().Perform();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }


        }
        public  StringBuilder GetContactsFromGroup(string tosearch)
        {
            StringBuilder str = new StringBuilder();

            Actions action = new Actions(driver);


            driver.FindElement(By.XPath(ContactSearchIconPath)).Click();


            ContactSearch(tosearch);


            action.SendKeys(Keys.Space).Build().Perform();
            
            ContactClick();

      

            if (clickstate)
            {

                Task.Delay(5000).Wait();


               
                    IList<IWebElement> selectElements = driver.FindElements(By.XPath(GroupHeaderContent));



                    string[] allText = new string[selectElements.Count];

                    int a = 0;

                    foreach (IWebElement element in selectElements)
                    {
                        allText[a++] = element.Text;

                    }


                    str.Append("First Name,Mobile Phone");
                    str.AppendLine();
                    str.Append(",");
                    foreach (var item in allText)
                    {

                        str.Append(item.ToString());
                    }
           
                
               
            }



            return str;

            

        }
        private bool IfSizeError(By by)
        {

            try
            {

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(by);

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IfConnected(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IfConnected2(By by)
        {
            try
            {
                driver2.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        public bool IsBrowserClosed()
        {
            bool isClosed = false;

            try
            {
                string myTitle = driver.Title;
            }
            catch ( WebDriverException)
            {
                isClosed = true;
            }

            return isClosed;
        }
        public bool IsBrowserClosed2()
        {
            bool isClosed = false;

            try
            {
                string myTitle = driver2.Title;
            }
            catch (WebDriverException)
            {
                isClosed = true;
            }

            return isClosed;
        }
        public void  LogoutWA()
        {
            if (FindElement(WA.driver, By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[1]/header[1]/div[2]/div[1]/span[1]/div[3]/div[1]/span[1]"), 5))
            {

                driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[1]/header[1]/div[2]/div[1]/span[1]/div[3]/div[1]/span[1]")).Click();

                if (FindElement(driver, By.XPath(LogOutButton), 5))
                {

                    
                        driver.FindElement(By.XPath(LogOutButton)).Click();
                   

                }
            }
            

            
            
            

           

              


        }
    }
}
