using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UserController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
    {
      return Ok(await _unitOfWork.UserRepository.GetUsersAsync());
    }

    [HttpPost()]
    public async Task<ActionResult> AddUser(AddUserViewModel model)
    {

      _unitOfWork.UserRepository.AddUser(model);
      if (await _unitOfWork.Complete())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Gick inte att spara användaren.");
    }
  }
}