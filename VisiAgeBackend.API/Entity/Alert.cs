using System.ComponentModel.DataAnnotations.Schema;

namespace VisiAgeBackend.API.Entity
{
    public class Alert
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? KeepFootage { get; set; }
        public double? AccuracyScore { get; set; }
        public string? VideoPath { get; set; }
        public string? Reason { get; set; }
        [ForeignKey("IncidentType")]
        public int IncidentTypeId { get; set; }
        public IncidentType IncidentType { get; set; }
        [ForeignKey("CameraRoom")]
        public int CameraRoomId { get; set; }
        public CameraRoom CameraRoom { get; set; }
        [ForeignKey("User")]
        public int DependentId { get; set; }
        public User Dependent { get; set; }
        public AlertStatus? AlertStatus { get; set; }
    }
}
