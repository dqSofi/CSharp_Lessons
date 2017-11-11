using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData()
                {
                    Firstname = GenerateRandomString(30),
                    Lastname = GenerateRandomString(30),
                    Address = GenerateRandomString(100)
                });
            }
            return contact;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData newContact)
        {
            /*ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";*/

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Navigator.AddNewContact();
            app.Contacts.Create(newContact);
            Assert.AreEqual(oldContacts.Count + 1,app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }

        /*[Test]
        public void ContactEmptyNameCreationTest()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "";
            newContact.Lastname = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Navigator.AddNewContact();
            app.Contacts.Create(newContact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }*/

    }
}

