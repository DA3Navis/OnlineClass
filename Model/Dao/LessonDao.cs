using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class LessonDao
    {

        OnlineClassContext db = null;

        public LessonDao()
        {
            db = new OnlineClassContext();
        }

        public IEnumerable<Lesson> ListAllPaging(string searchString, int page, int pageSize)
        {
            // Sắp sếp theo thứ tự ngày tạo
            IQueryable<Lesson> model = db.Lessons;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public bool Delete(long id)
        {
            try
            {
                var lesson = db.Lessons.Find(id);
                db.Lessons.Remove(lesson);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Lesson GetByID(long id)
        {
            return db.Lessons.SingleOrDefault(x => x.ID == id);
        }

        public long Insert(Lesson entity)
        {
            db.Lessons.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Lesson entity)
        {
            try
            {
                var less = db.Lessons.Find(entity.ID);
                less.Title = entity.Title;
                less.Description = entity.Description;
                less.Image = entity.Image;
                less.LinkURL = entity.LinkURL;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
