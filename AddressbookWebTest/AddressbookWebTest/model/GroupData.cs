using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]


    public class GroupData :IEquatable<GroupData>,IComparable<GroupData>
    {
        public GroupData()
        {
        }

        public GroupData (string name)
        {
            Name = name;
        }
        [Column(Name = "group_name")]
        public String Name { get; set; }
        [Column(Name = "group_header")]
        public String Header { get; set; }
        [Column(Name = "group_footer")]
        public String Footer { get; set; }
        [Column(Name = "group_id"),PrimaryKey,Identity]
        public String ID { get; set; }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))//это стандартная проверка
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))//вторая стандартная проверка
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode() // для оптимизации, не совпали хэш коды - точно разные объекты,
                                //совпали - можно и в equals сравнить
        {
            //return 0; без оптимизации, всегда смотреть в equals
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name="+Name + "\nheader="+Header+"\nfooter="+Footer;
        }

        // CompareTo returns 
        //1 - если текущий объект this больше по нашему правилу сравнения
        //0 - если объекты равны
        //-1 - если this меньше чем other


        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public static List<GroupData> GetAllFromDB()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public  List<ContactData> GetContactInGroup()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupID == ID && p.ContactID == c.ID && c.Deprecated== "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }
}
