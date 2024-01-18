namespace VisiAgeBackend.API.Entity
{
    public class AlertStatusType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AlertStatus>? AlertStatuses { get; set; }
    }
}
