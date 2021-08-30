using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public UserRepository(DataContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

        public async Task<IEnumerable<User>> GetUsersAsync()
    {
      return await _context.Users
        .ProjectTo<User>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }
        public void AddUser(AddUserViewModel vehicle)
    {
      var vehicleToAdd = _mapper.Map<User>(vehicle, opt =>
      {
        opt.Items["repo"] = _context;
      });
      _context.Entry(vehicleToAdd).State = EntityState.Added;
    }
  }
}