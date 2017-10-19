using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{

    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void DeleteFromHomePage()
        {
            //app.Contacts.Remove();
            app.Contacts.SelectContact();
            app.Contacts.DeleteContact();
            app.Contacts.SubmitContactDeletion();
        }

        [Test]
        public void DeleteThroughDetails()
        {
            //app.Contacts.Remove();
            app.Contacts.OpenDetails();
            app.Contacts.ClickModify();
            app.Contacts.ClickDelete();
        }

        [Test]
        public void DeleteThroughEdit()
        {
            //app.Contacts.Remove();
            app.Contacts.Edit();
            app.Contacts.ClickDelete();
        }
    }
}
