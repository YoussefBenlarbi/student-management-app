using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using student_management_app.Models;

namespace student_management_app.DataAccess
{
    public class StudentDAL
    {
        private readonly DatabaseConnection dbConnection;

        public StudentDAL()
        {
            dbConnection = new DatabaseConnection();
        }

        // Get all students
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT student_id, first_name, last_name, email, phone, created_date FROM students ORDER BY last_name, first_name";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                StudentId = reader["student_id"].ToString(),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"].ToString(),
                                CreatedDate = Convert.ToDateTime(reader["created_date"])
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving students: {ex.Message}");
            }

            return students;
        }

        // Get student by ID
        public Student GetStudentById(string studentId)
        {
            Student student = null;

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT student_id, first_name, last_name, email, phone, created_date FROM students WHERE student_id = @studentId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                student = new Student
                                {
                                    StudentId = reader["student_id"].ToString(),
                                    FirstName = reader["first_name"].ToString(),
                                    LastName = reader["last_name"].ToString(),
                                    Email = reader["email"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    CreatedDate = Convert.ToDateTime(reader["created_date"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving student: {ex.Message}");
            }

            return student;
        }

        // Add new student
        public bool AddStudent(Student student)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO students (student_id, first_name, last_name, email, phone, created_date) 
                                   VALUES (@studentId, @firstName, @lastName, @email, @phone, @createdDate)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", student.StudentId);
                        command.Parameters.AddWithValue("@firstName", student.FirstName);
                        command.Parameters.AddWithValue("@lastName", student.LastName);
                        command.Parameters.AddWithValue("@email", student.Email);
                        command.Parameters.AddWithValue("@phone", student.Phone ?? "");
                        command.Parameters.AddWithValue("@createdDate", student.CreatedDate);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding student: {ex.Message}");
            }
        }

        // Update student
        public bool UpdateStudent(Student student)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE students 
                                   SET first_name = @firstName, last_name = @lastName, 
                                       email = @email, phone = @phone 
                                   WHERE student_id = @studentId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", student.StudentId);
                        command.Parameters.AddWithValue("@firstName", student.FirstName);
                        command.Parameters.AddWithValue("@lastName", student.LastName);
                        command.Parameters.AddWithValue("@email", student.Email);
                        command.Parameters.AddWithValue("@phone", student.Phone ?? "");

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating student: {ex.Message}");
            }
        }

        // Delete student
        public bool DeleteStudent(string studentId)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    // Note: Due to CASCADE DELETE, this will also delete associated grades
                    string query = "DELETE FROM students WHERE student_id = @studentId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting student: {ex.Message}");
            }
        }

        // Search students by name or email
        public List<Student> SearchStudents(string searchTerm)
        {
            List<Student> students = new List<Student>();

            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT student_id, first_name, last_name, email, phone, created_date 
                                   FROM students 
                                   WHERE first_name LIKE @searchTerm 
                                      OR last_name LIKE @searchTerm 
                                      OR email LIKE @searchTerm 
                                      OR student_id LIKE @searchTerm
                                   ORDER BY last_name, first_name";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student student = new Student
                                {
                                    StudentId = reader["student_id"].ToString(),
                                    FirstName = reader["first_name"].ToString(),
                                    LastName = reader["last_name"].ToString(),
                                    Email = reader["email"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    CreatedDate = Convert.ToDateTime(reader["created_date"])
                                };
                                students.Add(student);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching students: {ex.Message}");
            }

            return students;
        }

        // Check if student ID exists
        public bool StudentExists(string studentId)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM students WHERE student_id = @studentId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking student existence: {ex.Message}");
            }
        }

        // Check if email exists (for validation)
        public bool EmailExists(string email, string excludeStudentId = null)
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM students WHERE email = @email";

                    if (!string.IsNullOrEmpty(excludeStudentId))
                    {
                        query += " AND student_id != @excludeStudentId";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        if (!string.IsNullOrEmpty(excludeStudentId))
                        {
                            command.Parameters.AddWithValue("@excludeStudentId", excludeStudentId);
                        }

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking email existence: {ex.Message}");
            }
        }
    }
}