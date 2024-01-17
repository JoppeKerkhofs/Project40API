namespace VisiAgeBackend.API.Dto
{
    public class GetAlertStatusDto
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? Message { get; set; }
        public int AlertId { get; set; }
        public int AlertStatusTypeId { get; set; }
        public int? ResolverId { get; set; }
    }
}
