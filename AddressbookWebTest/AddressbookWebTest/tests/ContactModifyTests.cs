using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactModifyTests : ContactTestBase
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
            ContactData oldContact = oldContacts[0];
            app.Contacts
                .OpenDetails(0)
                .ClickModify()
                .UpdateContact(newContact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname=newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.ID == oldContact.ID)
                {
                    Assert.AreEqual(newContact.Lastname, contact.Lastname);
                    Assert.AreEqual(newContact.Firstname, contact.Firstname);
                }
            }
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
            ContactData oldContact = oldContacts[0];
            app.Contacts
                .OpenEditForm(0)
                .UpdateContact(newContact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.ID == oldContact.ID)
                {
                    Assert.AreEqual(newContact.Lastname, contact.Lastname);
                    Assert.AreEqual(newContact.Firstname, contact.Firstname);
                }
            }
        }
    }
}
