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

    public partial class Visit
    {
        public Visit()
        {
            this.VisitTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.VisitNotes = "Упражнения";
        }

        public Visit(Visit visit)
        {
            this.VisitTime = visit.VisitTime;
            this.VisitNotes = visit.VisitNotes;
            this.UserId = visit.UserId;
        }
        [BsonId]
        public int Id { get; set; }

        [BsonElement("visittime")]
        public System.DateTime VisitTime { get; set; }

        [BsonElement("visitnotes")]
        public string VisitNotes { get; set; }

        [BsonElement("userid")]   
        public int UserId { get; set; }
    }
}
