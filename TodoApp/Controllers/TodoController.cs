using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;
using System.Threading.Tasks;

public class TodoController : Controller
{
    private readonly ApplicationDbContext _context;

    public TodoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Todo
    public async Task<IActionResult> Index()
    {
        var todos = await _context.Todos.Where(t => t.Status != "archived").ToListAsync();
        return View(todos);
    }

    // GET: /Todo/Archived
    public async Task<IActionResult> Archived()
    {
        var todos = await _context.Todos.Where(t => t.Status == "archived").ToListAsync();
        return View(todos);
    }

    // POST: /Todo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string title, string description, string priority)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(priority))
        {
            return BadRequest("All fields are required.");
        }

        var todo = new Todo
        {
            Title = title,
            Description = description,
            Priority = priority,
            Status = "active", // Default status is active
            CreatedAt = DateTime.Now
        };

        _context.Add(todo);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // POST: /Todo/ChangePriority/5
    [HttpPost]
    public async Task<IActionResult> ChangePriority(int id, string newPriority)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo != null)
        {
            todo.Priority = newPriority;
            await _context.SaveChangesAsync();
        }
        return Json(new { success = true, priority = newPriority });
    }

    // POST: /Todo/ChangeStatus/5
    [HttpPost]
    public async Task<IActionResult> ChangeStatus(int id, string newStatus)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo != null)
        {
            todo.Status = newStatus;
            if (newStatus == "finished")
            {
                todo.FinishedAt = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }
        return Json(new { success = true, status = newStatus });
    }
}
