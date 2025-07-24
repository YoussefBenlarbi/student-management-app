using System;

namespace student_management_app.Models
{
    public class Student
    {
        public string StudentId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public DateTime CreatedDate { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Student()
        {
            CreatedDate = DateTime.Now;
        }

        public Student(string studentId, string firstName, string lastName, string email, string? phone = null)
        {
            StudentId = studentId ?? throw new ArgumentNullException(nameof(studentId));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone;
            CreatedDate = DateTime.Now;
        }
    }

    
}