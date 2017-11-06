using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{

    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts
                .SelectContact()
                .DeleteContact()
                .SubmitContactDeletion();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void ContactDeleteThroughDetails()
        {
            //app.Contacts.Remove();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts
                .OpenDetails()
                .ClickModify()
                .ClickDelete();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactDeleteThroughEdit()
        {
            //app.Contacts.Remove();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts
                .OpenEditForm()
                .ClickDelete();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
