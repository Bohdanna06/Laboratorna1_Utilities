using System.Diagnostics;
using Laboratorna3_Utilities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorna3_Utilities.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.TenantServices
                        .Select(ts => new TenantServiceViewModel
                        {
                            Особовий_рахунок = ts.Tenant.AccountNumber,
                            ПІБ = ts.Tenant.FullName,
                            Адреса = ts.Tenant.Address,
                            Мешканців = ts.Tenant.OccupantsCount,
                            Площа_м2 = ts.Tenant.Area,
                            Послуга = ts.Service.ServiceName,
                            Тариф_за_м2 = ts.Service.RatePerSqMeter ?? 0,
                            Тариф_за_особу = ts.Service.RatePerPerson ?? 0,
                            Нараховано_грн = ts.Service.RatePerSqMeter.HasValue && ts.Service.RatePerSqMeter > 0
                                ? ts.Tenant.Area * ts.Service.RatePerSqMeter.Value
                                : ts.Tenant.OccupantsCount * (ts.Service.RatePerPerson ?? 0)
                        })
                        .OrderBy(x => x.Особовий_рахунок)
                        .ToList();
            return View(data ?? new List<TenantServiceViewModel>());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
