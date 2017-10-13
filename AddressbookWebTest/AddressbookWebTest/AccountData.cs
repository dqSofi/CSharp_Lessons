using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AccountData
    {
        private String username;
        private String password;

        public AccountData(string username,string password)
        {
            this.username = username;
            this.password = password;
        }
        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public String Password
        {
            get => password;
            set => password = value;
        }
    }
}
