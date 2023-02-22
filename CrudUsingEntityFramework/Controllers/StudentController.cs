using CrudUsingEntityFramework.Data;
using CrudUsingEntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingEntityFramework.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext db;
        StudentDAL studentDAL;
        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
            studentDAL = new StudentDAL(this.db);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var list= db.Students.ToList(); 
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int rollno)
        {
            var list =studentDAL.GetStudentById(rollno);
            return View(list); 
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stud)
        {
            try
            {
                int result = studentDAL.AddStudent(stud);
                if(result==1)
                    return RedirectToAction(nameof(Index));
               else 
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int rollno)
        {
           var stud=studentDAL.GetStudentById((rollno));

            return View(stud);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stud)
        {
            try
            {
                int result = studentDAL.UpdateStudent(stud);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int rollno)
        {
            var stud = studentDAL.GetStudentById((rollno));

            return View(stud);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int rollno)
        {
            try
            {
                int result = studentDAL.DeleteStudent(rollno);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
