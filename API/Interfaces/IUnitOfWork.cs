using System.Threading.Tasks;

namespace API.Interfaces
{
  public interface IUnitOfWork
  {
    ICourseRepository CourseRepository { get; }
    IUserRepository UserRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
  }
}