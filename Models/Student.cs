using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a course.")]
    [StringLength(60, ErrorMessage = "Course cannot exceed 60 characters.")]
    public string Course { get; set; } = string.Empty;

    // Nullable so [Required] works (an int would silently default to 0)
    [Required(ErrorMessage = "Semester is required.")]
    [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8.")]
    public int? Semester { get; set; }
}
