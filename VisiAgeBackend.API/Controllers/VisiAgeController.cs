using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisiAgeBackend.API.Dto;
using VisiAgeBackend.API;
using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisiAgeController : ControllerBase
    {
        private readonly VisiAgeDbContext _context;
        private readonly IMapper _mapper;
        public VisiAgeController(VisiAgeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Search - everyone is allowed to search

        //Get By ID
        [HttpGet("user/{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(t => t.Role)
                .Include(t => t.Confidants)
                .Include(t => t.Dependent)
                .SingleAsync(t => t.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetUserDto>(user);
        }

        // Get ALL
        [HttpGet("user")]
        public async Task<ActionResult<List<GetUserDto>>> GetUsers()
        {
            var users = await _context.Users
                .Include(t => t.Role)
                .Include(t => t.Dependent)
                .Include(t => t.Confidants)
                .ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetUserDto>>(users);
        }

        //Get Search
        [HttpGet("user/search")]
        public ActionResult<List<GetUserDto>> SearchUsers([FromQuery]SearchUserDto searchDto)
        {
            var users = _context.Users
                .Include(t => t.Role)
                .Include(t => t.Confidants)
                .Include(t => t.Dependent).ThenInclude(t => t.Role)
                .Where(t => t.FirstName.ToLower().Contains(searchDto.Name.ToLower()) || t.LastName.ToLower().Contains(searchDto.Name.ToLower()));

            if (users == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetUserDto>>(users);
        }

        //Insert
        [HttpPost("user")]
        public async Task<ActionResult<GetUserDto>> AddUser(CreateUserDto user)
        {
            //We map the CreateTripDto to the Trip entity object
            User userToAdd = _mapper.Map<User>(user);
            _context.Users.Add(userToAdd);
            await _context.SaveChangesAsync();
            GetUserDto userToReturn = _mapper.Map<GetUserDto>(userToAdd);

            return CreatedAtAction(nameof(GetUser), new { id = userToReturn.Id }, userToReturn);
        }
    }
}
