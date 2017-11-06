﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
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
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("ModifiedGroup");
            newGroup.Header = null;
            newGroup.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldGroup = oldGroups[0];
            app.Groups.Modify(0,newGroup);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.ID == oldGroup.ID)
                {
                    Assert.AreEqual(newGroup.Name,group.Name);
                }
            }
            //app.Auth.Logout();
        }
    }
}
