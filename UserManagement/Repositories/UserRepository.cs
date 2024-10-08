
using MongoDB.Bson;
using MongoDB.Driver;
using UserManagement.DbConnection;
using UserManagement.Repository.Interface;

namespace UserManagement.Repository;
public class UserRepository : IUserRepository
{
  public readonly DbContext dbContext;
  public UserRepository(DbContext _dbContext)
  {
    dbContext = _dbContext;
  }

  public async Task<List<User>> GetAllEmployee()
  {
    var data = await dbContext.userCollection.Find(_ => true).ToListAsync();
    return data;
  }

  public async Task<List<User>> GetEmployeeById(string id)
  {
    var data = await dbContext.userCollection.Find(emp => emp.Id == id).ToListAsync();
    return data;
  }

  public void AddNewEmployee(User user)
  {
    dbContext.userCollection.InsertOne(user);
  }

  public void UpdateUser(string id, User user)
  {

    dbContext.userCollection.ReplaceOne(emp => emp.Id == id, new User
    {
      Name = user.Name,
      Age = user.Age,
      Address = user.Address,
      Id = id
    });
  }

  public void DeleteUser(string id)
  {
    dbContext.userCollection.DeleteOne(emp => emp.Id == id);
  }

  public void DeleteAllEmployee()
  {
    dbContext.database.DropCollection("Users");
  }

}
