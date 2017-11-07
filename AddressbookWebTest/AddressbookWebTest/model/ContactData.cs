using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace WebAddressbookTests

{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
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
        public string allPhones;
        public string allEmails;

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ID { get; set; }
        public string Address { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones == null || allPhones == "")
                {
                    return "";
                }
                return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                    
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails == null || allEmails =="") 
                {
                    return "";
                }
                return NextLine(Email)+ NextLine(Email2) + NextLine(Email3);

            }
            set
            {
                allPhones = value;
            }
        }

        private string NextLine(string email)
        {
            if (email == null)
            {
                return "";
            }
            return email+"\r\n";

        }

        private string CleanUp(string phone)
        {
            if (phone == null)
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "");
            //phone.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "")+"\r\n";
        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        
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
