using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Laboratorna3_Utilities
{
    public class TenantService
    {
        public int TenantID { get; set; }
        [ValidateNever] // Вказує не валідувати об'єкт Tenant при створенні
        public Tenant Tenant { get; set; } = null!;

        public int ServiceID { get; set; }
        [ValidateNever] // Вказує не валідувати об'єкт Service при створенні
        public Service Service { get; set; } = null!;
    }
}
