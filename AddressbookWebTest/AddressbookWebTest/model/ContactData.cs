using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAddressbookTests

{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        //private string middlename = "";
        //private string nickname = "";
        //photo
        //private string title = "";
        //private string company = "";
        //private string address = "";
        //private string home = "";
        //private string mobile = "";
        //private string work = "";
        //private string fax = "";
        //private string email = "";
        //private string email2 = "";
        //private string email3 = "";
        //private string homepage = "";
        //birthday
        //anniversary
        //group
        //private string address2 = "";
        //private string phone2 = "";
        //private string notes = "";

        public string Firstname
        {
            get => firstname;
            set => firstname = value;
        }
        public string Lastname
        {
            get => lastname;
            set => lastname = value;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))//это стандартная проверка
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))//вторая стандартная проверка
            {
                return true;
            }
            return (Firstname == other.Firstname)&&(Lastname==other.Lastname);
        }

        public override int GetHashCode() // для оптимизации, не совпали хэш коды - точно разные объекты,
                                          //совпали - можно и в equals сравнить
        {
            //return 0; без оптимизации, всегда смотреть в equals
            return Lastname.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname)==0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }
    }
}
