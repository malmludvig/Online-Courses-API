using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/courses")]
  public class CourseController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;

    public CourseController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourses()
    {
      return Ok(await _unitOfWork.CourseRepository.GetCoursesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseViewModel>> GetCourseById(int id)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCourseByIdAsync(id));
    }

    [HttpGet("find/coursenumber/{no}")]
    public async Task<ActionResult<CourseViewModel>> FindCourseByCourseNumber(string no)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCoursesByCourseNoAsync(no));
    }

    [HttpGet("find/coursename/{name}")]
    public async Task<ActionResult<CourseViewModel>> FindCourseByCourseName(string name)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCoursesByCourseNameAsync(name));
    }

    [HttpPost()]
    public async Task<ActionResult> AddCourse(AddCourseViewModel model)
    {

      _unitOfWork.CourseRepository.AddCourse(model);
      if (await _unitOfWork.Complete())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Gick inte att spara kursen");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVehicleAsync(int id)
    {
      var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);
      if (course == null) return NotFound($"Tyvärr hittade ingen kurs med kursid {id}.");

      _unitOfWork.CourseRepository.DeleteCourse(course);
      if (await _unitOfWork.Complete()) return NoContent();

      return StatusCode(500, "Gick inte att ta bort kursen.");
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateCourse (int id, UpdateCourseViewModel updatedUser){

        _unitOfWork.CourseRepository.UpdateCourse(updatedUser, id);
        if (await _unitOfWork.Complete()) return NoContent();

        return StatusCode(500, "Det gick inte att uppdatera kursen");
    }

    //Gammal patch från Michael
    [HttpPatch("patch2/{id}")]
    public async Task<ActionResult> UpdateVehicle(int id, UpdateCourseViewModel model)
    {
      var vehicle = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);
      vehicle.IsRetired = model.IsRetired;


      if (await _unitOfWork.Complete()) return NoContent();

      return NoContent();
    }

    [HttpGet("search/{name}")]
    public async Task<ActionResult<IEnumerable<Course>>> Search(string name)
    {
        try
        {
            var result = await _unitOfWork.CourseRepository.Search(name);

            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500,
                "Fel vid hämtning av data.");
        }
    }
  }
}