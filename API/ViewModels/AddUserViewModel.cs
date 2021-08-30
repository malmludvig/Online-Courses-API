using System.Collections.Generic;
using API.Entities;
using API.ViewModels.Vehicles;

namespace API.ViewModels
{
  public class AddUserViewModel : CourseBaseViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    
    //public virtual ICollection<Course> Courses { get; set; }
  }
}