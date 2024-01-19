using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Dto
{
    public class GetAlertDto
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? KeepFootage { get; set; }
        public double? AccuracyScore { get; set; }
        public string? VideoPath { get; set; }
        public string? Reason { get; set; }
        public int IncidentTypeId { get; set; }
        public GetIncidentTypeDto IncidentType { get; set; }
        public int CameraRoomId { get; set; }
        public GetCameraRoomDto CameraRoom { get; set; }
        public int DependentId { get; set; }
        public GetUserDto Dependent { get; set; }
        public GetAlertStatusDto AlertStatus { get; set; } 
    }
}
