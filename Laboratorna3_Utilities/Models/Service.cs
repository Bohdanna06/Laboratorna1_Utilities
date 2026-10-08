using System.ComponentModel.DataAnnotations;

namespace Laboratorna3_Utilities
{
    public class Service
    {
        //public int ID { get; set; }
        //public string ServiceName { get; set; } = null!;
        //public decimal? RatePerSqMeter { get; set; }
        //public decimal? RatePerPerson { get; set; }

        public int ID { get; set; }

        [Required(ErrorMessage = "Введіть назву послуги")]
        [Display(Name = "Назва послуги")]
        public string ServiceName { get; set; } = null!;

        [Display(Name = "Тариф за м²")]
        public decimal? RatePerSqMeter { get; set; }

        [Display(Name = "Тариф за особу")]
        public decimal? RatePerPerson { get; set; }

        public ICollection<TenantService> TenantServices { get; set; } = new List<TenantService>();
    }
}
