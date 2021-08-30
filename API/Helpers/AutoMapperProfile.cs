using API.Entities;
using API.ViewModels;
using AutoMapper;

namespace API.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Course, Course>();
      CreateMap<UpdateCourseViewModel, Course>();
      CreateMap<Course, CourseViewModel>();
      CreateMap<CourseViewModel, Course>();
      CreateMap<AddCourseViewModel, Course>();

      CreateMap<User, User>();
      CreateMap<AddUserViewModel, User>();
    }
  }
}