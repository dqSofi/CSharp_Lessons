using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactInformationTests:AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromEditForm.AllEmails);
        }

        [Test]
        public void ContactDetailsTest()
        {
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            //для самопроверки
            //Console.WriteLine(fromDetails.AllDetails);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);
            //для самопроверки
            //Console.WriteLine("а дальше из формы редактирования");
            //Console.WriteLine(fromEditForm.AllDetails);

            Assert.AreEqual(fromDetails.AllDetails, fromEditForm.AllDetails);
        }
    }
}
