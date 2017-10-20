﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";

            app.Navigator.AddNewContact();
            app.Contacts.Create(newContact);
            //app.Auth.Logout();
        }

        [Test]
        public void EmptyNameContactCreationTest()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "";
            newContact.Lastname = "";

            app.Navigator.AddNewContact();
            app.Contacts.Create(newContact);
            //app.Auth.Logout();
        }
    }
}

