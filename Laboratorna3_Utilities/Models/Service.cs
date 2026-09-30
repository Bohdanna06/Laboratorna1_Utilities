namespace Laboratorna3_Utilities
{
    public class Service
    {
        public int ID { get; set; }
        public string ServiceName { get; set; } = null!;
        public decimal? RatePerSqMeter { get; set; }
        public decimal? RatePerPerson { get; set; }
    }
}
