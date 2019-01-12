using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LHMSAPI.Models
{
     public class User
        {
        //[BsonRepresentation(_id)]
        [BsonId]
            public BsonObjectId _id { get; set; }

            [BsonElement("id")]
            public int id {get; set;}
            
            [BsonElement("name")]
            public string name { get; set; }

            [BsonElement("summary")]
            public string summary { get; set; }
        }
}