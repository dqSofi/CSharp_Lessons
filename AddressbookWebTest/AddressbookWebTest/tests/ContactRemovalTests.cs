using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{

    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
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
        public void ContactDeleteFromHomePage()
        {
            //app.Contacts.Remove();
            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts
                .SelectContact(toBeRemoved.ID)
                .DeleteContact()
                .SubmitContactDeletion();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAllFromDB();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.ID, toBeRemoved.ID);
            }

        }

        [Test]
        public void ContactDeleteThroughDetails()
        {
            //app.Contacts.Remove();
            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts
                .OpenDetails(toBeRemoved.ID)
                .ClickModify()
                .ClickDelete();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAllFromDB();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.ID, toBeRemoved.ID);
            }
        }

        [Test]
        public void ContactDeleteThroughEdit()
        {
            //app.Contacts.Remove();
            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts
                .OpenEditForm(toBeRemoved.ID)
                .ClickDelete();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAllFromDB();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.ID, toBeRemoved.ID);
            }
        }
    }
}
