using System.ComponentModel.DataAnnotations;

namespace Laboratorna3_Utilities
{
    //public class Tenant
    //{
    //    public int ID { get; set; }
    //    public string AccountNumber { get; set; } = null!;
    //    public string FullName { get; set; } = null!;
    //    public string Address { get; set; } = null!;
    //    public int OccupantsCount { get; set; }
    //    public decimal Area { get; set; }
    //}
    public class Tenant
    {
        public int ID { get; set; }

    [Required(ErrorMessage = "Введіть особовий рахунок")]
    [Display(Name = "Особовий рахунок")]
    public string AccountNumber { get; set; } = null!;

    [Required(ErrorMessage = "Введіть ПІБ")]
    [Display(Name = "ПІБ")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Введіть адресу")]
    [Display(Name = "Адреса")]
    public string Address { get; set; } = null!;

    [Display(Name = "Кількість мешканців")]
    public int OccupantsCount { get; set; }

    [Display(Name = "Площа (м²)")]
    public decimal Area { get; set; }

    public ICollection<TenantService> TenantServices { get; set; } = new List<TenantService>();
}
}
