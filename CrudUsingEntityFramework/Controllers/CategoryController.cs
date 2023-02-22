using CrudUsingEntityFramework.Data;
using CrudUsingEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingEntityFramework.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext db;
        CategoryDAL categoryDAL;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
            categoryDAL = new CategoryDAL(this.db);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var list = categoryDAL.GetAllCategories();
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var list = categoryDAL.GetCategoryById(id);
            return View(list);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            try
            {
                int result = categoryDAL.AddCategory(cat);
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var list = categoryDAL.GetCategoryById(id);
            return View(list);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            try
            {
                int result = categoryDAL.AddCategory(cat);
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

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var list = categoryDAL.GetCategoryById(id);
            return View(list);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(Category cat)
        {
            try
            {
                int result = categoryDAL.AddCategory(cat);
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
