namespace VisiAgeBackend.API.Dto
{
    public class EditAlertStatusDto
    {
        public DateTime TimeStamp { get; set; }
        public string? Message { get; set; }
        public int AlertId { get; set; }
        public int AlertStatusTypeId { get; set; }
        public int? ResolverId { get; set; }
    }
}
