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

    public partial class Visitor : User
    {
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("weight")]
        public int Weight { get; set; }
        [BsonElement("height")]
        public int Height { get; set; }
        [BsonElement("subscriptionfinish")]
        public long SubscriptionFinish { get; set; }

        public virtual Visit Visit { get; set; }

        public Visitor() { }

        public Visitor(User user, int age, int weight, int height, long subscriptionFinish) : base(user)
        {
            Age = age;
            Weight = weight;
            Height = height;
            SubscriptionFinish = subscriptionFinish;
        }

        public override void UpdateUser(User user)
        {
            base.UpdateUser(user);
        }
    }
}
