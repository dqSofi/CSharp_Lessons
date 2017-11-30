using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class RemovingContactFromGroupTests : AuthTestBase
    {
        [SetUp]
        public void CheckIfGroupExist()
        {
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(new GroupData("CreatedToBeChosen!"));
            }
        }

        [SetUp]
        public void CheckIfThereIsAContactInAGroup()
        {
            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> areInGroup = group.GetContactInGroup();
            if (areInGroup.Count()==0)
            {
               List<ContactData> areNotInGroup = ContactData.GetAllFromDB().Except(areInGroup).ToList();
               if (areNotInGroup.Count() == 0)
                {
                    app.Contacts.Create(new ContactData()
                    {
                        Firstname = "I will be",
                        Lastname = "In this group!"
                    });

                }
                ContactData contact = ContactData.GetAllFromDB().Except(areInGroup).First();
                app.Contacts.AddContactToGroup(contact, group);
            }

        }

        [Test]
        public void RemovingContactFromGroupTest()
        {
            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> oldList = group.GetContactInGroup();
            ContactData contact; // = ContactData.GetAllFromDB().Except(oldList).First();
            contact = oldList.First();
            /*try
            {
                contact = ContactData.GetAllFromDB().Except(oldList).First();
            }
            catch (System.InvalidOperationException)
            {
                System.Console.Out.WriteLine("все контакты уже состоят в выбранной группе");
                throw;
            }*/

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContactInGroup();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
