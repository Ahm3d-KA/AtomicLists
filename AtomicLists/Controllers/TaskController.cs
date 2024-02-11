using AtomicLists.Data;
using Microsoft.AspNetCore.Mvc;
using Task = AtomicLists.Models.Task;

namespace AtomicLists.Controllers;

public class TaskController : Controller
{
    private readonly ApplicationDbContext _db;

    public TaskController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET
    public IActionResult Index()
    {
        IEnumerable<Task> objTasksList = _db.UserTasks;

        return View(objTasksList);
    }
    
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public IActionResult Create(Task newTask)
    // {
    //     // You can add server side validation here
    //     if (ModelState.IsValid)
    //     {
    //         // Add the new task to the database
    //         _db.UserTasks.Add(newTask);
    //         _db.SaveChanges();
    //         return RedirectToAction("Index", "Task");
    //     }
    //     else
    //     {
    //         return View(newTask);
    //     }
    //     
    //     
    //
    //     
    // }
    public IActionResult Create()
    {
        return View();
    }

}