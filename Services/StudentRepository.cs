using StudentRegistration.Models;

namespace StudentRegistration.Services;

public interface IStudentRepository
{
    List<Student> GetAll();
    Student? GetById(int id);
    void Add(Student student);
}

public class InMemoryStudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Aarav Patel", Email = "aarav@example.com", Course = "Computer Science", Semester = 3 },
        new Student { Id = 2, Name = "Diya Shah",   Email = "diya@example.com",  Course = "Information Technology", Semester = 5 }
    };
    private int _nextId = 3;
    private readonly object _lock = new();

    public List<Student> GetAll() { lock (_lock) return _students.ToList(); }

    public Student? GetById(int id) { lock (_lock) return _students.FirstOrDefault(s => s.Id == id); }

    public void Add(Student student)
    {
        lock (_lock)
        {
            student.Id = _nextId++;
            _students.Add(student);
        }
    }
}
