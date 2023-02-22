using CrudUsingEntityFramework.Data;

namespace CrudUsingEntityFramework.Models
{
    public class CategoryDAL
    {
        private readonly ApplicationDbContext db;
        public CategoryDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            var cat = db.Categories.Find(id);
            return cat;

        }
        public int AddCategory(Category cat)
        {
            db.Categories.Add(cat);
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateCategory(Category cat)
        {
            int result = 0;
            var p = db.Categories.Where(x => x.Cid == cat.Cid).FirstOrDefault();
            if (p != null)
            {
                p.Cname = cat.Cname;
               
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteCategoryt(int Cid)
        {
            int result = 0;
            var p = db.Categories.Where(x => x.Cid == Cid).FirstOrDefault();
            if (p != null)
            {
                db.Categories.Remove(p);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
