using System.ComponentModel.DataAnnotations.Schema;
using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Dto
{
    public class CreateCoughDto
    {
        public int Severity { get; set; }
        public TimeSpan Duration { get; set; }
        public int Amount { get; set; }
        public string? AudioPath { get; set; }
        public int DependentId { get; set; }
    }
}
