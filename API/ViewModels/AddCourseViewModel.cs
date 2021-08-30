using API.ViewModels.Vehicles;

namespace API.ViewModels
{
  public class AddCourseViewModel : CourseBaseViewModel
  {
    public string CourseName { get; set; }
    new public int CourseNumber { get; set; }
    public bool IsRetired { get; set; }
    public string ActiveUsers { get; set; }
  }
}