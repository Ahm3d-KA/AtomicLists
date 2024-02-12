using AtomicLists.Data;
using Microsoft.AspNetCore.Mvc;
using Task = AtomicLists.Models.Task;

namespace AtomicLists.Controllers;

public class TaskController : Controller
{
    private readonly ApplicationDbContext _db;
    
    // Makes database accessible to the controller
    public TaskController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET - INDEX
    public IActionResult Index()
    {
        IEnumerable<Task> objTasksList = _db.UserTasks2;

        return View(objTasksList);
    }
    
    // GET - CREATE
    public IActionResult Create()
    {
        return View();
    }
    
    // POST - CREATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Task newTask)
    {
        // You can add server side validation here
        if (ModelState.IsValid)
        {
            _db.UserTasks2.Add(newTask);
            _db.SaveChanges();
            return RedirectToAction("Index", "Task");
            
        }
        // Add the new task to the database and save changes
        
        return View();
    }
    
    // GET - EDIT
    public IActionResult Edit(int? Id)
    {
        // Checks if id exists
        if (Id == null || Id == 0)
        {
            return NotFound();
        }
        
        // Finds task and stores in variable
        var editTask = _db.UserTasks2.Find(Id);
        
        if (editTask == null)
        {
            return NotFound();
        }
        return View(editTask);
       
    }
    
    // POST - EDIT
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Task newTask)
    {
        // You can add server side validation here
        if (ModelState.IsValid)
        {
            _db.UserTasks2.Add(newTask);
            _db.SaveChanges();
            return RedirectToAction("Index", "Task");
            
        }
        // Add the new task to the database and save changes
        
        return View();
    }


}