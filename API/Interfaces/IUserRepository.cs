using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
  public interface IUserRepository
  {
    void AddUser(AddUserViewModel course);
    Task<IEnumerable<User>> GetUsersAsync();
  }
}