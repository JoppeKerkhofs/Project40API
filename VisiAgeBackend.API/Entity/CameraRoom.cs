using System.ComponentModel.DataAnnotations.Schema;

namespace VisiAgeBackend.API.Entity
{
    public class CameraRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("User")]
        public int DependentId { get; set; }
        public User Dependent { get; set; }
        public ICollection<Alert>? Alerts { get; set; }
    }
}
