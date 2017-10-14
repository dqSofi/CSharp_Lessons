using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;        

        protected LogInOutHelper loginout;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";

            loginout = new LogInOutHelper(this);
            navigator = new NavigationHelper(this,baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LogInOutHelper Auth
        {
            get
            {
                return loginout;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        
    }
}
