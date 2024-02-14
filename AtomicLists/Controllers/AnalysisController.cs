using System.Numerics;
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
    // This method is used to create a record in the database for the first time
    // HEREEEEE IS THE PROBLEMMMM
    // public IActionResult Create()
    // {
    //     Stats createTaskRecord = new Stats();
    //     createTaskRecord.TotalTasks = 0;
    //     createTaskRecord.TotalCompleted = 0;
    //     createTaskRecord.TotalIncomplete = 0;
    //     createTaskRecord.Username = "Ahm3d_KA";
    //     createTaskRecord.Password = "1234";
    //     
    //     createTaskRecord.PercentComplete = 0;
    //     createTaskRecord.AreaNames = new Vector<string>();
    //     createTaskRecord.NumberOfTasksByArea = new Vector<int>();
    //     createTaskRecord.PercentCompleteByArea = new Vector<float>();
    //     // createTaskRecord.AreaNamesSerialized = "";
    //     // createTaskRecord.NumberOfTasksByAreaSerialized = "";
    //     // createTaskRecord.PercentCompleteByAreaSerialized = "";
    //     _db.UserStats.Add(createTaskRecord);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index", "Analysis");
    // }
}