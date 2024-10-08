using Microsoft.AspNetCore.Mvc;
using UserManagement.Repository.Interface;

namespace UserManagement.Controllers;

public class UserController : Controller
{

    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    [Route("GetUsers")]
    public Task<List<User>> GetAllUsers()
    {
        return _userRepository.GetAllEmployee();
    }

    [HttpGet]
    [Route("GetUsers/{id}")]
    public Task<List<User>> GetUser(string id)
    {
        Task<List<User>> user = _userRepository.GetEmployeeById(id);
        // Not aware of API return values.
        // For now just returned values in all the APIs
        // if (user.ToBson().Length == 0){
        //     return NotFound();
        // }
        return user;
    }

    [HttpPost]
    [Route("AddUser")]
    public Task<List<User>> AddUser(User user)
    {
        _userRepository.AddNewEmployee(user);
        return _userRepository.GetAllEmployee();
    }

    [HttpPut]
    [Route("UpdateUser")]
    public Task<List<User>> UpdateUser(string id, User user)
    {
        _userRepository.UpdateUser(id, user);
        return _userRepository.GetAllEmployee();
    }

    [HttpDelete]
    [Route("DeleteUser/{id}")]
    public IActionResult DeleteUser(string id)
    {
        // I didn't check for whether id present in DB?
        // Need to change for negative secenarios too
        _userRepository.DeleteUser(id);
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteAll")]
    public void DeleteAllEmployees()
    {
        _userRepository.DeleteAllEmployee();
    }
}
