using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id;
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Address { get; set; }
}
