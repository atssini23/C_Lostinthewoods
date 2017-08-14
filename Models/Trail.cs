namespace YourNamespace.Models
{
    public abstract class BaseEntity{}
    public class Trail : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public int Elevation{ get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}