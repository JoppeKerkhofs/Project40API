using System.ComponentModel.DataAnnotations.Schema;

namespace VisiAgeBackend.API.Entity
{
    public class AlertStatus
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? Message { get; set; }
        [ForeignKey("Alert")]
        public int AlertId { get; set; }
        public Alert Alert { get; set; }
        [ForeignKey("AlertStatusType")]
        public int AlertStatusTypeId { get; set; }
        public AlertStatusType AlertStatusType { get; set; }
        [ForeignKey("User")]
        public int? ResolverId { get; set; }
        public User? Resolver { get; set; }
    }
}
