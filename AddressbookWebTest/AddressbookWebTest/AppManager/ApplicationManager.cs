using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        //устанавливает соответствие между текущим потоком и объектом типа апп менеджер
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        private ApplicationManager()
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

        //деструктор, всегда начинается с ~
        ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            //если для текущего потока внутри хранилища ничего не создано, то создать
            if (! app.IsValueCreated) 
            {
                ApplicationManager NewInstance = new ApplicationManager();
                NewInstance.Navigator.GoToHomePage();
                app.Value = NewInstance;
                                
            }
            return app.Value;
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
