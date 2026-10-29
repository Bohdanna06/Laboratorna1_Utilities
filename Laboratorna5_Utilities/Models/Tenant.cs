using System.ComponentModel.DataAnnotations;

namespace Laboratorna5_Utilities.Models
{
    public class Tenant
    {
        public int ID { get; set; }

        [Display(Name = "Особовий рахунок")]
        public string AccountNumber { get; set; } = string.Empty;

        [Display(Name = "ПІБ")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Адреса")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Мешканців")]
        public int OccupantsCount { get; set; }

        [Display(Name = "Площа (м²)")]
        public decimal Area { get; set; }

        public ICollection<TenantService> TenantServices { get; set; } = new List<TenantService>();
    }
}
