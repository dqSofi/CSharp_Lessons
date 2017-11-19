using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i =0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach  (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) //приведение типа
                new XmlSerializer(typeof(List<GroupData>)) //возвращает абстрактный объект
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            /*GroupData group = new GroupData("BestGroup");
            group.Header = "header";
            group.Footer = "footer";
            */
            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAllFromDB();
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
            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAllFromDB();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            //app.Auth.Logout();
        }
        /*[Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> ftomUI = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> ftomDB = GroupData.GetAllFromDB();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }*/
    }
}
