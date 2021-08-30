using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
  public interface ICourseRepository
  {
    void AddCourse(AddCourseViewModel course);
    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<CourseViewModel> GetCoursesByCourseNoAsync(string courseNo);
    Task<CourseViewModel> GetCoursesByCourseNameAsync(string courseName);
    Task<Course> GetCourseByIdAsync(int id);
    void DeleteCourse(Course course);
    void UpdateCourse(UpdateCourseViewModel course, int id);

    Task<IEnumerable<Course>> Search(string name);
  }
}