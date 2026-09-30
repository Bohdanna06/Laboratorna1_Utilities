namespace Laboratorna3_Utilities
{
    public class Tenant
    {
        public int ID { get; set; }
        public string AccountNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int OccupantsCount { get; set; }
        public decimal Area { get; set; }
    }
}
