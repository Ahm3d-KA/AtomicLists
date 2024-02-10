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
    public IActionResult Create()
    {
        

        return View();
    }
}