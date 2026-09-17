namespace Laboratorna1_Utilities
{
    public class TenantService
    {
        public int TenantID { get; set; }
        public Tenant Tenant { get; set; } = null!;

        public int ServiceID { get; set; }
        public Service Service { get; set; } = null!;
    }
}
