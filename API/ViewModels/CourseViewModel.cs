using API.ViewModels.Vehicles;

namespace API.ViewModels
{
  public class CourseViewModel : CourseBaseViewModel
  {
    public string CourseName { get; set; }
    public bool IsRetired { get; set; }
    public string ActiveUsers { get; set; }
  }
}