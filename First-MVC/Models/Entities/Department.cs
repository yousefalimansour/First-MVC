namespace First_MVC.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public List<Employee>? EmpList { get; set; }
    }
}
