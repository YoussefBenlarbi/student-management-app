using student_management_app.DataAccess;
using student_management_app.Models;
using student_management_app.Services;
using System.Data;

namespace student_management_app
{
    public partial class Form1 : Form
    {
        private readonly StudentDAL studentDAL;
        private readonly GradeDAL gradeDAL;
        private readonly DatabaseConnection dbConnection;
        private readonly ExportService exportService;
        private int selectedGradeId = 0;

        public Form1()
        {
            InitializeComponent();
            studentDAL = new StudentDAL();
            gradeDAL = new GradeDAL();
            dbConnection = new DatabaseConnection();
            exportService = new ExportService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Test database connection on startup
            if (!dbConnection.TestConnection())
            {
                MessageBox.Show("Could not connect to the database. Please check your connection settings.", 
                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load initial data
            LoadStudents();
            LoadGrades();
            LoadStudentsComboBox();
        }

        #region Student Management

        private void LoadStudents()
        {
            try
            {
                var students = studentDAL.GetAllStudents();
                
                var studentTable = new DataTable();
                studentTable.Columns.Add("Student ID");
                studentTable.Columns.Add("First Name");
                studentTable.Columns.Add("Last Name");
                studentTable.Columns.Add("Email");
                studentTable.Columns.Add("Phone");
                studentTable.Columns.Add("Created Date");

                foreach (var student in students)
                {
                    studentTable.Rows.Add(
                        student.StudentId,
                        student.FirstName,
                        student.LastName,
                        student.Email,
                        student.Phone ?? "",
                        student.CreatedDate.ToString("yyyy-MM-dd HH:mm")
                    );
                }

                dgvStudents.DataSource = studentTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var row = dgvStudents.SelectedRows[0];
                txtStudentId.Text = row.Cells["Student ID"].Value?.ToString() ?? "";
                txtFirstName.Text = row.Cells["First Name"].Value?.ToString() ?? "";
                txtLastName.Text = row.Cells["Last Name"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateStudentInput())
                    return;

                if (studentDAL.StudentExists(txtStudentId.Text))
                {
                    MessageBox.Show("Student ID already exists. Please use a different ID.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (studentDAL.EmailExists(txtEmail.Text))
                {
                    MessageBox.Show("Email address already exists. Please use a different email.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var student = new Student(
                    txtStudentId.Text.Trim(),
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim()
                );

                if (studentDAL.AddStudent(student))
                {
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    LoadStudentsComboBox();
                    ClearStudentForm();
                }
                else
                {
                    MessageBox.Show("Failed to add student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentId.Text))
                {
                    MessageBox.Show("Please select a student to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateStudentInput())
                    return;

                if (studentDAL.EmailExists(txtEmail.Text, txtStudentId.Text))
                {
                    MessageBox.Show("Email address already exists for another student.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var student = new Student(
                    txtStudentId.Text.Trim(),
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim()
                );

                if (studentDAL.UpdateStudent(student))
                {
                    MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    LoadStudentsComboBox();
                    ClearStudentForm();
                }
                else
                {
                    MessageBox.Show("Failed to update student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentId.Text))
                {
                    MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Are you sure you want to delete student '{txtStudentId.Text}'?\nThis will also delete all associated grades.", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (studentDAL.DeleteStudent(txtStudentId.Text))
                    {
                        MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents();
                        LoadStudentsComboBox();
                        LoadGrades();
                        ClearStudentForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            ClearStudentForm();
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearchStudent.Text))
                {
                    LoadStudents();
                    return;
                }

                var students = studentDAL.SearchStudents(txtSearchStudent.Text.Trim());
                
                var studentTable = new DataTable();
                studentTable.Columns.Add("Student ID");
                studentTable.Columns.Add("First Name");
                studentTable.Columns.Add("Last Name");
                studentTable.Columns.Add("Email");
                studentTable.Columns.Add("Phone");
                studentTable.Columns.Add("Created Date");

                foreach (var student in students)
                {
                    studentTable.Rows.Add(
                        student.StudentId,
                        student.FirstName,
                        student.LastName,
                        student.Email,
                        student.Phone ?? "",
                        student.CreatedDate.ToString("yyyy-MM-dd HH:mm")
                    );
                }

                dgvStudents.DataSource = studentTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshStudents_Click(object sender, EventArgs e)
        {
            LoadStudents();
            txtSearchStudent.Clear();
        }

        private bool ValidateStudentInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Student ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void ClearStudentForm()
        {
            txtStudentId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            dgvStudents.ClearSelection();
        }

        #endregion

        #region Grade Management

        private void LoadGrades()
        {
            try
            {
                var grades = gradeDAL.GetAllGrades();
                
                var gradeTable = new DataTable();
                gradeTable.Columns.Add("Grade ID");
                gradeTable.Columns.Add("Student ID");
                gradeTable.Columns.Add("Subject");
                gradeTable.Columns.Add("Grade Value");
                gradeTable.Columns.Add("Grade Date");
                gradeTable.Columns.Add("Created Date");

                foreach (var grade in grades)
                {
                    gradeTable.Rows.Add(
                        grade.GradeId,
                        grade.StudentId,
                        grade.Subject,
                        grade.GradeValue,
                        grade.GradeDate.ToString("yyyy-MM-dd"),
                        grade.CreatedDate.ToString("yyyy-MM-dd HH:mm")
                    );
                }

                dgvGrades.DataSource = gradeTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudentsComboBox()
        {
            try
            {
                var students = studentDAL.GetAllStudents();
                cmbStudentForGrade.Items.Clear();
                
                foreach (var student in students)
                {
                    cmbStudentForGrade.Items.Add($"{student.StudentId} - {student.FullName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students for combo box: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGrades_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGrades.SelectedRows.Count > 0)
            {
                var row = dgvGrades.SelectedRows[0];
                selectedGradeId = Convert.ToInt32(row.Cells["Grade ID"].Value);
                
                string studentId = row.Cells["Student ID"].Value?.ToString() ?? "";
                for (int i = 0; i < cmbStudentForGrade.Items.Count; i++)
                {
                    if (cmbStudentForGrade.Items[i].ToString().StartsWith(studentId))
                    {
                        cmbStudentForGrade.SelectedIndex = i;
                        break;
                    }
                }

                txtSubject.Text = row.Cells["Subject"].Value?.ToString() ?? "";
                nudGradeValue.Value = Convert.ToDecimal(row.Cells["Grade Value"].Value ?? 0);
                dtpGradeDate.Value = Convert.ToDateTime(row.Cells["Grade Date"].Value ?? DateTime.Now);

                // Calculate and display average for this student
                try
                {
                    decimal average = gradeDAL.GetAverageGradeForStudent(studentId);
                    lblAverageGrade.Text = $"Average Grade for {studentId}: {average:F2}";
                }
                catch
                {
                    lblAverageGrade.Text = "";
                }
            }
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateGradeInput())
                    return;

                string studentId = GetSelectedStudentId();
                
                var grade = new Grade(
                    studentId,
                    txtSubject.Text.Trim(),
                    nudGradeValue.Value,
                    dtpGradeDate.Value.Date
                );

                if (gradeDAL.AddGrade(grade))
                {
                    MessageBox.Show("Grade added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrades();
                    ClearGradeForm();
                }
                else
                {
                    MessageBox.Show("Failed to add grade.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateGrade_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGradeId == 0)
                {
                    MessageBox.Show("Please select a grade to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateGradeInput())
                    return;

                string studentId = GetSelectedStudentId();

                var grade = new Grade(studentId, txtSubject.Text.Trim(), nudGradeValue.Value, dtpGradeDate.Value.Date)
                {
                    GradeId = selectedGradeId
                };

                if (gradeDAL.UpdateGrade(grade))
                {
                    MessageBox.Show("Grade updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrades();
                    ClearGradeForm();
                }
                else
                {
                    MessageBox.Show("Failed to update grade.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteGrade_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGradeId == 0)
                {
                    MessageBox.Show("Please select a grade to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this grade?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (gradeDAL.DeleteGrade(selectedGradeId))
                    {
                        MessageBox.Show("Grade deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGrades();
                        ClearGradeForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete grade.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearGrade_Click(object sender, EventArgs e)
        {
            ClearGradeForm();
        }

        private void btnSearchGrade_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearchGrade.Text))
                {
                    LoadGrades();
                    return;
                }

                var grades = gradeDAL.GetGradesBySubject(txtSearchGrade.Text.Trim());
                
                var gradeTable = new DataTable();
                gradeTable.Columns.Add("Grade ID");
                gradeTable.Columns.Add("Student ID");
                gradeTable.Columns.Add("Subject");
                gradeTable.Columns.Add("Grade Value");
                gradeTable.Columns.Add("Grade Date");
                gradeTable.Columns.Add("Created Date");

                foreach (var grade in grades)
                {
                    gradeTable.Rows.Add(
                        grade.GradeId,
                        grade.StudentId,
                        grade.Subject,
                        grade.GradeValue,
                        grade.GradeDate.ToString("yyyy-MM-dd"),
                        grade.CreatedDate.ToString("yyyy-MM-dd HH:mm")
                    );
                }

                dgvGrades.DataSource = gradeTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshGrades_Click(object sender, EventArgs e)
        {
            LoadGrades();
            txtSearchGrade.Clear();
            lblAverageGrade.Text = "";
        }

        private bool ValidateGradeInput()
        {
            if (cmbStudentForGrade.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStudentForGrade.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Subject is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubject.Focus();
                return false;
            }

            if (nudGradeValue.Value < 0 || nudGradeValue.Value > 100)
            {
                MessageBox.Show("Grade value must be between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudGradeValue.Focus();
                return false;
            }

            return true;
        }

        private void ClearGradeForm()
        {
            selectedGradeId = 0;
            cmbStudentForGrade.SelectedIndex = -1;
            txtSubject.Clear();
            nudGradeValue.Value = 0;
            dtpGradeDate.Value = DateTime.Now;
            dgvGrades.ClearSelection();
            lblAverageGrade.Text = "";
        }

        private string GetSelectedStudentId()
        {
            if (cmbStudentForGrade.SelectedIndex == -1)
                return "";

            string selectedItem = cmbStudentForGrade.SelectedItem.ToString();
            return selectedItem.Split('-')[0].Trim();
        }

        #endregion

        #region Export Functionality

        private void btnExportStudentsCSV_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveFileDialog.Title = "Export Students to CSV";
                    saveFileDialog.FileName = $"Students_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var students = studentDAL.GetAllStudents();
                        
                        if (exportService.ExportStudentsToCsv(students, saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Students exported successfully to:\n{saveFileDialog.FileName}", 
                                "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting students to CSV: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportStudentsExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Export Students to Excel";
                    saveFileDialog.FileName = $"Students_Export_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var students = studentDAL.GetAllStudents();
                        
                        if (exportService.ExportStudentsToExcel(students, saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Students exported successfully to:\n{saveFileDialog.FileName}", 
                                "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting students to Excel: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportGradesCSV_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveFileDialog.Title = "Export Grades to CSV";
                    saveFileDialog.FileName = $"Grades_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var grades = gradeDAL.GetAllGrades();
                        var students = studentDAL.GetAllStudents();
                        
                        if (exportService.ExportGradesToCsv(grades, students, saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Grades exported successfully to:\n{saveFileDialog.FileName}", 
                                "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting grades to CSV: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportGradesExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Export Grades to Excel";
                    saveFileDialog.FileName = $"Grades_Export_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var grades = gradeDAL.GetAllGrades();
                        var students = studentDAL.GetAllStudents();
                        
                        if (exportService.ExportGradesToExcel(grades, students, saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Grades exported successfully to:\n{saveFileDialog.FileName}", 
                                "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting grades to Excel: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportGradesPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Export Grades to PDF";
                    saveFileDialog.FileName = $"Grades_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var grades = gradeDAL.GetAllGrades();
                        var students = studentDAL.GetAllStudents();
                        
                        if (exportService.ExportGradesToPdf(grades, students, saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Grades report exported successfully to:\n{saveFileDialog.FileName}", 
                                "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting grades to PDF: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportFullReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Export Full Report to Excel";
                    saveFileDialog.FileName = $"Full_Report_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var students = studentDAL.GetAllStudents();
                        var grades = gradeDAL.GetAllGrades();
                        
                        if (exportService.ExportFullReportToExcel(students, grades, saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Full report exported successfully to:\n{saveFileDialog.FileName}\n\nThe report includes:\n- Students worksheet\n- Grades worksheet\n- Summary worksheet", 
                                "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting full report: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Utility Methods

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
