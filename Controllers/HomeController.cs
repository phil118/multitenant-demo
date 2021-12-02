using System.Diagnostics;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Models;

namespace MultiTenant.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var tenantInfo = HttpContext.GetMultiTenantContext<TenantViewModel>()?.TenantInfo;

        if (tenantInfo != null)
        {
            return View(tenantInfo);
        }

        return View();
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
