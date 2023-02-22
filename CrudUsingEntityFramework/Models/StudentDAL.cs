using CrudUsingEntityFramework.Data;

namespace CrudUsingEntityFramework.Models
{
    public class StudentDAL
    {
        private readonly ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Student> GetAllStudent()
        {

            return db.Students.ToList();
        }
        public Student GetStudentById(int rollno)
        {
            var stud = db.Students.Find(rollno);
            return stud;

        }
        public int AddStudent(Student stud)
        {
            db.Students.Add(stud);
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student stud)
        {
            int result = 0;
            var p = db.Students.Where(x => x.Rollno == stud.Rollno).FirstOrDefault();
            if (p != null)
            {
                p.Name = stud.Name;
                p.Marks = stud.Marks;
                p.City = stud.City;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteStudent(int rollno)
        {
            int result = 0;
            var s = db.Students.Where(x => x.Rollno == rollno).FirstOrDefault();
            if (s != null)
            {
                db.Students.Remove(s);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
