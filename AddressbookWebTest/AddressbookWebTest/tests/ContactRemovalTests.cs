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
            app.Contacts
                .SelectContact()
                .DeleteContact()
                .SubmitContactDeletion();
        }

        [Test]
        public void ContactDeleteThroughDetails()
        {
            //app.Contacts.Remove();
            app.Contacts
                .OpenDetails()
                .ClickModify()
                .ClickDelete();
        }

        [Test]
        public void ContactDeleteThroughEdit()
        {
            //app.Contacts.Remove();
            app.Contacts
                .OpenEditForm()
                .ClickDelete();
        }
    }
}
