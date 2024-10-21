namespace First_MVC.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Yousef", ImageURl = "R.jpg" });
            students.Add(new Student() { Id = 2, Name = "ahmed", ImageURl = "R.jpg" });
            students.Add(new Student() { Id = 3, Name = "yaser", ImageURl = "R.jpg" });
            students.Add(new Student() { Id = 4, Name = "menna", ImageURl = "R.jpg" });
            students.Add(new Student() { Id = 5, Name = "sara", ImageURl = "R.jpg" });
            students.Add(new Student() { Id = 6, Name = "arwa", ImageURl = "R.jpg" });
        }
        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetByID(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }
    }
}
