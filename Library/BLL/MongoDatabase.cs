using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BLL
{
    public class MongoDatabase : IDatabase
    {
        IMongoDatabase db;
        private IMongoCollection<User> UsersCollection;
        private IMongoCollection<Visit> VisitCollection;
        private IMongoCollection<Visitor> VisitorCollection;

        public void init()
        {
            MongoClient client = new MongoClient();
            db = client.GetDatabase("FitnessDB");
            UsersCollection = db.GetCollection<User>("users");
            VisitCollection = db.GetCollection<Visit>("visit");
            VisitorCollection = db.GetCollection<Visitor>("visitor");
        }

        public User AddUser(User user)
        {
            int count = GetUsers().Count;
            user.Id = count;
            UsersCollection.InsertOne(user);
            return user;
        }

        public Visitor AddVisitor(Visitor visitor)
        {
            int count = GetUsers().Count;
            visitor.Id = count;
            VisitorCollection.InsertOne(visitor);
            return visitor;
        }

        public void AddVisits(Visit visit)
        {
            int count = GetVisits().Count;
            visit.Id = count;
            VisitCollection.InsertOne(visit);
        }

        public bool CheckAdminRole(string login, string password)
        {
            var filter = Builders<User>.Filter.And(
    Builders<User>.Filter.Where(p => p.Password.Equals(password)),
    Builders<User>.Filter.Where(p => p.Login.Equals(login))
            );
            User user = UsersCollection.Find(filter).Single();
            if (user != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool CheckLogin(string login)
        {
            var filter = Builders<User>.Filter.And(
Builders<User>.Filter.Where(p => p.Login.Equals(login))
);
            User user = UsersCollection.Find(filter).Single();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteVisit(Visit visit)
        {
            var filter = Builders<Visit>.Filter.Eq("_id", visit.Id);
            VisitCollection.DeleteOne(filter);
        }

        public User GetUser(string login, string password)
        {
            var filter = Builders<User>.Filter.And(
Builders<User>.Filter.Where(p => p.Password.Equals(password)),
Builders<User>.Filter.Where(p => p.Login.Equals(login))
 );
            User user = UsersCollection.Find(filter).Single();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public User GetUser(string login)
        {
            var filter = Builders<User>.Filter.And(
Builders<User>.Filter.Where(p => p.Login.Equals(login))
);
            User user = UsersCollection.Find(filter).Single();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            return UsersCollection.Find(new BsonDocument()).ToList();
        }

        public Visit GetVisit(int id)
        {
            var filter = Builders<Visit>.Filter.And(
Builders<Visit>.Filter.Where(p => p.Id == (id))
);
            Visit visit = VisitCollection.Find(filter).Single();
            if (visit != null)
            {
                return visit;
            }
            else
            {
                return null;
            }
        }

        public List<Visit> GetVisits(User user)
        {
            return VisitCollection.Find(new BsonDocument()).ToList();
        }

        public List<Visit> GetVisits()
        {
            return VisitCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq("_id", user.Id);
            var update = Builders<User>.Update.Set("login", user.Login)
                .Set("password", user.Login)
                .Set("fio", user.FIO)
                .Set("admin", user.Admin);

            var result = UsersCollection.UpdateOne(filter, update);
        }

        public void UpdateVisit(Visit oldVisit, Visit newVisit)
        {
            int oldVisitId = newVisit.Id;
            var filter = Builders<Visit>.Filter.Eq("_id", oldVisit.Id);
            var update = Builders<Visit>.Update.Set("visittime", newVisit.VisitTime)
                .Set("visitnotes", newVisit.VisitNotes)
                .Set("userid", newVisit.UserId);

            var result = VisitCollection.UpdateOne(filter, update);
        }
    }
}
