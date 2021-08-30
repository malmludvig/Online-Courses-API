using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{

  [Table("Course", Schema = "Courses")]
  public class Course
  {
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public int CourseNumber { get; set; }
    public bool IsRetired { get; set; }
    public string ActiveUsers { get; set; }
    
    //public virtual ICollection<User> Users { get; set; }

  }
}