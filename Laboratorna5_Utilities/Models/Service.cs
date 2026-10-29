using System.ComponentModel.DataAnnotations;
using Laboratorna5_Utilities.Models;

namespace Laboratorna5_Utilities.Models
{
    public class Service
    {
        public int ID { get; set; }

        [Display(Name = "Послуга")]
        public string ServiceName { get; set; } = string.Empty;

        [Display(Name = "Тариф за м²")]
        public decimal? RatePerSqMeter { get; set; }

        [Display(Name = "Тариф за особу")]
        public decimal? RatePerPerson { get; set; }

        public ICollection<TenantService> TenantServices { get; set; } = new List<TenantService>();
    }
}
