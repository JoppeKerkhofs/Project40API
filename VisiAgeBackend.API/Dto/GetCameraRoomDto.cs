using VisiAgeBackend.API.Entity;

namespace VisiAgeBackend.API.Dto
{
    public class GetCameraRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DependentId { get; set; }
    }
}
