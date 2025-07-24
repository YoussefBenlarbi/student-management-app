using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using student_management_app.Models;

namespace student_management_app.DataAccess
{
    public class GradeDAL
    {
        private readonly DatabaseConnection dbConnection;

        public GradeDAL()
        {
            dbConnection = new DatabaseConnection();
        }

        // Get all grades
        public List<Grade> GetAllGrades()
        {
            List<Grade> grades = new List<Grade>();

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT grade_id, student_id, subject, grade_value, grade_date, created_date FROM grades ORDER BY grade_date DESC";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Grade grade = new Grade
                            {
                                GradeId = Convert.ToInt32(reader["grade_id"]),
                                StudentId = reader["student_id"].ToString() ?? "",
                                Subject = reader["subject"].ToString() ?? "",
                                GradeValue = Convert.ToDecimal(reader["grade_value"]),
                                GradeDate = Convert.ToDateTime(reader["grade_date"]),
                                CreatedDate = Convert.ToDateTime(reader["created_date"])
                            };
                            grades.Add(grade);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving grades: {ex.Message}");
            }

            return grades;
        }

        // Get grades by student ID
        public List<Grade> GetGradesByStudentId(string studentId)
        {
            List<Grade> grades = new List<Grade>();

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT grade_id, student_id, subject, grade_value, grade_date, created_date FROM grades WHERE student_id = @studentId ORDER BY grade_date DESC";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Grade grade = new Grade
                                {
                                    GradeId = Convert.ToInt32(reader["grade_id"]),
                                    StudentId = reader["student_id"].ToString() ?? "",
                                    Subject = reader["subject"].ToString() ?? "",
                                    GradeValue = Convert.ToDecimal(reader["grade_value"]),
                                    GradeDate = Convert.ToDateTime(reader["grade_date"]),
                                    CreatedDate = Convert.ToDateTime(reader["created_date"])
                                };
                                grades.Add(grade);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving grades for student: {ex.Message}");
            }

