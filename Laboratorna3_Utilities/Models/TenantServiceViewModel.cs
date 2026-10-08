namespace Laboratorna3_Utilities.Models
{
    public class TenantServiceViewModel
    {
        public string Особовий_рахунок { get; set; } = null!;
        public string ПІБ { get; set; } = null!;
        public string Адреса { get; set; } = null!;
        public int Мешканців { get; set; }
        public decimal Площа_м2 { get; set; }
        public string Послуга { get; set; } = null!;
        public decimal Тариф_за_м2 { get; set; }
        public decimal Тариф_за_особу { get; set; }
        public decimal Нараховано_грн { get; set; }
    }
}