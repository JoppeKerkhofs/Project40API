using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiAgeBackend.API.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("User")]
        public int? DependentId { get; set; }
        public User? Dependent { get; set; }
        public ICollection<Cough>? Coughs { get; set; }
        public ICollection<User>? Confidants { get; set; }
        public ICollection<CameraRoom>? CameraRooms { get; set; }
        public ICollection<Alert>? Alerts { get; set; }
        public AlertStatus? AlertStatus { get; set; }
    }
}
