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
        [Test]
        public void ContactCreationTest()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Navigator.AddNewContact();
            app.Contacts.Create(newContact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }

        [Test]
        public void EmptyNameContactCreationTest()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "";
            newContact.Lastname = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Navigator.AddNewContact();
            app.Contacts.Create(newContact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }

    }
}

