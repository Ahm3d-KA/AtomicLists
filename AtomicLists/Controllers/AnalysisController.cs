using AtomicLists.Data;
using AtomicLists.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtomicLists.Controllers;

public class AnalysisController : Controller
{
    private readonly ApplicationDbContext _db;

    public AnalysisController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        Stats? objStats = _db.UserStats.Find(1);
        return View(objStats);
    }
    // ONE TIME GET
    public IActionResult Create()
    {
        Stats objStats = new Stats();
        objStats.TotalTasks = 0;
        objStats.TotalCompleted = 0;
        objStats.TotalIncomplete = 0;
        objStats.Username = "Ahm3d_KA";
        objStats.Password = "1234";
        _db.UserStats.Add(objStats);
        _db.SaveChanges();
        return RedirectToAction("Index", "Analysis");
    }
}