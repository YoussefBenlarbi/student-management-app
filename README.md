# Student Management Application

A comprehensive Windows Forms application built with .NET 8 for managing student records and grades using MySQL database with a unified interface and complete export capabilities.

## Features

- **Unified User Interface**
  - Side-by-side Students and Grades management in a single window
  - No tabs - both sections visible simultaneously
  - Data grids for viewing records with full-row selection
  - Organized form panels for data entry and editing
  - Search functionality across both modules
  - Real-time data validation
  - Export functionality with multiple formats

- **Student Management** (Left Panel)
  - Add, edit, delete students
  - Search students by name, email, or ID
  - Unique email validation
  - Student ID existence checking
  - Full CRUD operations with validation
  - Export students to CSV and Excel

- **Grade Management** (Right Panel)
  - Add, edit, delete grades
  - View grades by student or subject
  - Calculate average grades per student
  - Grade history tracking
  - Student selection via dropdown
  - Advanced search by subject
  - Export grades to CSV, Excel, and PDF
  - Full report generation with multiple worksheets

- **Export Capabilities**
  - **CSV Export**: Students and Grades data
  - **Excel Export**: Students, Grades, and Full Reports
  - **PDF Export**: Professional grade reports with statistics
  - **Multi-Sheet Reports**: Combined Excel reports with summary analytics

- **Database Integration**
  - MySQL database connectivity
  - Configurable connection strings
  - Connection testing on startup
  - Error handling and validation
  - Transaction support
  - Advanced analytics and reporting

## Technology Stack

- **.NET 8** - Target framework
- **Windows Forms** - UI framework with SplitContainer layout
- **MySQL** - Database
- **MySql.Data** - Database connector
- **EPPlus** - Excel export functionality
- **iTextSharp** - PDF export functionality
- **C# 12** - Programming language

## Prerequisites

- .NET 8 Runtime/SDK
- MySQL Server
- Visual Studio 2022 or later (recommended)

## Setup Instructions

1. **Database Setup**
   - Install MySQL Server
   - Run the `database_setup.sql` script to create the database and tables
   - Update connection string in `app.config` if needed

2. **Configuration**
   - Update the connection string in `app.config`:
   ```xml
   <connectionStrings>
       <add name="StudentManagementDB" 
            connectionString="Server=localhost;Database=student_management;Uid=root;Pwd=your_password;" 
            providerName="MySql.Data.MySqlClient" />
   </connectionStrings>
   ```

3. **Build and Run**
   - Open the solution in Visual Studio
   - Build the solution (Ctrl+Shift+B)
   - Run the application (F5)

## User Interface Layout

The application features a **unified, single-window interface** with:

### Left Panel - Students Management
- **Students Data Grid**: Top section showing all students
- **Student Details**: Bottom-left with input forms
- **Student Actions**: Bottom-right with CRUD and export buttons

### Right Panel - Grades Management
- **Grades Data Grid**: Top section showing all grades
- **Grade Details**: Bottom-left with input forms and average display
- **Grade Actions**: Bottom-right with CRUD and export buttons

### Interface Benefits
- **Side-by-side view**: See both students and grades simultaneously
- **No navigation needed**: Everything visible in one window
- **Logical workflow**: Select student on left, manage grades on right
- **Efficient screen usage**: Maximizes available space

## User Interface Features

### Students Section (Left Panel)
- **Data Grid**: Displays all students with sorting and selection
- **Student Details Panel**: 
  - Student ID (required, unique)
  - First Name (required)
  - Last Name (required)
  - Email (required, unique, validated)
  - Phone (optional)
- **Action Buttons**: Add Student, Update Student, Delete Student, Clear Form
- **Search Functionality**: Real-time search across all student fields
- **Export Options**:
  - Export to CSV: Simple comma-separated values format
  - Export to Excel: Formatted spreadsheet with styling
- **Refresh Button**: Reload all student data

