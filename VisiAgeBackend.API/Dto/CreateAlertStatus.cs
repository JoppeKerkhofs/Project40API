using System.ComponentModel.DataAnnotations.Schema;
using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Dto
{
    public class CreateAlertStatus
    {
        public DateTime TimeStamp { get; set; }
        public string? Message { get; set; }
        public int AlertId { get; set; }
        public int AlertStatusTypeId { get; set; }
        public int? ResolverId { get; set; }
    }
}
