using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisiAgeBackend.API.Dto;
using VisiAgeBackend.API;
using VisiAgeBackend.API.Entity;
using System.Security.Claims;

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
            User userToAdd = _mapper.Map<User>(user);
            _context.Users.Add(userToAdd);
            await _context.SaveChangesAsync();
            GetUserDto userToReturn = _mapper.Map<GetUserDto>(userToAdd);

            return CreatedAtAction(nameof(GetUser), new { id = userToReturn.Id }, userToReturn);
        }

        [HttpPut("user/{id}")]
        public async Task<ActionResult<GetUserDto>> EditUser(int id, EditUserDto userDto)
        {
            try
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

                _mapper.Map(userDto, user);

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                var updatedUserDto = _mapper.Map<GetUserDto>(user);
                return Ok(updatedUserDto);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("role")]
        public async Task<ActionResult<List<GetRoleDto>>> GetRoles()
        {
            var roles = await _context.Roles
                .ToListAsync();

            if (roles == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetRoleDto>>(roles);
        }

        [HttpGet("role/{id}")]
        public async Task<ActionResult<GetRoleDto>> GetRole(int id)
        {
            var role = await _context.Roles
                .SingleAsync(t => t.Id == id);

            if (role == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetRoleDto>(role);
        }

        [HttpPost("role")]
        public async Task<ActionResult<GetRoleDto>> AddRole(CreateRoleDto role)
        {
            Role roleToAdd = _mapper.Map<Role>(role);
            _context.Roles.Add(roleToAdd);
            await _context.SaveChangesAsync();
            GetRoleDto roleToReturn = _mapper.Map<GetRoleDto>(roleToAdd);

            return CreatedAtAction(nameof(GetRole), new { id = roleToReturn.Id }, roleToReturn);
        }

        [HttpPut("role/{id}")]
        public async Task<ActionResult<GetRoleDto>> EditRole(int id, EditRoleDto roleDto)
        {
            try
            {
                var role = await _context.Roles
                    .SingleAsync(t => t.Id == id);

                if (role == null)
                {
                    return NotFound();
                }

                _mapper.Map(roleDto, role);

                _context.Roles.Update(role);
                await _context.SaveChangesAsync();

                var updatedRoleDto = _mapper.Map<GetRoleDto>(role);
                return Ok(updatedRoleDto);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("cough")]
        public async Task<ActionResult<List<GetCoughDto>>> GetCoughs()
        {
            var coughs = await _context.Coughs
                .Include(t => t.Dependent)
                .ToListAsync();

            if (coughs == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetCoughDto>>(coughs);
        }

        [HttpGet("cough/{id}")]
        public async Task<ActionResult<GetCoughDto>> GetCough(int id)
        {
            var cough = await _context.Coughs
                .Include(t => t.Dependent)
                .SingleAsync(t => t.Id == id);

            if (cough == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetCoughDto>(cough);
        }

        [HttpPost("cough")]
        public async Task<ActionResult<GetCoughDto>> AddCough(CreateCoughDto cough)
        {
            Cough coughToAdd = _mapper.Map<Cough>(cough);
            _context.Coughs.Add(coughToAdd);
            await _context.SaveChangesAsync();
            GetCoughDto coughToReturn = _mapper.Map<GetCoughDto>(coughToAdd);

            return CreatedAtAction(nameof(GetCough), new { id = coughToReturn.Id }, coughToReturn);
        }

        [HttpGet("cameraroom")]
        public async Task<ActionResult<List<GetCameraRoomDto>>> GetCameraRooms()
        {
            var cameraRooms = await _context.CameraRooms
                .ToListAsync();

            if (cameraRooms == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetCameraRoomDto>>(cameraRooms);
        }

        [HttpGet("cameraroom/{id}")]
        public async Task<ActionResult<GetCameraRoomDto>> GetCameraRoom(int id)
        {
            var cameraRoom = await _context.CameraRooms
                .SingleAsync(t => t.Id == id);

            if (cameraRoom == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetCameraRoomDto>(cameraRoom);
        }

        [HttpPost("cameraroom")]
        public async Task<ActionResult<GetCameraRoomDto>> AddCameraRoom(CreateCameraRoomDto cameraRoom)
        {
            CameraRoom cameraRoomToAdd = _mapper.Map<CameraRoom>(cameraRoom);
            _context.CameraRooms.Add(cameraRoomToAdd);
            await _context.SaveChangesAsync();
            GetCameraRoomDto cameraRoomToReturn = _mapper.Map<GetCameraRoomDto>(cameraRoomToAdd);

            return CreatedAtAction(nameof(GetCameraRoom), new { id = cameraRoomToReturn.Id }, cameraRoomToReturn);
        }

        [HttpGet("incidenttype")]
        public async Task<ActionResult<List<GetIncidentTypeDto>>> GetIncidentTypes()
        {
            var incidentType = await _context.IncidentTypes
                .ToListAsync();

            if (incidentType == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetIncidentTypeDto>>(incidentType);
        }

        [HttpGet("incidenttype/{id}")]
        public async Task<ActionResult<GetIncidentTypeDto>> GetIncidentType(int id)
        {
            var incidentType = await _context.IncidentTypes
                .SingleAsync(t => t.Id == id);

            if (incidentType == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetIncidentTypeDto>(incidentType);
        }

        [HttpPost("incidenttype")]
        public async Task<ActionResult<GetIncidentTypeDto>> AddIncidentType(CreateIncidentTypeDto incidentType)
        {
            IncidentType incidentTypeToAdd = _mapper.Map<IncidentType>(incidentType);
            _context.IncidentTypes.Add(incidentTypeToAdd);
            await _context.SaveChangesAsync();
            GetIncidentTypeDto incidentTypeToReturn = _mapper.Map<GetIncidentTypeDto>(incidentTypeToAdd);

            return CreatedAtAction(nameof(GetIncidentType), new { id = incidentTypeToReturn.Id }, incidentTypeToReturn);
        }

        [HttpGet("alert")]
        public async Task<ActionResult<List<GetAlertDto>>> GetAlerts()
        {
            var alert = await _context.Alerts
                .Include(t => t.IncidentType)
                .Include(t => t.CameraRoom)
                .Include(t => t.Dependent)
                .ToListAsync();

            if (alert == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetAlertDto>>(alert);
        }

        [HttpGet("alert/{id}")]
        public async Task<ActionResult<GetAlertDto>> GetAlert(int id)
        {
            var alert = await _context.Alerts
                .Include(t => t.IncidentType)
                .Include(t => t.CameraRoom)
                .Include(t => t.Dependent)
                .SingleAsync(t => t.Id == id);

            if (alert == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetAlertDto>(alert);
        }

        [HttpPost("alert")]
        public async Task<ActionResult<GetAlertDto>> AddAlert(CreateAlertDto alert)
        {
            Alert alertToAdd = _mapper.Map<Alert>(alert);
            _context.Alerts.Add(alertToAdd);
            await _context.SaveChangesAsync();
            GetAlertDto alertToReturn = _mapper.Map<GetAlertDto>(alertToAdd);

            return CreatedAtAction(nameof(GetAlert), new { id = alertToReturn.Id }, alertToReturn);
        }

        [HttpGet("alertstatus")]
        public async Task<ActionResult<List<GetAlertStatusDto>>> GetAlertStatuses()
        {
            var alertStatus = await _context.AlertStatuses
                .Include(t => t.AlertStatusType)
                .Include(t => t.Resolver)
                .ToListAsync();

            if (alertStatus == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetAlertStatusDto>>(alertStatus);
        }

        [HttpGet("alertstatus/{id}")]
        public async Task<ActionResult<GetAlertStatusDto>> GetAlertStatus(int id)
        {
            var alertStatus = await _context.AlertStatuses
                .Include(t => t.AlertStatusType)
                .Include(t => t.Resolver)
                .SingleAsync(t => t.Id == id);

            if (alertStatus == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetAlertStatusDto>(alertStatus);
        }

        [HttpPost("alertstatus")]
        public async Task<ActionResult<GetAlertStatusDto>> AddAlertStatus(CreateAlertStatusDto alertStatus)
        {
            AlertStatus alertStatusToAdd = _mapper.Map<AlertStatus>(alertStatus);
            _context.AlertStatuses.Add(alertStatusToAdd);
            await _context.SaveChangesAsync();
            GetAlertStatusDto alertStatusToReturn = _mapper.Map<GetAlertStatusDto>(alertStatusToAdd);

            return CreatedAtAction(nameof(GetAlertStatus), new { id = alertStatusToReturn.Id }, alertStatusToReturn);
        }

        [HttpGet("alertstatustype")]
        public async Task<ActionResult<List<GetAlertStatusTypeDto>>> GetAlertStatusTypes()
        {
            var alertStatusType = await _context.AlertStatusTypes
                .ToListAsync();

            if (alertStatusType == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetAlertStatusTypeDto>>(alertStatusType);
        }

        [HttpGet("alertstatustype/{id}")]
        public async Task<ActionResult<GetAlertStatusTypeDto>> GetAlertStatusType(int id)
        {
            var alertStatusType = await _context.AlertStatusTypes
                .SingleAsync(t => t.Id == id);

            if (alertStatusType == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetAlertStatusTypeDto>(alertStatusType);
        }

        [HttpPost("alertstatustype")]
        public async Task<ActionResult<GetAlertStatusTypeDto>> AddAlertStatusType(CreateAlertStatusTypeDto alertStatusType)
        {
            AlertStatusType alertStatusTypeToAdd = _mapper.Map<AlertStatusType>(alertStatusType);
            _context.AlertStatusTypes.Add(alertStatusTypeToAdd);
            await _context.SaveChangesAsync();
            GetAlertStatusTypeDto alertStatusTypeToReturn = _mapper.Map<GetAlertStatusTypeDto>(alertStatusTypeToAdd);

            return CreatedAtAction(nameof(GetAlertStatusType), new { id = alertStatusTypeToReturn.Id }, alertStatusTypeToReturn);
        }
    }
}
