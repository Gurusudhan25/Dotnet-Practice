
using MongoDB.Driver;

namespace UserManagement.DbConnection
{
  public class DbContext
  {
    public readonly IMongoCollection<User> userCollection;
    public readonly IMongoDatabase database;
    public DbContext(IConfiguration configuration)
    {
      MongoClient client = new MongoClient(configuration["ConnectionStrings:Connection_name"]);
      database = client.GetDatabase(configuration["ConnectionStrings:Database_name"]);
      userCollection = database.GetCollection<User>(configuration["ConnectionStrings:Collection_name"]);
    }
  }
}