            return grades;
        }

        // Get grade by ID
        public Grade? GetGradeById(int gradeId)
        {
            Grade? grade = null;

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT grade_id, student_id, subject, grade_value, grade_date, created_date FROM grades WHERE grade_id = @gradeId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@gradeId", gradeId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                grade = new Grade
                                {
                                    GradeId = Convert.ToInt32(reader["grade_id"]),
                                    StudentId = reader["student_id"].ToString() ?? "",
                                    Subject = reader["subject"].ToString() ?? "",
                                    GradeValue = Convert.ToDecimal(reader["grade_value"]),
                                    GradeDate = Convert.ToDateTime(reader["grade_date"]),
                                    CreatedDate = Convert.ToDateTime(reader["created_date"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving grade: {ex.Message}");
            }

            return grade;
        }

        // Add new grade
        public bool AddGrade(Grade grade)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO grades (student_id, subject, grade_value, grade_date, created_date) 
                                   VALUES (@studentId, @subject, @gradeValue, @gradeDate, @createdDate)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", grade.StudentId);
                        command.Parameters.AddWithValue("@subject", grade.Subject);
                        command.Parameters.AddWithValue("@gradeValue", grade.GradeValue);
                        command.Parameters.AddWithValue("@gradeDate", grade.GradeDate);
                        command.Parameters.AddWithValue("@createdDate", grade.CreatedDate);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding grade: {ex.Message}");
            }
        }

        // Update grade
        public bool UpdateGrade(Grade grade)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE grades 
                                   SET student_id = @studentId, subject = @subject, 
                                       grade_value = @gradeValue, grade_date = @gradeDate 
                                   WHERE grade_id = @gradeId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@gradeId", grade.GradeId);
                        command.Parameters.AddWithValue("@studentId", grade.StudentId);
                        command.Parameters.AddWithValue("@subject", grade.Subject);
                        command.Parameters.AddWithValue("@gradeValue", grade.GradeValue);
                        command.Parameters.AddWithValue("@gradeDate", grade.GradeDate);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating grade: {ex.Message}");
            }
        }

        // Delete grade
        public bool DeleteGrade(int gradeId)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM grades WHERE grade_id = @gradeId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@gradeId", gradeId);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting grade: {ex.Message}");
            }
        }

        // Get grades by subject
        public List<Grade> GetGradesBySubject(string subject)
        {
            List<Grade> grades = new List<Grade>();

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT grade_id, student_id, subject, grade_value, grade_date, created_date FROM grades WHERE subject LIKE @subject ORDER BY grade_date DESC";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@subject", $"%{subject}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Grade grade = new Grade
                                {
                                    GradeId = Convert.ToInt32(reader["grade_id"]),
                                    StudentId = reader["student_id"].ToString() ?? "",
                                    Subject = reader["subject"].ToString() ?? "",
                                    GradeValue = Convert.ToDecimal(reader["grade_value"]),
                                    GradeDate = Convert.ToDateTime(reader["grade_date"]),
                                    CreatedDate = Convert.ToDateTime(reader["created_date"])
                                };
                                grades.Add(grade);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving grades by subject: {ex.Message}");
            }

            return grades;
        }

        // Get average grade for a student
        public decimal GetAverageGradeForStudent(string studentId)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT AVG(grade_value) FROM grades WHERE student_id = @studentId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);
                        
                        object result = command.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculating average grade: {ex.Message}");
            }
        }

        // Get all distinct subjects
        public List<string> GetAllSubjects()
        {
            List<string> subjects = new List<string>();

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT subject FROM grades ORDER BY subject";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(reader["subject"].ToString() ?? "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving subjects: {ex.Message}");
            }

            return subjects;
        }

        // Get grades with student information for better reporting
        public List<(Grade Grade, Student Student)> GetGradesWithStudentInfo()
        {
            List<(Grade, Student)> gradesWithStudents = new List<(Grade, Student)>();

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT g.grade_id, g.student_id, g.subject, g.grade_value, g.grade_date, g.created_date,
                                           s.first_name, s.last_name, s.email, s.phone, s.created_date as student_created_date
                                    FROM grades g 
                                    JOIN students s ON g.student_id = s.student_id 
                                    ORDER BY g.grade_date DESC";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var grade = new Grade
                            {
                                GradeId = Convert.ToInt32(reader["grade_id"]),
                                StudentId = reader["student_id"].ToString() ?? "",
                                Subject = reader["subject"].ToString() ?? "",
                                GradeValue = Convert.ToDecimal(reader["grade_value"]),
                                GradeDate = Convert.ToDateTime(reader["grade_date"]),
                                CreatedDate = Convert.ToDateTime(reader["created_date"])
                            };

                            var student = new Student
                            {
                                StudentId = reader["student_id"].ToString() ?? "",
                                FirstName = reader["first_name"].ToString() ?? "",
                                LastName = reader["last_name"].ToString() ?? "",
                                Email = reader["email"].ToString() ?? "",
                                Phone = reader["phone"].ToString(),
                                CreatedDate = Convert.ToDateTime(reader["student_created_date"])
                            };

                            gradesWithStudents.Add((grade, student));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving grades with student info: {ex.Message}");
            }

            return gradesWithStudents;
        }

        // Get grade statistics
        public (int TotalGrades, decimal AverageGrade, decimal HighestGrade, decimal LowestGrade) GetGradeStatistics()
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) as total, AVG(grade_value) as average, MAX(grade_value) as highest, MIN(grade_value) as lowest FROM grades";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                TotalGrades: Convert.ToInt32(reader["total"]),
                                AverageGrade: reader["average"] != DBNull.Value ? Convert.ToDecimal(reader["average"]) : 0,
                                HighestGrade: reader["highest"] != DBNull.Value ? Convert.ToDecimal(reader["highest"]) : 0,
                                LowestGrade: reader["lowest"] != DBNull.Value ? Convert.ToDecimal(reader["lowest"]) : 0
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving grade statistics: {ex.Message}");
            }

            return (0, 0, 0, 0);
        }

        // Get top performing students
        public List<(string StudentId, string StudentName, decimal AverageGrade)> GetTopPerformingStudents(int limit = 10)
        {
            List<(string, string, decimal)> topStudents = new List<(string, string, decimal)>();

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT g.student_id, 
                                           CONCAT(s.first_name, ' ', s.last_name) as student_name,
                                           AVG(g.grade_value) as average_grade
                                    FROM grades g 
                                    JOIN students s ON g.student_id = s.student_id 
                                    GROUP BY g.student_id, student_name
                                    ORDER BY average_grade DESC 
                                    LIMIT @limit";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@limit", limit);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                topStudents.Add((
                                    reader["student_id"].ToString() ?? "",
                                    reader["student_name"].ToString() ?? "",
                                    Convert.ToDecimal(reader["average_grade"])
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving top performing students: {ex.Message}");
            }

            return topStudents;
        }
    }
}