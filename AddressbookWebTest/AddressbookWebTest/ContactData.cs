using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        private string middlename = "";
        private string nickname = "";
        //photo
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        //birthday
        //anniversary
        //group
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";

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
    }
}
