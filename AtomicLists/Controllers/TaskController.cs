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

    // INDEX - GET
    public IActionResult Index()
    {
        IEnumerable<Task> objTasksList = _db.UserTasks2;

        return View(objTasksList);
    }
    
    // CREATE - GET
    public IActionResult Create()
    {
        return View();
    }
    
    // CREATE - POST
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
    
    // EDIT - GET
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
    
    // EDIT - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Task newTask)
    {
        // You can add server side validation here
        if (ModelState.IsValid)
        {
            _db.UserTasks2.Update(newTask);
            _db.SaveChanges();
            return RedirectToAction("Index", "Task");
            
        }
        // Add the new task to the database and save changes
        
        return View();
    }
    
    // EDIT TASK COMPLETION UPDATED - POST
    public IActionResult TaskCompletionUpdated(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var task = _db.UserTasks2.Find(id);
        if (task == null)
        {
            return NotFound();
        }
        task.IsComplete = !task.IsComplete;
        _db.UserTasks2.Update(task);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    
    // DELETE - GET
    public IActionResult Delete(int? Id)
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
    
    // DELETE - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? Id)
    {
        var deleteTask = _db.UserTasks2.Find(Id);
        _db.UserTasks2.Remove(deleteTask);
        _db.SaveChanges();
        return RedirectToAction("Index", "Task");
    }
    
    // DETAILS - GET
    public IActionResult Details(int? Id)
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


}