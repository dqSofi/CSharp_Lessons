﻿using System;
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData()
            {
                Firstname = firstName,
                Lastname = lastName,
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupToRemoveFrom(group.Name);
            SelectContact(contact.ID);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void SelectGroupToRemoveFrom(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.ID);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenDetails(0);
            string cells = driver.FindElement(By.Id("content")).Text;

            return new ContactData()
            {
                AllDetails = cells
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenEditForm(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData()
            {
                Firstname = firstName,
                Middlename = middlename,
                Lastname = lastName,
                Address = address,
                HomePhone = home,
                MobilePhone = mobile,
                WorkPhone = work,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

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

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                //новый
                IList<IWebElement> lines = driver.FindElement(By.Id("maintable"))
                    .FindElements(By.Name("entry"));
               
                foreach (IWebElement line in lines)
                {
                    ContactData contact = new ContactData();
                    contact.Lastname = line.FindElement(By.XPath("./td[2]")).Text;
                    contact.Firstname = line.FindElement(By.XPath("./td[3]")).Text;
                    contact.ID = line.FindElement(By.XPath("./td[1]/input")).GetAttribute("id");
                    contactCache.Add(contact);
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
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
            contactCache = null;
            return this;
        }

        public ContactHelper ClickUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ClickModify()
        {
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public ContactHelper OpenDetails(int index)
        {
            //сюда
            /*if (!IsElementPresent(By.XPath("img[alt=\"Details\"]")))
            {
                Create(new ContactData());
            }*/
            /*driver.FindElement(By.CssSelector("img[alt=\"Details\"]")).Click();*/
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        
        public ContactHelper OpenDetails(string id)
        {
            //сюда
            /*if (!IsElementPresent(By.XPath("img[alt=\"Details\"]")))
            {
                Create(new ContactData());
            }*/
            /*driver.FindElement(By.CssSelector("img[alt=\"Details\"]")).Click();*/
            //driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();

            /*contact.Lastname = line.FindElement(By.XPath("./td[2]")).Text;
            contact.Firstname = line.FindElement(By.XPath("./td[3]")).Text;*
            contact.ID = line.FindElement(By.XPath("./td[1]/input")).GetAttribute("id");*/

            driver.FindElement(By.XPath("(//input[@name='selected[]' and @id='" + id + "']/../..)"))
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            
            return this;
        }

        //public ContactHelper OpenEditForm()
        public ContactHelper OpenEditForm(int index)
        {
            //и сюда
            /*if (!IsElementPresent(By.XPath("img[alt=\"Edit\"]")))
            {
                Create(new ContactData());
            }*/
            //driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;

        }

        public ContactHelper OpenEditForm(string id)
        {
            //и сюда
            /*if (!IsElementPresent(By.XPath("img[alt=\"Edit\"]")))
            {
                Create(new ContactData());
            }*/
            //driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @id='" + id + "']/../..)"))
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;

        }

        public ContactHelper SubmitContactDeletion()
        {
            driver.SwitchTo().Alert().Accept();
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCache = null;
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
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

        public ContactHelper SelectContact(string id)
        {
            //driver.FindElement(By.XPath("//input[@type='checkbox' and @id ='" + id + "']")).Click();
            driver.FindElement(By.Id(id)).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
    }
}
