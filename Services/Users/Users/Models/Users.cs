using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace UsersService.Models
{
    public class Users
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        
        [BsonElement]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime date { get; set; }
    }
}