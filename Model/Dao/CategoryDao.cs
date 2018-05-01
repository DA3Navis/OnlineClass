using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineClassContext db = null;

        public CategoryDao()
        {
            db = new OnlineClassContext();
        }

        public IEnumerable<CourseCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            // Sắp sếp theo thứ tự ngày tạo
            IQueryable<CourseCategory> model = db.CourseCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool ChangeStatus(long id)
        {
            var cate = db.CourseCategories.Find(id);
            cate.Status = !cate.Status;
            db.SaveChanges();
            return cate.Status;
        }

        public bool Delete(long id)
        {
            try
            {
                var cate = db.CourseCategories.Find(id);
                db.CourseCategories.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CourseCategory ViewDetail(long id)
        {
            return db.CourseCategories.Find(id);
        }

        public long Insert(CourseCategory entity)
        {
            db.CourseCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(CourseCategory entity)
        {
            try
            {
                var cate = db.CourseCategories.Find(entity.ID);
                cate.Name = entity.Name;
                cate.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CourseCategory> ListAll()
        {
            return db.CourseCategories.Where(x => x.Status == true).ToList();
        }

    }
}
