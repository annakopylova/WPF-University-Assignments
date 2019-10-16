using System;
using DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SQLDatabase: IDatabase // repository
    {
        FitnessDB db = new FitnessDB();

        public bool CheckLogin(string login)
        {
            var u = from User in db.Users
                    where User.Login.ToLower() == login.ToLower()
                    select User;
            try
            {
                u.First();
                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool CheckAdminRole(string login, string password)
        {
            return GetUser(login, password).Admin;
        }

        public User AddUser(User user) // unit of work
        {
            if (CheckLogin(user.Login))
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
            return null;
        }

        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public User GetUser(string login, string password)
        {
            var user = from User in db.Users
                       where User.Login.ToLower() == login && User.Password == password
                       select User;
            try
            {
                return user.First();
            }
            catch
            {
                return null;
            }
        }

        public User GetUser(string login)
        {
            var user = from User in db.Users
                       where User.Login.ToLower() == login
                       select User;
            try
            {
                return user.First();
            }
            catch
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public Visitor AddVisitor(Visitor student)
        {
            db.Users.Add(student);
            db.SaveChanges();
            return student;
        }

        public Visit GetVisit(int id)
        {
           var visit = from Visit in db.Visits
                      where Visit.Id == id
                      select Visit;
            try
            {
                return visit.First();
            }
            catch
            {
                return null;
            }
        }

        public List<Visit> GetVisits(User user)
        {
            if (user.Admin)
            {
                return db.Visits.ToList();
            } else
            {
                return db.Visits.Where(v => v.UserId == user.Id).ToList();
            }
        }

        public void AddVisits(Visit visit)
        {
            db.Visits.Add(visit);
            db.SaveChanges();
        }

        public void UpdateVisit(Visit oldVisit, Visit newVisit)
        {
            DeleteVisit(oldVisit);
            db.Visits.Add(newVisit);
            db.SaveChanges();
        }

        public void DeleteVisit(Visit visit)
        {
            db.Visits.Remove(GetVisit(visit.Id));
            db.SaveChanges();
        }

        public void init()
        {

        }
    }
}