### Grades Section (Right Panel)
- **Data Grid**: Displays all grades with student information
- **Grade Details Panel**:
  - Student Selection (dropdown with existing students)
  - Subject (required)
  - Grade Value (0-100, decimal supported)
  - Grade Date (date picker)
  - Average Grade Display (dynamic calculation)
- **Action Buttons**: Add Grade, Update Grade, Delete Grade, Clear Form
- **Search Functionality**: Search by subject name
- **Export Options**:
  - CSV: Simple grade data export
  - Excel: Formatted report with statistics
  - PDF: Professional report with charts and summaries
  - Full Report: Multi-sheet Excel with students, grades, and analytics
- **Refresh Button**: Reload all grade data

## Export Features

### CSV Export
- **Students**: Basic student information in CSV format
- **Grades**: Complete grade data with student names
- Simple format for data analysis and import into other systems

### Excel Export
- **Students**: Professional formatting with colored headers
- **Grades**: Detailed reports with student information and statistics
- **Auto-fit columns** for optimal viewing
- **Summary statistics** including averages, totals, and extremes

### PDF Export
- **Professional grade reports** with headers and footers
- **Formatted tables** with proper spacing and styling
- **Summary statistics** section with key metrics
- **Generation timestamp** for tracking

### Full Report Export
- **Multi-sheet Excel workbook** with:
  - Students worksheet with complete student data
  - Grades worksheet with detailed grade information
  - Summary worksheet with comprehensive analytics
- **Cross-references** between students and grades
- **Statistical analysis** and performance metrics

## Project Structure

```
student-management-app/
??? Models/
?   ??? Student.cs          # Student entity model
?   ??? Grade.cs            # Grade entity model
??? DataAccess/
?   ??? DatabaseConnection.cs  # Database connection manager
?   ??? StudentDAL.cs       # Student data access layer
?   ??? GradeDAL.cs         # Enhanced grade data access layer
??? Services/
?   ??? ExportService.cs    # Export functionality service
??? Form1.cs                # Main form code-behind
??? Form1.Designer.cs       # Unified interface designer code
??? Form1.resx              # Form resources
??? Program.cs              # Application entry point
??? app.config              # Configuration file
??? database_setup.sql      # Database setup script
```

## Database Schema

### Students Table
- `student_id` (VARCHAR(20), PRIMARY KEY)
- `first_name` (VARCHAR(50), NOT NULL)
- `last_name` (VARCHAR(50), NOT NULL)
- `email` (VARCHAR(100), NOT NULL, UNIQUE)
- `phone` (VARCHAR(20))
- `created_date` (DATETIME, DEFAULT CURRENT_TIMESTAMP)

### Grades Table
- `grade_id` (INT, AUTO_INCREMENT, PRIMARY KEY)
- `student_id` (VARCHAR(20), FOREIGN KEY)
- `subject` (VARCHAR(100), NOT NULL)
- `grade_value` (DECIMAL(5,2), NOT NULL)
- `grade_date` (DATE, NOT NULL)
- `created_date` (DATETIME, DEFAULT CURRENT_TIMESTAMP)

## Application Workflow

### Adding a Student
1. View students in left panel data grid
2. Fill in student details in bottom-left form
3. Click "Add Student" button
4. System validates uniqueness of ID and email
5. Student is added to database and grid refreshes

### Managing Grades
1. View grades in right panel data grid
2. Select student from dropdown in bottom-right
3. Enter subject and grade value
4. Set grade date
5. Click "Add Grade" to save
6. View average grade calculation automatically

### Unified Workflow
1. **Select student** in left panel grid
2. **View their grades** in right panel (filtered view)
3. **Add new grades** using the selected student
4. **Export data** using appropriate format buttons

### Exporting Data
1. **Single Format Export**: Click desired export button (CSV, Excel, PDF)
2. **Choose location**: Select save location and filename
3. **Automatic generation**: System creates formatted report
4. **Confirmation**: Success message with file location

