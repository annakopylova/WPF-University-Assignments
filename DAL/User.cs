using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("login")]
        public string Login { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("fio")]
        public string FIO { get; set; }
        [BsonElement("admin")]
        public bool Admin { get; set; }

        public User() { }

        public User(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            FIO = user.FIO;
            Admin = user.Admin;
        }

        public User(string login, string password, string FIO)
        {
            Login = login;
            Password = password;
            this.FIO = FIO;
            Admin = false;
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            Admin = true;
        }

        public virtual void UpdateUser(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            FIO = user.FIO;
            Admin = user.Admin;
        }
    }
}

