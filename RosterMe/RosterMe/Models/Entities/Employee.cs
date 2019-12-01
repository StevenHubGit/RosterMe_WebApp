using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RosterMe.Models.Entities
{
    public class Employee
    {
        //Class variables
        private static String LOG_TAG = "Employees Entity class message";

        //Class attributes

        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String LastName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String Gender { get; set; }

        [Display(Name = "Profile Picture")]
        public String ProfilePicture { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String Position { get; set; }

        [Display(Name = "User Role")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String UserRole { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String Contract { get; set; }

        [Display(Name = "Reporting Manager ID")]
        public int ReportingManagerId { get; set; }

        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Hourly Salary")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal HourlySalary { get; set; }
    }
}
