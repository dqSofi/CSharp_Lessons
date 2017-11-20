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
