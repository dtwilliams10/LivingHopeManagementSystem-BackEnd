
namespace LHMSAPI.Models
{
     public class User
        {
        //[BsonRepresentation(_id)]
            public int _id { get; set; }

            public int id {get; set;}
            
            public string name { get; set; }

            public string summary { get; set; }
        }
}