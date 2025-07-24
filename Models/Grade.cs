using System;

namespace student_management_app.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public decimal GradeValue { get; set; }
        public DateTime GradeDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Grade()
        {
            GradeDate = DateTime.Now.Date;
            CreatedDate = DateTime.Now;
        }

        public Grade(string studentId, string subject, decimal gradeValue, DateTime gradeDate)
        {
            StudentId = studentId ?? throw new ArgumentNullException(nameof(studentId));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            GradeValue = gradeValue;
            GradeDate = gradeDate;
            CreatedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Subject}: {GradeValue} ({GradeDate:yyyy-MM-dd})";
        }
    }
}