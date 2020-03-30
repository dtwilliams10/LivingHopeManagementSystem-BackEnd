namespace LHMSAPI.Entities
{
    public class User
    {
        public int id {get; set;}
        public string firstName {get; set;}
        public string lastName {get; set;}
        public string username {get; set;}
        public string emailAddress {get; set;}
        public byte[] passwordHash {get; set;}
        public byte[] passwordSalt {get; set;}
    }
}