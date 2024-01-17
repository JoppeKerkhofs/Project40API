using System.ComponentModel.DataAnnotations.Schema;

namespace VisiAgeBackend.API.Dto
{
    public class CreateCameraRoomDto
    {
        public string Name { get; set; }
        public int DependentId { get; set; }
    }
}
