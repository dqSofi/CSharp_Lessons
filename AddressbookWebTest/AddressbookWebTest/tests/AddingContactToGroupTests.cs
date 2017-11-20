using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class AddingContactToGroupTests : AuthTestBase
    {
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
