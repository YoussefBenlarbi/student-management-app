namespace student_management_app
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Main containers
        private Panel pnlMain;
        private SplitContainer splitMain;
        private SplitContainer splitLeft;
        private SplitContainer splitRight;
        
        // Student section controls
        private GroupBox grpStudentSection;
        private DataGridView dgvStudents;
        private GroupBox grpStudentDetails;
        private GroupBox grpStudentActions;
        private TextBox txtStudentId;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtSearchStudent;
        private Label lblStudentId;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblSearchStudent;
        private Label lblStudentTitle;
        private Button btnAddStudent;
        private Button btnUpdateStudent;
        private Button btnDeleteStudent;
        private Button btnClearStudent;
        private Button btnSearchStudent;
        private Button btnRefreshStudents;
        private Button btnExportStudentsCSV;
        private Button btnExportStudentsExcel;
        
        // Grade section controls
        private GroupBox grpGradeSection;
        private DataGridView dgvGrades;
        private GroupBox grpGradeDetails;
        private GroupBox grpGradeActions;
        private ComboBox cmbStudentForGrade;
        private TextBox txtSubject;
        private NumericUpDown nudGradeValue;
        private DateTimePicker dtpGradeDate;
        private TextBox txtSearchGrade;
        private Label lblStudentForGrade;
        private Label lblSubject;
        private Label lblGradeValue;
        private Label lblGradeDate;
        private Label lblSearchGrade;
        private Label lblGradeTitle;
        private Button btnAddGrade;
        private Button btnUpdateGrade;
        private Button btnDeleteGrade;
        private Button btnClearGrade;
        private Button btnSearchGrade;
        private Button btnRefreshGrades;
        private Button btnExportGradesCSV;
        private Button btnExportGradesExcel;
        private Button btnExportGradesPDF;
        private Button btnExportFullReport;
        private Label lblAverageGrade;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Initialize all controls
            this.pnlMain = new Panel();
            this.splitMain = new SplitContainer();
            this.splitLeft = new SplitContainer();
            this.splitRight = new SplitContainer();
            
            // Student section
            this.grpStudentSection = new GroupBox();
            this.dgvStudents = new DataGridView();
            this.grpStudentDetails = new GroupBox();
            this.grpStudentActions = new GroupBox();
            this.txtStudentId = new TextBox();
            this.txtFirstName = new TextBox();
            this.txtLastName = new TextBox();
            this.txtEmail = new TextBox();
            this.txtPhone = new TextBox();
            this.txtSearchStudent = new TextBox();
            this.lblStudentId = new Label();
            this.lblFirstName = new Label();
            this.lblLastName = new Label();
            this.lblEmail = new Label();
            this.lblPhone = new Label();
            this.lblSearchStudent = new Label();
            this.lblStudentTitle = new Label();
            this.btnAddStudent = new Button();
            this.btnUpdateStudent = new Button();
            this.btnDeleteStudent = new Button();
            this.btnClearStudent = new Button();
            this.btnSearchStudent = new Button();
            this.btnRefreshStudents = new Button();
            this.btnExportStudentsCSV = new Button();
            this.btnExportStudentsExcel = new Button();
            
            // Grade section
            this.grpGradeSection = new GroupBox();
            this.dgvGrades = new DataGridView();
            this.grpGradeDetails = new GroupBox();
            this.grpGradeActions = new GroupBox();
            this.cmbStudentForGrade = new ComboBox();
            this.txtSubject = new TextBox();
            this.nudGradeValue = new NumericUpDown();
            this.dtpGradeDate = new DateTimePicker();
            this.txtSearchGrade = new TextBox();
            this.lblStudentForGrade = new Label();
            this.lblSubject = new Label();
            this.lblGradeValue = new Label();
            this.lblGradeDate = new Label();
            this.lblSearchGrade = new Label();
            this.lblGradeTitle = new Label();
            this.btnAddGrade = new Button();
            this.btnUpdateGrade = new Button();
            this.btnDeleteGrade = new Button();
            this.btnClearGrade = new Button();
            this.btnSearchGrade = new Button();
            this.btnRefreshGrades = new Button();
            this.btnExportGradesCSV = new Button();
            this.btnExportGradesExcel = new Button();
            this.btnExportGradesPDF = new Button();
            this.btnExportFullReport = new Button();
            this.lblAverageGrade = new Label();

            // Suspend layout
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).BeginInit();
            this.splitLeft.Panel1.SuspendLayout();
            this.splitLeft.Panel2.SuspendLayout();
            this.splitLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            this.grpStudentSection.SuspendLayout();
            this.grpGradeSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGradeValue)).BeginInit();
            this.grpStudentDetails.SuspendLayout();
            this.grpStudentActions.SuspendLayout();
            this.grpGradeDetails.SuspendLayout();
            this.grpGradeActions.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitMain);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(10);
            this.pnlMain.Size = new Size(1400, 800);
            this.pnlMain.TabIndex = 0;

            // 
            // splitMain
            // 
            this.splitMain.Dock = DockStyle.Fill;
            this.splitMain.Location = new Point(10, 10);
            this.splitMain.Name = "splitMain";
            this.splitMain.Size = new Size(1380, 780);
            this.splitMain.SplitterDistance = 690;
            this.splitMain.TabIndex = 0;

            // 
            // splitMain.Panel1 (Students Section)
            // 
            this.splitMain.Panel1.Controls.Add(this.splitLeft);

            // 
            // splitMain.Panel2 (Grades Section)
            // 
            this.splitMain.Panel2.Controls.Add(this.splitRight);

            // 
            // splitLeft (Student Section Layout)
            // 
            this.splitLeft.Dock = DockStyle.Fill;
            this.splitLeft.Location = new Point(0, 0);
            this.splitLeft.Name = "splitLeft";
            this.splitLeft.Orientation = Orientation.Horizontal;
            this.splitLeft.Size = new Size(690, 780);
            this.splitLeft.SplitterDistance = 400;
            this.splitLeft.TabIndex = 0;

            // 
            // splitLeft.Panel1 (Student Grid)
            // 
            this.splitLeft.Panel1.Controls.Add(this.grpStudentSection);

            // 
            // splitLeft.Panel2 (Student Details)
            // 
            this.splitLeft.Panel2.Controls.Add(this.grpStudentDetails);
            this.splitLeft.Panel2.Controls.Add(this.grpStudentActions);

            // 
            // splitRight (Grade Section Layout)
            // 
            this.splitRight.Dock = DockStyle.Fill;
            this.splitRight.Location = new Point(0, 0);
            this.splitRight.Name = "splitRight";
            this.splitRight.Orientation = Orientation.Horizontal;
            this.splitRight.Size = new Size(686, 780);
            this.splitRight.SplitterDistance = 400;
            this.splitRight.TabIndex = 0;

            // 
            // splitRight.Panel1 (Grade Grid)
            // 
            this.splitRight.Panel1.Controls.Add(this.grpGradeSection);

            // 
            // splitRight.Panel2 (Grade Details)
            // 
            this.splitRight.Panel2.Controls.Add(this.grpGradeDetails);
            this.splitRight.Panel2.Controls.Add(this.grpGradeActions);

            // === STUDENT SECTION ===

            // 
            // grpStudentSection
            // 
            this.grpStudentSection.Controls.Add(this.lblStudentTitle);
            this.grpStudentSection.Controls.Add(this.lblSearchStudent);
            this.grpStudentSection.Controls.Add(this.txtSearchStudent);
            this.grpStudentSection.Controls.Add(this.btnSearchStudent);
            this.grpStudentSection.Controls.Add(this.btnRefreshStudents);
            this.grpStudentSection.Controls.Add(this.dgvStudents);
            this.grpStudentSection.Dock = DockStyle.Fill;
            this.grpStudentSection.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.grpStudentSection.Location = new Point(0, 0);
            this.grpStudentSection.Name = "grpStudentSection";
            this.grpStudentSection.Padding = new Padding(5);
            this.grpStudentSection.Size = new Size(690, 400);
            this.grpStudentSection.TabIndex = 0;
            this.grpStudentSection.TabStop = false;
            this.grpStudentSection.Text = "STUDENTS MANAGEMENT";

            // 
            // lblStudentTitle
            // 
            this.lblStudentTitle.AutoSize = true;
            this.lblStudentTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.lblStudentTitle.ForeColor = Color.DarkBlue;
            this.lblStudentTitle.Location = new Point(15, 25);
            this.lblStudentTitle.Name = "lblStudentTitle";
            this.lblStudentTitle.Size = new Size(83, 20);
            this.lblStudentTitle.TabIndex = 0;
            this.lblStudentTitle.Text = "Students";

            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new Point(15, 80);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new Size(660, 300);
            this.dgvStudents.TabIndex = 1;
            this.dgvStudents.SelectionChanged += new EventHandler(this.dgvStudents_SelectionChanged);

            // Student search controls
            this.lblSearchStudent.AutoSize = true;
            this.lblSearchStudent.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblSearchStudent.Location = new Point(15, 55);
            this.lblSearchStudent.Name = "lblSearchStudent";
            this.lblSearchStudent.Size = new Size(48, 15);
            this.lblSearchStudent.TabIndex = 2;
            this.lblSearchStudent.Text = "Search:";

            this.txtSearchStudent.Font = new Font("Microsoft Sans Serif", 9F);
            this.txtSearchStudent.Location = new Point(70, 52);
            this.txtSearchStudent.Name = "txtSearchStudent";
            this.txtSearchStudent.Size = new Size(300, 21);
            this.txtSearchStudent.TabIndex = 3;

            this.btnSearchStudent.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnSearchStudent.Location = new Point(380, 50);
            this.btnSearchStudent.Name = "btnSearchStudent";
            this.btnSearchStudent.Size = new Size(80, 25);
            this.btnSearchStudent.TabIndex = 4;
            this.btnSearchStudent.Text = "Search";
            this.btnSearchStudent.UseVisualStyleBackColor = true;
            this.btnSearchStudent.Click += new EventHandler(this.btnSearchStudent_Click);

            this.btnRefreshStudents.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnRefreshStudents.Location = new Point(470, 50);
            this.btnRefreshStudents.Name = "btnRefreshStudents";
            this.btnRefreshStudents.Size = new Size(80, 25);
            this.btnRefreshStudents.TabIndex = 5;
            this.btnRefreshStudents.Text = "Refresh";
            this.btnRefreshStudents.UseVisualStyleBackColor = true;
            this.btnRefreshStudents.Click += new EventHandler(this.btnRefreshStudents_Click);

            // 
            // grpStudentDetails
            // 
            this.grpStudentDetails.Controls.Add(this.lblStudentId);
            this.grpStudentDetails.Controls.Add(this.txtStudentId);
            this.grpStudentDetails.Controls.Add(this.lblFirstName);
            this.grpStudentDetails.Controls.Add(this.txtFirstName);
            this.grpStudentDetails.Controls.Add(this.lblLastName);
            this.grpStudentDetails.Controls.Add(this.txtLastName);
            this.grpStudentDetails.Controls.Add(this.lblEmail);
            this.grpStudentDetails.Controls.Add(this.txtEmail);
            this.grpStudentDetails.Controls.Add(this.lblPhone);
            this.grpStudentDetails.Controls.Add(this.txtPhone);
            this.grpStudentDetails.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            this.grpStudentDetails.Location = new Point(10, 10);
            this.grpStudentDetails.Name = "grpStudentDetails";
            this.grpStudentDetails.Size = new Size(350, 220);
            this.grpStudentDetails.TabIndex = 0;
            this.grpStudentDetails.TabStop = false;
            this.grpStudentDetails.Text = "Student Details";

            // Student detail controls
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblStudentId.Location = new Point(15, 30);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new Size(68, 15);
            this.lblStudentId.TabIndex = 0;
            this.lblStudentId.Text = "Student ID:";

            this.txtStudentId.Font = new Font("Microsoft Sans Serif", 9F);
            this.txtStudentId.Location = new Point(100, 27);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new Size(230, 21);
            this.txtStudentId.TabIndex = 1;

            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblFirstName.Location = new Point(15, 60);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(67, 15);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";

            this.txtFirstName.Font = new Font("Microsoft Sans Serif", 9F);
            this.txtFirstName.Location = new Point(100, 57);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(230, 21);
            this.txtFirstName.TabIndex = 3;

            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblLastName.Location = new Point(15, 90);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(66, 15);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name:";

            this.txtLastName.Font = new Font("Microsoft Sans Serif", 9F);
            this.txtLastName.Location = new Point(100, 87);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(230, 21);
            this.txtLastName.TabIndex = 5;

            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblEmail.Location = new Point(15, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 15);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";

            this.txtEmail.Font = new Font("Microsoft Sans Serif", 9F);
            this.txtEmail.Location = new Point(100, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(230, 21);
            this.txtEmail.TabIndex = 7;

            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblPhone.Location = new Point(15, 150);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(44, 15);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Phone:";

            this.txtPhone.Font = new Font("Microsoft Sans Serif", 9F);
            this.txtPhone.Location = new Point(100, 147);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new Size(230, 21);
            this.txtPhone.TabIndex = 9;

            // 
            // grpStudentActions
            // 
            this.grpStudentActions.Controls.Add(this.btnAddStudent);
            this.grpStudentActions.Controls.Add(this.btnUpdateStudent);
            this.grpStudentActions.Controls.Add(this.btnDeleteStudent);
            this.grpStudentActions.Controls.Add(this.btnClearStudent);
            this.grpStudentActions.Controls.Add(this.btnExportStudentsCSV);
            this.grpStudentActions.Controls.Add(this.btnExportStudentsExcel);
            this.grpStudentActions.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            this.grpStudentActions.Location = new Point(370, 10);
            this.grpStudentActions.Name = "grpStudentActions";
            this.grpStudentActions.Size = new Size(300, 220);
            this.grpStudentActions.TabIndex = 1;
            this.grpStudentActions.TabStop = false;
            this.grpStudentActions.Text = "Actions & Export";

            // Student action buttons
            this.btnAddStudent.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnAddStudent.Location = new Point(15, 30);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new Size(120, 30);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new EventHandler(this.btnAddStudent_Click);

            this.btnUpdateStudent.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnUpdateStudent.Location = new Point(150, 30);
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.Size = new Size(120, 30);
            this.btnUpdateStudent.TabIndex = 1;
            this.btnUpdateStudent.Text = "Update Student";
            this.btnUpdateStudent.UseVisualStyleBackColor = true;
            this.btnUpdateStudent.Click += new EventHandler(this.btnUpdateStudent_Click);

            this.btnDeleteStudent.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnDeleteStudent.Location = new Point(15, 70);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new Size(120, 30);
            this.btnDeleteStudent.TabIndex = 2;
            this.btnDeleteStudent.Text = "Delete Student";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new EventHandler(this.btnDeleteStudent_Click);

            this.btnClearStudent.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnClearStudent.Location = new Point(150, 70);
            this.btnClearStudent.Name = "btnClearStudent";
            this.btnClearStudent.Size = new Size(120, 30);
            this.btnClearStudent.TabIndex = 3;
            this.btnClearStudent.Text = "Clear Form";
            this.btnClearStudent.UseVisualStyleBackColor = true;
            this.btnClearStudent.Click += new EventHandler(this.btnClearStudent_Click);

            this.btnExportStudentsCSV.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnExportStudentsCSV.Location = new Point(15, 120);
            this.btnExportStudentsCSV.Name = "btnExportStudentsCSV";
            this.btnExportStudentsCSV.Size = new Size(120, 35);
            this.btnExportStudentsCSV.TabIndex = 4;
            this.btnExportStudentsCSV.Text = "Export to CSV";
            this.btnExportStudentsCSV.UseVisualStyleBackColor = true;
            this.btnExportStudentsCSV.Click += new EventHandler(this.btnExportStudentsCSV_Click);

            this.btnExportStudentsExcel.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnExportStudentsExcel.Location = new Point(150, 120);
            this.btnExportStudentsExcel.Name = "btnExportStudentsExcel";
            this.btnExportStudentsExcel.Size = new Size(120, 35);
            this.btnExportStudentsExcel.TabIndex = 5;
            this.btnExportStudentsExcel.Text = "Export to Excel";
            this.btnExportStudentsExcel.UseVisualStyleBackColor = true;
            this.btnExportStudentsExcel.Click += new EventHandler(this.btnExportStudentsExcel_Click);

            // === GRADE SECTION ===

            // 
            // grpGradeSection
            // 
            this.grpGradeSection.Controls.Add(this.lblGradeTitle);
            this.grpGradeSection.Controls.Add(this.lblSearchGrade);
            this.grpGradeSection.Controls.Add(this.txtSearchGrade);
            this.grpGradeSection.Controls.Add(this.btnSearchGrade);
            this.grpGradeSection.Controls.Add(this.btnRefreshGrades);
            this.grpGradeSection.Controls.Add(this.dgvGrades);
            this.grpGradeSection.Dock = DockStyle.Fill;
            this.grpGradeSection.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.grpGradeSection.Location = new Point(0, 0);
            this.grpGradeSection.Name = "grpGradeSection";
            this.grpGradeSection.Padding = new Padding(5);
            this.grpGradeSection.Size = new Size(686, 400);
            this.grpGradeSection.TabIndex = 0;
            this.grpGradeSection.TabStop = false;
            this.grpGradeSection.Text = "GRADES MANAGEMENT";

            // 
            // lblGradeTitle
            // 
            this.lblGradeTitle.AutoSize = true;
            this.lblGradeTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.lblGradeTitle.ForeColor = Color.DarkGreen;
            this.lblGradeTitle.Location = new Point(15, 25);
            this.lblGradeTitle.Name = "lblGradeTitle";
            this.lblGradeTitle.Size = new Size(67, 20);
            this.lblGradeTitle.TabIndex = 0;
            this.lblGradeTitle.Text = "Grades";

            // 
            // dgvGrades
            // 
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Location = new Point(15, 80);
            this.dgvGrades.MultiSelect = false;
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.ReadOnly = true;
            this.dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrades.Size = new Size(656, 300);
            this.dgvGrades.TabIndex = 1;
            this.dgvGrades.SelectionChanged += new EventHandler(this.dgvGrades_SelectionChanged);

            // Grade search controls
            this.lblSearchGrade.AutoSize = true;
            this.lblSearchGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblSearchGrade.Location = new Point(15, 55);
            this.lblSearchGrade.Name = "lblSearchGrade";
            this.lblSearchGrade.Size = new Size(48, 15);
            this.lblSearchGrade.TabIndex = 2;
            this.lblSearchGrade.Text = "Search:";

            this.txtSearchGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.txtSearchGrade.Location = new Point(70, 52);
            this.txtSearchGrade.Name = "txtSearchGrade";
            this.txtSearchGrade.Size = new Size(300, 21);
            this.txtSearchGrade.TabIndex = 3;

            this.btnSearchGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnSearchGrade.Location = new Point(380, 50);
            this.btnSearchGrade.Name = "btnSearchGrade";
            this.btnSearchGrade.Size = new Size(80, 25);
            this.btnSearchGrade.TabIndex = 4;
            this.btnSearchGrade.Text = "Search";
            this.btnSearchGrade.UseVisualStyleBackColor = true;
            this.btnSearchGrade.Click += new EventHandler(this.btnSearchGrade_Click);

            this.btnRefreshGrades.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnRefreshGrades.Location = new Point(470, 50);
            this.btnRefreshGrades.Name = "btnRefreshGrades";
            this.btnRefreshGrades.Size = new Size(80, 25);
            this.btnRefreshGrades.TabIndex = 5;
            this.btnRefreshGrades.Text = "Refresh";
            this.btnRefreshGrades.UseVisualStyleBackColor = true;
            this.btnRefreshGrades.Click += new EventHandler(this.btnRefreshGrades_Click);

            // 
            // grpGradeDetails
            // 
            this.grpGradeDetails.Controls.Add(this.lblStudentForGrade);
            this.grpGradeDetails.Controls.Add(this.cmbStudentForGrade);
            this.grpGradeDetails.Controls.Add(this.lblSubject);
            this.grpGradeDetails.Controls.Add(this.txtSubject);
            this.grpGradeDetails.Controls.Add(this.lblGradeValue);
            this.grpGradeDetails.Controls.Add(this.nudGradeValue);
            this.grpGradeDetails.Controls.Add(this.lblGradeDate);
            this.grpGradeDetails.Controls.Add(this.dtpGradeDate);
            this.grpGradeDetails.Controls.Add(this.lblAverageGrade);
            this.grpGradeDetails.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            this.grpGradeDetails.Location = new Point(10, 10);
            this.grpGradeDetails.Name = "grpGradeDetails";
            this.grpGradeDetails.Size = new Size(350, 220);
            this.grpGradeDetails.TabIndex = 0;
            this.grpGradeDetails.TabStop = false;
            this.grpGradeDetails.Text = "Grade Details";

            // Grade detail controls
            this.lblStudentForGrade.AutoSize = true;
            this.lblStudentForGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblStudentForGrade.Location = new Point(15, 30);
            this.lblStudentForGrade.Name = "lblStudentForGrade";
            this.lblStudentForGrade.Size = new Size(53, 15);
            this.lblStudentForGrade.TabIndex = 0;
            this.lblStudentForGrade.Text = "Student:";

            this.cmbStudentForGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudentForGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.cmbStudentForGrade.Location = new Point(100, 27);
            this.cmbStudentForGrade.Name = "cmbStudentForGrade";
            this.cmbStudentForGrade.Size = new Size(230, 23);
            this.cmbStudentForGrade.TabIndex = 1;

            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblSubject.Location = new Point(15, 60);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new Size(49, 15);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "Subject:";

            this.txtSubject.Font = new Font("Microsoft Sans Serif", 9F);
            this.txtSubject.Location = new Point(100, 57);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new Size(230, 21);
            this.txtSubject.TabIndex = 3;

            this.lblGradeValue.AutoSize = true;
            this.lblGradeValue.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblGradeValue.Location = new Point(15, 90);
            this.lblGradeValue.Name = "lblGradeValue";
            this.lblGradeValue.Size = new Size(73, 15);
            this.lblGradeValue.TabIndex = 4;
            this.lblGradeValue.Text = "Grade Value:";

            this.nudGradeValue.DecimalPlaces = 2;
            this.nudGradeValue.Font = new Font("Microsoft Sans Serif", 9F);
            this.nudGradeValue.Location = new Point(100, 87);
            this.nudGradeValue.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudGradeValue.Name = "nudGradeValue";
            this.nudGradeValue.Size = new Size(230, 21);
            this.nudGradeValue.TabIndex = 5;

            this.lblGradeDate.AutoSize = true;
            this.lblGradeDate.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblGradeDate.Location = new Point(15, 120);
            this.lblGradeDate.Name = "lblGradeDate";
            this.lblGradeDate.Size = new Size(68, 15);
            this.lblGradeDate.TabIndex = 6;
            this.lblGradeDate.Text = "Grade Date:";

            this.dtpGradeDate.Font = new Font("Microsoft Sans Serif", 9F);
            this.dtpGradeDate.Format = DateTimePickerFormat.Short;
            this.dtpGradeDate.Location = new Point(100, 117);
            this.dtpGradeDate.Name = "dtpGradeDate";
            this.dtpGradeDate.Size = new Size(230, 21);
            this.dtpGradeDate.TabIndex = 7;

            this.lblAverageGrade.AutoSize = true;
            this.lblAverageGrade.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            this.lblAverageGrade.ForeColor = Color.DarkGreen;
            this.lblAverageGrade.Location = new Point(15, 180);
            this.lblAverageGrade.Name = "lblAverageGrade";
            this.lblAverageGrade.Size = new Size(0, 15);
            this.lblAverageGrade.TabIndex = 8;

            // 
            // grpGradeActions
            // 
            this.grpGradeActions.Controls.Add(this.btnAddGrade);
            this.grpGradeActions.Controls.Add(this.btnUpdateGrade);
            this.grpGradeActions.Controls.Add(this.btnDeleteGrade);
            this.grpGradeActions.Controls.Add(this.btnClearGrade);
            this.grpGradeActions.Controls.Add(this.btnExportGradesCSV);
            this.grpGradeActions.Controls.Add(this.btnExportGradesExcel);
            this.grpGradeActions.Controls.Add(this.btnExportGradesPDF);
            this.grpGradeActions.Controls.Add(this.btnExportFullReport);
            this.grpGradeActions.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            this.grpGradeActions.Location = new Point(370, 10);
            this.grpGradeActions.Name = "grpGradeActions";
            this.grpGradeActions.Size = new Size(300, 220);
            this.grpGradeActions.TabIndex = 1;
            this.grpGradeActions.TabStop = false;
            this.grpGradeActions.Text = "Actions & Export";

            // Grade action buttons
            this.btnAddGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnAddGrade.Location = new Point(15, 30);
            this.btnAddGrade.Name = "btnAddGrade";
            this.btnAddGrade.Size = new Size(120, 30);
            this.btnAddGrade.TabIndex = 0;
            this.btnAddGrade.Text = "Add Grade";
            this.btnAddGrade.UseVisualStyleBackColor = true;
            this.btnAddGrade.Click += new EventHandler(this.btnAddGrade_Click);

            this.btnUpdateGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnUpdateGrade.Location = new Point(150, 30);
            this.btnUpdateGrade.Name = "btnUpdateGrade";
            this.btnUpdateGrade.Size = new Size(120, 30);
            this.btnUpdateGrade.TabIndex = 1;
            this.btnUpdateGrade.Text = "Update Grade";
            this.btnUpdateGrade.UseVisualStyleBackColor = true;
            this.btnUpdateGrade.Click += new EventHandler(this.btnUpdateGrade_Click);

            this.btnDeleteGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnDeleteGrade.Location = new Point(15, 70);
            this.btnDeleteGrade.Name = "btnDeleteGrade";
            this.btnDeleteGrade.Size = new Size(120, 30);
            this.btnDeleteGrade.TabIndex = 2;
            this.btnDeleteGrade.Text = "Delete Grade";
            this.btnDeleteGrade.UseVisualStyleBackColor = true;
            this.btnDeleteGrade.Click += new EventHandler(this.btnDeleteGrade_Click);

            this.btnClearGrade.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnClearGrade.Location = new Point(150, 70);
            this.btnClearGrade.Name = "btnClearGrade";
            this.btnClearGrade.Size = new Size(120, 30);
            this.btnClearGrade.TabIndex = 3;
            this.btnClearGrade.Text = "Clear Form";
            this.btnClearGrade.UseVisualStyleBackColor = true;
            this.btnClearGrade.Click += new EventHandler(this.btnClearGrade_Click);

            this.btnExportGradesCSV.Font = new Font("Microsoft Sans Serif", 8F);
            this.btnExportGradesCSV.Location = new Point(15, 120);
            this.btnExportGradesCSV.Name = "btnExportGradesCSV";
            this.btnExportGradesCSV.Size = new Size(70, 30);
            this.btnExportGradesCSV.TabIndex = 4;
            this.btnExportGradesCSV.Text = "CSV";
            this.btnExportGradesCSV.UseVisualStyleBackColor = true;
            this.btnExportGradesCSV.Click += new EventHandler(this.btnExportGradesCSV_Click);

            this.btnExportGradesExcel.Font = new Font("Microsoft Sans Serif", 8F);
            this.btnExportGradesExcel.Location = new Point(95, 120);
            this.btnExportGradesExcel.Name = "btnExportGradesExcel";
            this.btnExportGradesExcel.Size = new Size(70, 30);
            this.btnExportGradesExcel.TabIndex = 5;
            this.btnExportGradesExcel.Text = "Excel";
            this.btnExportGradesExcel.UseVisualStyleBackColor = true;
            this.btnExportGradesExcel.Click += new EventHandler(this.btnExportGradesExcel_Click);

            this.btnExportGradesPDF.Font = new Font("Microsoft Sans Serif", 8F);
            this.btnExportGradesPDF.Location = new Point(175, 120);
            this.btnExportGradesPDF.Name = "btnExportGradesPDF";
            this.btnExportGradesPDF.Size = new Size(70, 30);
            this.btnExportGradesPDF.TabIndex = 6;
            this.btnExportGradesPDF.Text = "PDF";
            this.btnExportGradesPDF.UseVisualStyleBackColor = true;
            this.btnExportGradesPDF.Click += new EventHandler(this.btnExportGradesPDF_Click);

            this.btnExportFullReport.Font = new Font("Microsoft Sans Serif", 8F);
            this.btnExportFullReport.Location = new Point(15, 160);
            this.btnExportFullReport.Name = "btnExportFullReport";
            this.btnExportFullReport.Size = new Size(150, 30);
            this.btnExportFullReport.TabIndex = 7;
            this.btnExportFullReport.Text = "Full Report (Excel)";
            this.btnExportFullReport.UseVisualStyleBackColor = true;
            this.btnExportFullReport.Click += new EventHandler(this.btnExportFullReport_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 800);
            this.Controls.Add(this.pnlMain);
            this.MinimumSize = new Size(1400, 800);
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Student Management System - Unified Interface";
            this.Load += new EventHandler(this.Form1_Load);

            // Resume layout
            this.pnlMain.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitLeft.Panel1.ResumeLayout(false);
            this.splitLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).EndInit();
            this.splitLeft.ResumeLayout(false);
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            this.grpStudentSection.ResumeLayout(false);
            this.grpStudentSection.PerformLayout();
            this.grpGradeSection.ResumeLayout(false);
            this.grpGradeSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGradeValue)).EndInit();
            this.grpStudentDetails.ResumeLayout(false);
            this.grpStudentDetails.PerformLayout();
            this.grpStudentActions.ResumeLayout(false);
            this.grpGradeDetails.ResumeLayout(false);
            this.grpGradeDetails.PerformLayout();
            this.grpGradeActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
