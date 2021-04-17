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
        public string _id { get; set; }
     
        public string name { get; set; }
       
        public string age { get; set; }
  
        public string phone { get; set; }
  
        public string email { get; set; }
  
        public string address { get; set; }

        public bool active { get; set; }
    }
}
