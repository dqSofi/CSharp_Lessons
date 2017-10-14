﻿using System;
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
            ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";

            app.Contacts
                .AddNewContact()
                .FillNewContactForm(newContact)
                .SubmitContactCreation()
                .ReturnToHomePage();
            app.Auth.Logout();
        }

        [Test]
        public void EmptyNameContactCreationTest()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";

            app.Contacts
                .AddNewContact()
                .FillNewContactForm(newContact)
                .SubmitContactCreation()
                .ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}

