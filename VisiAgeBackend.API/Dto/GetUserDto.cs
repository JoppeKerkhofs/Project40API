using System.Text.Json.Serialization;
using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Dto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public GetRoleDto Role { get; set; }
        public int? DependentId { get; set; }
        public GetUserDto? Dependent { get; set; }
    }
}
