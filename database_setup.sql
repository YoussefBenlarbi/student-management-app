-- Student Management Database Setup Script
-- Run this script in your MySQL server to create the required database and tables

CREATE DATABASE IF NOT EXISTS student_management;
USE student_management;

-- Create students table
CREATE TABLE IF NOT EXISTS students (
    student_id VARCHAR(20) PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    phone VARCHAR(20),
    created_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Create grades table
CREATE TABLE IF NOT EXISTS grades (
    grade_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id VARCHAR(20) NOT NULL,
    subject VARCHAR(100) NOT NULL,
    grade_value DECIMAL(5,2) NOT NULL,
    grade_date DATE NOT NULL,
    created_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE
);

-- Create indexes for better performance
CREATE INDEX idx_students_email ON students(email);
CREATE INDEX idx_students_name ON students(last_name, first_name);
CREATE INDEX idx_grades_student_id ON grades(student_id);
CREATE INDEX idx_grades_subject ON grades(subject);
CREATE INDEX idx_grades_date ON grades(grade_date);

-- Insert sample data (optional)
INSERT INTO students (student_id, first_name, last_name, email, phone) VALUES
('STU001', 'John', 'Doe', 'john.doe@email.com', '123-456-7890'),
('STU002', 'Jane', 'Smith', 'jane.smith@email.com', '098-765-4321'),
('STU003', 'Bob', 'Johnson', 'bob.johnson@email.com', '555-123-4567');

INSERT INTO grades (student_id, subject, grade_value, grade_date) VALUES
('STU001', 'Mathematics', 85.50, '2024-01-15'),
('STU001', 'English', 92.00, '2024-01-16'),
('STU001', 'Science', 78.75, '2024-01-17'),
('STU002', 'Mathematics', 95.00, '2024-01-15'),
('STU002', 'English', 88.50, '2024-01-16'),
('STU003', 'Science', 82.25, '2024-01-17');

SELECT 'Database setup completed successfully!' as status;