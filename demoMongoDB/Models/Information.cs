using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoMongoDB.Models
{
    public class Information
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("age")]
        public int age { get; set; }
        [BsonElement("phone")]
        public string phone { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("address")]
        public string address { get; set; }
        [BsonElement("active")]
        public bool active { get; set; }
    }
}
