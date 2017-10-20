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
        [Test]
        public void ContactModifyByDetails()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "Новое Имя1";
            newContact.Lastname = "Новая Фамилия1";

            app.Contacts
                .OpenDetails()
                .ClickModify()
                .UpdateContact(newContact);
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

            app.Contacts
                .OpenEditForm()
                .UpdateContact(newContact);
        }
    }
}
