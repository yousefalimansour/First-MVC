using System.ComponentModel.DataAnnotations.Schema;

namespace First_MVC.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string JobTilte { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}