### Search and Filter
- **Students**: Search by name, email, or student ID in left panel
- **Grades**: Filter by subject name with partial matching in right panel
- Clear search to view all records

## Advanced Features

### Grade Analytics
- **Average calculations** per student (displayed in real-time)
- **Top performing students** rankings
- **Subject-based analysis** and filtering
- **Statistical summaries** across all grades

### Export Analytics
- **Automatic statistics** in Excel and PDF exports
- **Performance metrics** including min, max, average grades
- **Student count** and grade distribution
- **Date-stamped reports** for tracking

### Data Integrity
- **Foreign key relationships** between students and grades
- **Cascade delete** operations (deleting student removes all grades)
- **Validation** at both UI and database levels
- **Error handling** with user-friendly messages

### Interface Benefits
- **No context switching**: Both sections always visible
- **Improved productivity**: Faster data entry and management
- **Better overview**: See relationships between students and grades
- **Efficient layout**: Optimized use of screen real estate

## Validation Features

- **Required Field Validation**: Prevents submission with missing data
- **Email Format Validation**: Ensures valid email format using .NET MailAddress
- **Unique Constraints**: Prevents duplicate student IDs and emails
- **Grade Range Validation**: Ensures grades are between 0-100
- **Database Connection Testing**: Alerts user if database is unavailable
- **Export Validation**: Ensures data exists before export operations

## Error Handling

- All database operations include comprehensive try-catch blocks
- User-friendly error messages with specific details
- Connection failure notifications with guidance
- Data validation feedback with field focus
- Export error handling with rollback capabilities
- Graceful degradation on errors

## Sample Data

The application includes sample data for testing:
- 3 sample students with complete contact information
- 6 sample grades across different subjects (Mathematics, English, Science)
- Demonstrates relationships between students and grades
- Provides data for testing export functionality

## Performance Optimizations

- **Database indexes** on frequently queried columns
- **Connection pooling** handled by MySql.Data connector
- **Read-only DataGridViews** for improved performance
- **Efficient queries** with proper joins and filtering
- **Memory management** with proper disposal of resources
- **SplitContainer layout** for responsive interface

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly with the unified interface and export functions
5. Submit a pull request

## Troubleshooting

### Common Issues
1. **Database Connection Error**: Check MySQL server status and connection string
2. **Build Errors**: Ensure .NET 8 SDK is installed
3. **Missing References**: Restore NuGet packages (EPPlus, iTextSharp)
4. **Form Display Issues**: Check Form1.resx file exists
5. **Export Failures**: Verify write permissions to selected directory

### Interface Issues
1. **Layout problems**: Ensure minimum window size is maintained
2. **SplitContainer not responsive**: Check panel sizing and docking
3. **Controls overlapping**: Verify control positioning and sizing

### Export Issues
1. **Excel files won't open**: Ensure EPPlus package is properly installed
2. **PDF generation fails**: Check iTextSharp dependencies
3. **Large exports**: For large datasets, consider implementing progress indicators

### Performance Tips
- Use search and filtering to work with smaller datasets
- Regular database maintenance for optimal performance
- Resize panels using splitters for optimal viewing
- Consider archiving old grade data periodically

## Security Considerations

- **SQL Injection Prevention**: All queries use parameterized commands
- **Input Validation**: Comprehensive validation on all user inputs
- **Connection String Security**: Store sensitive data in configuration files
- **File Access**: Export operations respect system file permissions

## Future Enhancements

Potential areas for expansion:
- **Responsive layout**: Automatic panel resizing based on content
- **Grade visualization**: Charts and graphs in the interface
- **Advanced filtering**: Cross-panel filtering and selection
- **Customizable layout**: User-configurable panel sizes
- **Keyboard shortcuts**: Faster navigation between panels
- **Multi-monitor support**: Separate windows for dual-screen setups

## License

This project is for educational purposes and demonstrates best practices for Windows Forms applications with unified interfaces, database integration, and comprehensive export capabilities.