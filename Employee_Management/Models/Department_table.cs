using System.ComponentModel.DataAnnotations;

namespace Employee_Management.Models
{
    public class Department_table
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department {  get; set; }

        public string Description { get; set; }

    }
}
