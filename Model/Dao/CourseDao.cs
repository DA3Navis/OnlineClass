using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model.Dao
{
    public class CourseDao
    {
        OnlineClassContext db = null;

        public CourseDao()
        {
            db = new OnlineClassContext();
        }

        public IEnumerable<Course> ListAllPaging(string searchString, int page, int pageSize)
        {
            // Sắp sếp theo thứ tự ngày tạo
            IQueryable<Course> model = db.Courses;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public Course GetById(long id)
        {
            return db.Courses.Find(id);
        }

        public bool Update(Course entity)
        {
            try
            {
                var course = db.Courses.Find(entity.ID);
                course.CategoryID = entity.CategoryID;
                course.Name = entity.Name;
                course.Description = entity.Description;
                course.Image = entity.Image;
                course.Price = entity.Price;
                course.PromotonPrice = entity.PromotonPrice;
                course.CountLesson = entity.CountLesson;
                course.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Course GetByID(long id)
        {
            return db.Courses.SingleOrDefault(x => x.ID == id);
        }

        public bool Delete(long id)
        {
            try
            {
                var course = db.Courses.Find(id);
                db.Courses.Remove(course);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            var course = db.Courses.Find(id);
            course.Status = !course.Status;
            db.SaveChanges();
            return course.Status;
        }

        public long Insert(Course entity)
        {
            db.Courses.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public List<Course> ListAll()
        {
            return db.Courses.Where(x => x.Status == true).ToList();
        }
    }
}
