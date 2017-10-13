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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();
            ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";
            FillNewContactForm(newContact);
            SubmitContactCreation();
            ReturnToHomePage();
            Logout();
        }
    }
}

