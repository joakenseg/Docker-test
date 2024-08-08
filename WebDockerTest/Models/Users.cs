using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebDockerTest.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }
    }
}