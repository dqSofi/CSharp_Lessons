using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;


namespace WebAddressbookTests

{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        //private string nickname = "";
        //photo
        //private string company = "";
        //private string fax = "";
        //private string homepage = "";
        //birthday
        //anniversary
        //group
        //private string address2 = "";
        //private string phone2 = "";
        //private string notes = "";
        
        public string allPhones;
        public string allEmails;
        public string allDetails;
        public string fio;

        [Column(Name = "id"),PrimaryKey,Identity]
        public string ID { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
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
                if (allEmails != null) 
                {
                    return allEmails;
                }
                else if((HomePhone!=null && HomePhone!="")||
                    (WorkPhone != null && WorkPhone != "" )||
                    (MobilePhone != null && MobilePhone != "") )
                {
                    return "\r\n" + (NextLine(Email) + NextLine(Email2) + NextLine(Email3)).Trim();
                }
                else
                {
                    return (NextLine(Email) + NextLine(Email2) + NextLine(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return (AddIfNotEmpty(NextLine(Fio)) // (Firstname + " " + Lastname)
                        + AddIfNotEmpty(NextLine(Address)+"\r\n") 
                        + AddIfNotEmpty(LetterForPhone(HomePhone))
                        + AddIfNotEmpty(LetterForPhone(MobilePhone))
                        + AddIfNotEmpty(LetterForPhone(WorkPhone))
                        + AddIfNotEmpty(AllEmails)).Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }

        //проверка на непустую строку - только в этом случае добавляется к allDetails
        public string AddIfNotEmpty(string stroka)
        {
            if (stroka == null || stroka == "")
            {
                return "";
            }
            return stroka;
        }

        public string Fio
        {
            get
            {
                if (fio != null)
                {
                    return fio;
                }
                else
                {
                    fio = fio + Firstname;
                    if (Middlename!="" && Middlename != null)
                    {
                        fio = fio + " " + Middlename;
                    };
                    if (Lastname != "" && Lastname != null)
                    {
                        fio = fio + " " + Lastname;
                    };
                    return fio;
                }
            }
            set
            {
                fio = value;
            }
        }
        
        

        
        //добавляет правильную большую букву перед непустым номером телефона
        private string LetterForPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else if (phone == HomePhone)
            {
                return "H: " + phone + "\r\n";
            }
            else if (phone == MobilePhone)
            {
                return "M: " + MobilePhone + "\r\n";
            }
            else if (phone == WorkPhone)
            {
                return "W: " + WorkPhone + "\r\n";
            }
            else return "";

        }

        private string NextLine(string stroka)
        {
            if (stroka == null || stroka == "")
            {
                return "";
            }
            return stroka+"\r\n";

        }

        private string CleanUp(string phone)
        {
            if (phone == null||phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "")+"\r\n";
            //phone.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "")+"\r\n";
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
            return Lastname.GetHashCode()+Firstname.GetHashCode();
            //поскольку это только сокращение - если сумма хэшей имени и фамилии не сойдется
            //то точно хотя бы одно из полей отличается. В случае равенства суммы хэшей
            //все равно будет подробное сравнение этих полей
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

        public override string ToString()
        {
            return "firstname=" + Firstname + "\nlastname=" + Lastname;
        }

        public static List<ContactData> GetAllFromDB()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00")
                        //where c.Deprecated == "0000-00-00 00:00:00"
                        select c).ToList();
            }
        }
    }
}
