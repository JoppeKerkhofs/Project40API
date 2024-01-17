using System.ComponentModel.DataAnnotations.Schema;

namespace VisiAgeBackend.API.Entity
{
    public class Cough
    {
        public int Id { get; set; }
        public int Severity { get; set; }
        public TimeSpan Duration { get; set; }
        public int Amount { get; set; }
        public string? AudioPath { get; set; }
        [ForeignKey("User")]
        public int DependentId { get; set; }
        public User Dependent { get; set; }
    }
}
