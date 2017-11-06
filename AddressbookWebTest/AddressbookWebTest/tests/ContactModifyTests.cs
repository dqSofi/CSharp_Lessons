using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactModifyTests : AuthTestBase
    {
        [SetUp]
        public void CheckIfСontactExist()
        {
            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(new ContactData());
            }
        }

        [Test]
        public void ContactModifyByDetails()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "Новое Имя1";
            newContact.Lastname = "Новая Фамилия1";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts
                .OpenDetails()
                .ClickModify()
                .UpdateContact(newContact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname=newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactModifyByEdit()
        {
            //второй вариант инициализации
            ContactData newContact = new ContactData
            {
                Firstname = "Новое Имя2",
                Lastname = "Новая Фамилия2"
            };

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts
                .OpenEditForm()
                .UpdateContact(newContact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
