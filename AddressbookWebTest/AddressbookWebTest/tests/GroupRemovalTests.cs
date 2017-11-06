using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
    [SetUp]
    public void CheckIfGroupExist()
        {
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(new GroupData("CreatedToBeChosen!"));
            }
        }
            
    [Test]
        public void GroupRemovalTest()
        {
            //app.Groups.IsGroupExist(1);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);//удалаемую группу помещаем в переменную, чтобы сравнить после удаления
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.ID, toBeRemoved.ID);
            }
            //app.Auth.Logout();
        }
    }
}
