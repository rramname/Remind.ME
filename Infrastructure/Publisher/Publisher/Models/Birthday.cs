using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Publisher.Models
{
    public class Birthday
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
    }
}