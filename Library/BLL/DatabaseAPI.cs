using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DatabaseAPI: IDatabase
    {
        IDatabase database;

        [Ninject.Inject]
        public DatabaseAPI(IDatabase database)
        {
            this.database = database;
        }

        public bool CheckLogin(string login)
        {
           return database.CheckLogin(login);
        }

        public bool CheckAdminRole(string login, string password)
        {
            return database.CheckAdminRole(login, password);
        }

        public User AddUser(User user)
        {
            return database.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            database.UpdateUser(user);
        }

        public User GetUser(string login, string password)
        {
            return database.GetUser(login, password);
        }

        public User GetUser(string login)
        {
            return database.GetUser(login);
        }

        public List<User> GetUsers()
        {
            return database.GetUsers();
        }

        public Visitor AddVisitor(Visitor student)
        {
            return database.AddVisitor(student);
        }

        public Visit GetVisit(int id)
        {
            return database.GetVisit(id);
        }

        public List<Visit> GetVisits(User user)
        {
            return database.GetVisits(user);
        }

        public void AddVisits(Visit visit)
        {
            database.AddVisits(visit);
        }

        public void UpdateVisit(Visit oldVisit, Visit newVisit)
        {
            database.UpdateVisit(oldVisit, newVisit);
        }

        public void DeleteVisit(Visit visit)
        {
            database.DeleteVisit(visit);
        }

        public void init()
        {
            database.init();
        }
    }
}
