using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.AddNewContact();
            ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";
            app.Contacts.FillNewContactForm(newContact);
            app.Contacts.SubmitContactCreation();
            app.Contacts.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}

