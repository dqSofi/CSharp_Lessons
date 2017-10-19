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
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        //Высокоуровневые
        public ContactHelper Create(ContactData newContact)
        {
            manager.Navigator.AddNewContact();
            FillNewContactForm(newContact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        /*
public ContactHelper Remove()
{
   SelectContact();
   DeleteContact();
   SubmitContactDeletion();
   return this;
}
*/

        public ContactHelper FillNewContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        //По 1 действию

        public ContactHelper ClickDelete()
        {
            //driver.FindElement(By.XPath("(//input[@value='Delete'])"));
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            return this;
        }

        public ContactHelper ClickUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ClickModify()
        {
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public ContactHelper OpenDetails()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Details\"]")).Click();
            return this;
        }

        public ContactHelper Edit()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactDeletion()
        {
            driver.SwitchTo().Alert().Accept();
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact()
        { 
            driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
    }
}
