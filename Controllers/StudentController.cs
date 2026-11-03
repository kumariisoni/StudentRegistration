using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentRegistration.Models;
using StudentRegistration.Services;

namespace StudentRegistration.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository _repo;

    private static readonly string[] Courses =
    {
        "Computer Science", "Information Technology", "Electronics",
        "Mechanical Engineering", "Business Administration"
    };

    public StudentController(IStudentRepository repo) => _repo = repo;

    // GET /Student  -> list of students (Model passed to the view)
    public IActionResult Index()
    {
        var students = _repo.GetAll();
        ViewBag.Total = students.Count;          // extra data via ViewBag
        return View(students);
    }

    // GET /Student/Create -> empty form
    [HttpGet]
    public IActionResult Create()
    {
        LoadCourses();
        return View();
    }

    // POST /Student/Create -> model binding + validation
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name,Email,Course,Semester")] Student student)
    {
        // Extra server-side rule beyond data annotations
        if (!string.IsNullOrWhiteSpace(student.Email) &&
            _repo.GetAll().Any(s => s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError(nameof(Student.Email), "This email is already registered.");
        }

        if (!ModelState.IsValid)
        {
            LoadCourses(student.Course);
            return View(student);                // redisplay with errors
        }

        _repo.Add(student);
        TempData["Success"] = $"{student.Name} was registered successfully.";
        return RedirectToAction(nameof(Details), new { id = student.Id });
    }

    // GET /Student/Details/5
    public IActionResult Details(int id)
    {
        var student = _repo.GetById(id);
        if (student == null) return NotFound();
        return View(student);
    }

    private void LoadCourses(string? selected = null) =>
        ViewBag.Courses = new SelectList(Courses, selected);
}
