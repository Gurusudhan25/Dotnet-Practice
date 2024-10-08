

namespace UserManagement.Repository.Interface;
public interface IUserRepository
{
  Task<List<User>> GetAllEmployee();
  Task<List<User>> GetEmployeeById(string id);
  void AddNewEmployee(User user);
  void UpdateUser(string id, User user);
  void DeleteAllEmployee();
  void DeleteUser(string id);
}