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

            app.Groups.Modify(1,newGroup);
            //app.Auth.Logout();
        }
    }
}
