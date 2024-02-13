using Microsoft.AspNetCore.Mvc;

namespace AtomicLists.Controllers;

public class AnalysisController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}