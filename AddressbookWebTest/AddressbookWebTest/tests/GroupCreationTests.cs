using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("BestGroup");
            group.Header = "header";
            group.Footer = "footer";

            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //app.Auth.Logout();
        }

        [Test]
        public void EmptyNameGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            //app.Auth.Logout();
        }   
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("d'a");
            group.Header = "sdfsdf";
            group.Footer = "sdfsf";

            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            //app.Auth.Logout();
        }
    }
}
