using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LHMSAPI.Models
{
     public class User
        {
            [BsonId]
            public int Id { get; set; }

            [BsonElement("Name")]
            public string Name { get; set; }

            [BsonElement("Summary")]
            public string Summary { get; set; }
        }
}