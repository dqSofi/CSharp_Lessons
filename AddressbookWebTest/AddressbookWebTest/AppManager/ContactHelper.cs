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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            //подозрительно
            ICollection<IWebElement> lastNames = driver.FindElements(By.XPath("//tr[@name='entry']/td[2]"));
            ICollection<IWebElement> firstNames = driver.FindElements(By.XPath("//tr[@name='entry']/td[3]"));
            List<IWebElement> l=lastNames.ToList();
            List<IWebElement> f= firstNames.ToList();
            for (int i=0;i < lastNames.Count; i++)
            {
                ContactData contact = new ContactData();
                contact.Firstname = f[i].Text;
                contact.Lastname = l[i].Text;
                contacts.Add(contact);
                //System.Console.WriteLine("FN " + contact.Firstname + " LN " + contact.Lastname);
            }
            return contacts;
        }

        public ContactHelper UpdateContact(ContactData newContact)
        {
            FillNewContactForm(newContact);
            ClickUpdate();
            return this;
        }

        public ContactHelper FillNewContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }


        //По 1 действию

        public bool IsContactExist()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
        }
        //driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
        //public bool IsGroupExist(int index) - поменяла на [1] вместо index
        //без индекса - чтобы хотя по умолчанию даже единственная группа будет первой, 
        //достаточно проверить наличие с индексом 1
  /*      public bool IsGroupExist()
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]"));
        }*/


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
            //сюда
            /*if (!IsElementPresent(By.XPath("img[alt=\"Details\"]")))
            {
                Create(new ContactData());
            }*/
            driver.FindElement(By.CssSelector("img[alt=\"Details\"]")).Click();
            return this;
        }

        public ContactHelper OpenEditForm()
        {
            //и сюда
            /*if (!IsElementPresent(By.XPath("img[alt=\"Edit\"]")))
            {
                Create(new ContactData());
            }*/
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
            //и сюда
            /*if (!IsElementPresent(By.XPath("//input[@type='checkbox']")))
            {
                Create(new ContactData());
            }*/
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
