using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class AddingContactToGroupTests : AuthTestBase
    {
        [SetUp]
        public void CheckIfСontactExist()
        {
            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(new ContactData() {
                Firstname="I was born",
                Lastname = "To be added to the group"} );
            }
        }

        [SetUp]
        public void CheckIfGroupExist()
        {
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(new GroupData("CreatedToBeChosen!"));
            }
        }

        [SetUp]
        public void CheckIfConactIsInAllGroups()
        {
            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> areInGroup = group.GetContactInGroup();
            List<ContactData> allExisting = ContactData.GetAllFromDB();
            if (areInGroup.Count() == allExisting.Count()){
                app.Contacts.Create(new ContactData()
                {
                    Firstname = "I am",
                    Lastname = "The Chosen One"
                });
            }
            
        }

        [Test]
        public void AddingContactToGroupTest()
        {
            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> oldList = group.GetContactInGroup();
            ContactData contact; // = ContactData.GetAllFromDB().Except(oldList).First();
            contact = ContactData.GetAllFromDB().Except(oldList).First();
            /*try
            {
                contact = ContactData.GetAllFromDB().Except(oldList).First();
            }
            catch (System.InvalidOperationException)
            {
                System.Console.Out.WriteLine("все контакты уже состоят в выбранной группе");
                throw;
            }*/
            
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContactInGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
