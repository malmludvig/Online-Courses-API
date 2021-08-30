using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class CourseRepository : ICourseRepository
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CourseRepository(DataContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public void AddCourse(AddCourseViewModel vehicle)
    {
      var vehicleToAdd = _mapper.Map<Course>(vehicle, opt =>
      {
        opt.Items["repo"] = _context;
      });
      _context.Entry(vehicleToAdd).State = EntityState.Added;
    }

    public void DeleteCourse(Course course)
    {
      _context.Entry(course).State = EntityState.Deleted;
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        return await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == id);
    }

    public async Task<CourseViewModel> GetCoursesByCourseNoAsync(string regNo)
    {
      return await _context.Courses
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync(c => c.CourseNumber.ToLower() == regNo.ToLower());
    }

        public async Task<CourseViewModel> GetCoursesByCourseNameAsync(string courseName)
    {
      return await _context.Courses
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync(c => c.CourseName.ToLower() == courseName.ToLower());
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
      return await _context.Courses
        .ProjectTo<Course>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public void UpdateCourse(UpdateCourseViewModel updatedCourse, int id)
    {
        var user = _mapper.Map<Course>(updatedCourse);
        user.CourseId = id;
        _context.Entry(user).State = EntityState.Modified;
    }

    public async Task<IEnumerable<Course>> Search(string name)
    {
        IQueryable<Course> query = _context.Courses;
            
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(e => e.CourseName.Contains(name));
        }

        return await query.ToListAsync();
    }
  }
}