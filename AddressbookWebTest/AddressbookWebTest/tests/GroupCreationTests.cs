using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("BestGroup");
            group.Header = "header";
            group.Footer = "footer";

            app.Navigator.GoToGroupsPage();
            app.Groups.Create(group);
            app.Auth.Logout();
        }

        [Test]
        public void EmptyNameGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Navigator.GoToGroupsPage();
            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }
}
