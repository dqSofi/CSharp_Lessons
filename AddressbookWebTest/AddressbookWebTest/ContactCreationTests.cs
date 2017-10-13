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
            navigator.GoToHomePage();
            loginout.Login(new AccountData("admin", "secret"));
            contactHelper.AddNewContact();
            ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";
            contactHelper.FillNewContactForm(newContact);
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToHomePage();
            loginout.Logout();
        }
    }
}

