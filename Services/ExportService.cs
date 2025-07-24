using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using student_management_app.Models;
using OfficeOpenXml;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace student_management_app.Services
{
    public class ExportService
    {
        public ExportService()
        {
            // Set EPPlus license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        #region Grade Export Methods

        public bool ExportGradesToCsv(List<Grade> grades, List<Student> students, string filePath)
        {
            try
            {
                var csv = new StringBuilder();
                
                // Add header
                csv.AppendLine("Grade ID,Student ID,Student Name,Subject,Grade Value,Grade Date,Created Date");

                // Add data
                foreach (var grade in grades)
                {
                    var student = students.Find(s => s.StudentId == grade.StudentId);
                    var studentName = student != null ? $"{student.FirstName} {student.LastName}" : "Unknown";
                    
                    csv.AppendLine($"{grade.GradeId}," +
                                 $"{grade.StudentId}," +
                                 $"\"{studentName}\"," +
                                 $"\"{grade.Subject}\"," +
                                 $"{grade.GradeValue}," +
                                 $"{grade.GradeDate:yyyy-MM-dd}," +
                                 $"{grade.CreatedDate:yyyy-MM-dd HH:mm}");
                }

                File.WriteAllText(filePath, csv.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting to CSV: {ex.Message}");
            }
        }

        public bool ExportGradesToExcel(List<Grade> grades, List<Student> students, string filePath)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Grades Report");

                    // Set headers
                    worksheet.Cells[1, 1].Value = "Grade ID";
                    worksheet.Cells[1, 2].Value = "Student ID";
                    worksheet.Cells[1, 3].Value = "Student Name";
                    worksheet.Cells[1, 4].Value = "Subject";
                    worksheet.Cells[1, 5].Value = "Grade Value";
                    worksheet.Cells[1, 6].Value = "Grade Date";
                    worksheet.Cells[1, 7].Value = "Created Date";

                    // Style headers
                    using (var range = worksheet.Cells[1, 1, 1, 7])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
                    }

                    // Add data
                    int row = 2;
                    foreach (var grade in grades)
                    {
                        var student = students.Find(s => s.StudentId == grade.StudentId);
                        var studentName = student != null ? $"{student.FirstName} {student.LastName}" : "Unknown";

                        worksheet.Cells[row, 1].Value = grade.GradeId;
                        worksheet.Cells[row, 2].Value = grade.StudentId;
                        worksheet.Cells[row, 3].Value = studentName;
                        worksheet.Cells[row, 4].Value = grade.Subject;
                        worksheet.Cells[row, 5].Value = grade.GradeValue;
                        worksheet.Cells[row, 6].Value = grade.GradeDate.ToString("yyyy-MM-dd");
                        worksheet.Cells[row, 7].Value = grade.CreatedDate.ToString("yyyy-MM-dd HH:mm");
                        row++;
                    }

                    // Auto-fit columns
                    worksheet.Cells.AutoFitColumns();

                    // Add summary section
                    if (grades.Count > 0)
                    {
                        row += 2;
                        worksheet.Cells[row, 1].Value = "Summary Statistics:";
                        worksheet.Cells[row, 1].Style.Font.Bold = true;
                        
                        row++;
                        worksheet.Cells[row, 1].Value = "Total Grades:";
                        worksheet.Cells[row, 2].Value = grades.Count;
                        
                        row++;
                        worksheet.Cells[row, 1].Value = "Average Grade:";
                        var avgGrade = grades.Average(g => (double)g.GradeValue);
                        worksheet.Cells[row, 2].Value = Math.Round(avgGrade, 2);
                        
                        row++;
                        worksheet.Cells[row, 1].Value = "Highest Grade:";
                        worksheet.Cells[row, 2].Value = grades.Max(g => g.GradeValue);
                        
                        row++;
                        worksheet.Cells[row, 1].Value = "Lowest Grade:";
                        worksheet.Cells[row, 2].Value = grades.Min(g => g.GradeValue);
                    }

                    // Save the file
                    var fileInfo = new FileInfo(filePath);
                    package.SaveAs(fileInfo);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting to Excel: {ex.Message}");
            }
        }

        public bool ExportGradesToPdf(List<Grade> grades, List<Student> students, string filePath)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    var document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
                    var writer = PdfWriter.GetInstance(document, stream);
                    
                    document.Open();

                    // Add title
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                    var title = new Paragraph("Grades Report", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    document.Add(title);

                    // Add generation date
                    var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
                    var dateInfo = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm}", dateFont);
                    dateInfo.Alignment = Element.ALIGN_RIGHT;
                    dateInfo.SpacingAfter = 20;
                    document.Add(dateInfo);

                    // Create table
                    var table = new PdfPTable(7);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 10, 15, 25, 20, 12, 15, 18 });

                    // Add headers
                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                    var headers = new string[] { "Grade ID", "Student ID", "Student Name", "Subject", "Grade", "Grade Date", "Created Date" };
                    
                    foreach (var header in headers)
                    {
                        var cell = new PdfPCell(new Phrase(header, headerFont));
                        cell.BackgroundColor = BaseColor.DARK_GRAY;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.Padding = 5;
                        table.AddCell(cell);
                    }

                    // Add data
                    var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
                    foreach (var grade in grades)
                    {
                        var student = students.Find(s => s.StudentId == grade.StudentId);
                        var studentName = student != null ? $"{student.FirstName} {student.LastName}" : "Unknown";

                        table.AddCell(new PdfPCell(new Phrase(grade.GradeId.ToString(), cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(grade.StudentId, cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(studentName, cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(grade.Subject, cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(grade.GradeValue.ToString("F2"), cellFont)) { Padding = 3, HorizontalAlignment = Element.ALIGN_RIGHT });
                        table.AddCell(new PdfPCell(new Phrase(grade.GradeDate.ToString("yyyy-MM-dd"), cellFont)) { Padding = 3 });
                        table.AddCell(new PdfPCell(new Phrase(grade.CreatedDate.ToString("yyyy-MM-dd HH:mm"), cellFont)) { Padding = 3 });
                    }

                    document.Add(table);

                    // Add summary
                    if (grades.Count > 0)
                    {
                        document.Add(new Paragraph("\n"));
                        
                        var summaryTitle = new Paragraph("Summary Statistics", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK));
                        summaryTitle.SpacingBefore = 20;
                        summaryTitle.SpacingAfter = 10;
                        document.Add(summaryTitle);

                        var summaryFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                        var avgGrade = grades.Average(g => (double)g.GradeValue);
                        
                        document.Add(new Paragraph($"Total Grades: {grades.Count}", summaryFont));
                        document.Add(new Paragraph($"Average Grade: {avgGrade:F2}", summaryFont));
                        document.Add(new Paragraph($"Highest Grade: {grades.Max(g => g.GradeValue):F2}", summaryFont));
                        document.Add(new Paragraph($"Lowest Grade: {grades.Min(g => g.GradeValue):F2}", summaryFont));
                    }

                    document.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting to PDF: {ex.Message}");
            }
        }

        #endregion

        #region Student Export Methods

        public bool ExportStudentsToCsv(List<Student> students, string filePath)
        {
            try
            {
                var csv = new StringBuilder();
                
                // Add header
                csv.AppendLine("Student ID,First Name,Last Name,Email,Phone,Created Date");

                // Add data
                foreach (var student in students)
                {
                    csv.AppendLine($"{student.StudentId}," +
                                 $"\"{student.FirstName}\"," +
                                 $"\"{student.LastName}\"," +
                                 $"\"{student.Email}\"," +
                                 $"\"{student.Phone ?? ""}\"," +
                                 $"{student.CreatedDate:yyyy-MM-dd HH:mm}");
                }

                File.WriteAllText(filePath, csv.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting students to CSV: {ex.Message}");
            }
        }

        public bool ExportStudentsToExcel(List<Student> students, string filePath)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Students Report");

                    // Set headers
                    worksheet.Cells[1, 1].Value = "Student ID";
                    worksheet.Cells[1, 2].Value = "First Name";
                    worksheet.Cells[1, 3].Value = "Last Name";
                    worksheet.Cells[1, 4].Value = "Email";
                    worksheet.Cells[1, 5].Value = "Phone";
                    worksheet.Cells[1, 6].Value = "Created Date";

                    // Style headers
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
                    }

                    // Add data
                    int row = 2;
                    foreach (var student in students)
                    {
                        worksheet.Cells[row, 1].Value = student.StudentId;
                        worksheet.Cells[row, 2].Value = student.FirstName;
                        worksheet.Cells[row, 3].Value = student.LastName;
                        worksheet.Cells[row, 4].Value = student.Email;
                        worksheet.Cells[row, 5].Value = student.Phone ?? "";
                        worksheet.Cells[row, 6].Value = student.CreatedDate.ToString("yyyy-MM-dd HH:mm");
                        row++;
                    }

                    // Auto-fit columns
                    worksheet.Cells.AutoFitColumns();

                    // Add summary
                    row += 2;
                    worksheet.Cells[row, 1].Value = "Total Students:";
                    worksheet.Cells[row, 1].Style.Font.Bold = true;
                    worksheet.Cells[row, 2].Value = students.Count;

                    // Save the file
                    var fileInfo = new FileInfo(filePath);
                    package.SaveAs(fileInfo);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting students to Excel: {ex.Message}");
            }
        }

        #endregion

        #region Combined Reports

        public bool ExportFullReportToExcel(List<Student> students, List<Grade> grades, string filePath)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    // Students worksheet
                    var studentsSheet = package.Workbook.Worksheets.Add("Students");
                    AddStudentsToWorksheet(studentsSheet, students);

                    // Grades worksheet
                    var gradesSheet = package.Workbook.Worksheets.Add("Grades");
                    AddGradesToWorksheet(gradesSheet, grades, students);

                    // Summary worksheet
                    var summarySheet = package.Workbook.Worksheets.Add("Summary");
                    AddSummaryToWorksheet(summarySheet, students, grades);

                    // Save the file
                    var fileInfo = new FileInfo(filePath);
                    package.SaveAs(fileInfo);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting full report to Excel: {ex.Message}");
            }
        }

        private void AddStudentsToWorksheet(ExcelWorksheet worksheet, List<Student> students)
        {
            // Headers
            worksheet.Cells[1, 1].Value = "Student ID";
            worksheet.Cells[1, 2].Value = "First Name";
            worksheet.Cells[1, 3].Value = "Last Name";
            worksheet.Cells[1, 4].Value = "Email";
            worksheet.Cells[1, 5].Value = "Phone";
            worksheet.Cells[1, 6].Value = "Created Date";

            // Style headers
            using (var range = worksheet.Cells[1, 1, 1, 6])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
            }

            // Data
            int row = 2;
            foreach (var student in students)
            {
                worksheet.Cells[row, 1].Value = student.StudentId;
                worksheet.Cells[row, 2].Value = student.FirstName;
                worksheet.Cells[row, 3].Value = student.LastName;
                worksheet.Cells[row, 4].Value = student.Email;
                worksheet.Cells[row, 5].Value = student.Phone ?? "";
                worksheet.Cells[row, 6].Value = student.CreatedDate.ToString("yyyy-MM-dd HH:mm");
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }

        private void AddGradesToWorksheet(ExcelWorksheet worksheet, List<Grade> grades, List<Student> students)
        {
            // Headers
            worksheet.Cells[1, 1].Value = "Grade ID";
            worksheet.Cells[1, 2].Value = "Student ID";
            worksheet.Cells[1, 3].Value = "Student Name";
            worksheet.Cells[1, 4].Value = "Subject";
            worksheet.Cells[1, 5].Value = "Grade Value";
            worksheet.Cells[1, 6].Value = "Grade Date";
            worksheet.Cells[1, 7].Value = "Created Date";

            // Style headers
            using (var range = worksheet.Cells[1, 1, 1, 7])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
            }

            // Data
            int row = 2;
            foreach (var grade in grades)
            {
                var student = students.Find(s => s.StudentId == grade.StudentId);
                var studentName = student != null ? $"{student.FirstName} {student.LastName}" : "Unknown";

                worksheet.Cells[row, 1].Value = grade.GradeId;
                worksheet.Cells[row, 2].Value = grade.StudentId;
                worksheet.Cells[row, 3].Value = studentName;
                worksheet.Cells[row, 4].Value = grade.Subject;
                worksheet.Cells[row, 5].Value = grade.GradeValue;
                worksheet.Cells[row, 6].Value = grade.GradeDate.ToString("yyyy-MM-dd");
                worksheet.Cells[row, 7].Value = grade.CreatedDate.ToString("yyyy-MM-dd HH:mm");
                row++;
            }

            worksheet.Cells.AutoFitColumns();
        }

        private void AddSummaryToWorksheet(ExcelWorksheet worksheet, List<Student> students, List<Grade> grades)
        {
            worksheet.Cells[1, 1].Value = "Student Management System - Summary Report";
            worksheet.Cells[1, 1].Style.Font.Bold = true;
            worksheet.Cells[1, 1].Style.Font.Size = 16;

            worksheet.Cells[3, 1].Value = "Generated on:";
            worksheet.Cells[3, 2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            worksheet.Cells[5, 1].Value = "Students Statistics:";
            worksheet.Cells[5, 1].Style.Font.Bold = true;
            worksheet.Cells[6, 1].Value = "Total Students:";
            worksheet.Cells[6, 2].Value = students.Count;

            worksheet.Cells[8, 1].Value = "Grades Statistics:";
            worksheet.Cells[8, 1].Style.Font.Bold = true;
            worksheet.Cells[9, 1].Value = "Total Grades:";
            worksheet.Cells[9, 2].Value = grades.Count;

            if (grades.Count > 0)
            {
                var avgGrade = grades.Average(g => (double)g.GradeValue);
                worksheet.Cells[10, 1].Value = "Average Grade:";
                worksheet.Cells[10, 2].Value = Math.Round(avgGrade, 2);
                worksheet.Cells[11, 1].Value = "Highest Grade:";
                worksheet.Cells[11, 2].Value = grades.Max(g => g.GradeValue);
                worksheet.Cells[12, 1].Value = "Lowest Grade:";
                worksheet.Cells[12, 2].Value = grades.Min(g => g.GradeValue);
            }

            worksheet.Cells.AutoFitColumns();
        }

        #endregion
    }
}