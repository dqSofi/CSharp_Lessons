using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Groups.Remove(1);
            //app.Auth.Logout();
        }
    }
}
