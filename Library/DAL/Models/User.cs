using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class User
    {
        public User(string fio, string login, Role role)
        {
            FIO = fio;
            Login = login;
            Role = role;
        }

        public string FIO { get; set; }
        public string Login { get; set; }
        internal Role Role { get; set; }
    }
}
