using System.ComponentModel.DataAnnotations.Schema;
using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Dto
{
    public class CreateAlertDto
    {
        public DateTime TimeStamp { get; set; }
        public bool? KeepFootage { get; set; }
        public double? AccuracyScore { get; set; }
        public string? VideoPath { get; set; }
        public string? Reason { get; set; }
        public int IncidentTypeId { get; set; }
        public int CameraRoomId { get; set; }
        public int DependentId { get; set; }
    }
}
