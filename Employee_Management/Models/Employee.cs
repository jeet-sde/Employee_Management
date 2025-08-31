using System.ComponentModel.DataAnnotations;

namespace Employee_Management.Models
{
    public class Employee
    {

        public int id { get; set; }


        [Required(ErrorMessage = "Name is required")]

        public string name { get; set; }


        [Required(ErrorMessage = "Age is required")]
        public int age { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

       
        [Range(0 ,double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal salary { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string Education { get; set; }

    }
}
