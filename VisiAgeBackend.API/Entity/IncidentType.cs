namespace VisiAgeBackend.API.Entity
{
    public class IncidentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Alert>? Alerts { get; set; }
    }
}
