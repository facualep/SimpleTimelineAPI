using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Timeline.Models
{
    public class Hit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime HitDate { get; set; }

        [BsonElement("Name")]
        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Links { get; set; }

        public void setId()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
