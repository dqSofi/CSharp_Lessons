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
        [Test]
        public void DeleteFromHomePage()
        {
            //app.Contacts.Remove();
            app.Contacts
                .SelectContact()
                .DeleteContact()
                .SubmitContactDeletion();
        }

        [Test]
        public void DeleteThroughDetails()
        {
            //app.Contacts.Remove();
            app.Contacts
                .OpenDetails()
                .ClickModify()
                .ClickDelete();
        }

        [Test]
        public void DeleteThroughEdit()
        {
            //app.Contacts.Remove();
            app.Contacts
                .OpenEditForm()
                .ClickDelete();
        }
    }
}
