using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("ModifiedGroup");
            newGroup.Header = null;
            newGroup.Footer = null;

            app.Groups.Modify(1,newGroup);
            //app.Auth.Logout();
        }
    }
}
