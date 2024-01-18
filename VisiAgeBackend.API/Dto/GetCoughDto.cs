namespace VisiAgeBackend.API.Dto
{
    public class GetCoughDto
    {
        public int Id { get; set; }
        public int Severity { get; set; }
        public TimeSpan Duration { get; set; }
        public int Amount { get; set; }
        public string? AudioPath { get; set; }
        public int DependentId { get; set; }
    }
}
