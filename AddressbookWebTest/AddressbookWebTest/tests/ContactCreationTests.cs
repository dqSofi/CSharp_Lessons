using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData()
                {
                    Firstname = GenerateRandomString(30),
                    Lastname = GenerateRandomString(30),
                    Address = GenerateRandomString(100)
                });
            }
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contact = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contact.Add(new ContactData()
                {
                    Firstname = parts[0],
                    Lastname = parts[1],
                    Address = parts[2]
                });
            }
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>) //приведение типа
                new XmlSerializer(typeof(List<ContactData>)) //возвращает абстрактный объект
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromCsvFile")]
        public void ContactCreationTest(ContactData newContact)
        {
            /*ContactData newContact = new ContactData();
            newContact.Firstname = "Имя";
            newContact.Lastname = "Фамилия";*/

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Navigator.AddNewContact();
            app.Contacts.Create(newContact);
            Assert.AreEqual(oldContacts.Count + 1,app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }

        /*[Test]
        public void ContactEmptyNameCreationTest()
        {
            ContactData newContact = new ContactData();
            newContact.Firstname = "";
            newContact.Lastname = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Navigator.AddNewContact();
            app.Contacts.Create(newContact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }*/

        [Test]
        public void ContactTestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> ftomUI = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> ftomDB = ContactData.GetAllFromDB();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }

    }
}

