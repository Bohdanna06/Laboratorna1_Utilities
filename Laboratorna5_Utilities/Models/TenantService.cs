namespace Laboratorna5_Utilities.Models
{
    public class TenantService
    {
        public int ID { get; set; }
        public int TenantID { get; set; }
        public Tenant? Tenant { get; set; }

        public int ServiceID { get; set; }
        public Service? Service { get; set; }
    }
}
