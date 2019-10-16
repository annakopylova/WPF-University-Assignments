using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IDatabase // repository
    {
        public void init();

        public bool CheckLogin(string login);

        public bool CheckAdminRole(string login, string password);

        public User AddUser(User user);

        public void UpdateUser(User user);

        public User GetUser(string login, string password);

        public User GetUser(string login);

        public List<User> GetUsers();

        public Visitor AddVisitor(Visitor student);

        public Visit GetVisit(int id);

        public List<Visit> GetVisits(User user);

        public void AddVisits(Visit visit);

        public void UpdateVisit(Visit oldVisit, Visit newVisit);

        public void DeleteVisit(Visit visit);
    }
}
