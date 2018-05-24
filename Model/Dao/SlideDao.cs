using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SlideDao
    {
        OnlineClassContext db = null;

        public SlideDao()
        {
            db = new OnlineClassContext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.OrderByDescending(x => x.CreatedDate).ToList();
        }


        public object ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public long Insert(Slide entity)
        {
            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Delete(long id)
        {
            try
            {
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Slide entity)
        {
            try
            {
                var slide = db.Slides.Find(entity.ID);
                slide.Name = entity.Name;
                slide.Image = entity.Image;
                slide.Link = entity.Link;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Slide GetById(int id)
        {
            return db.Slides.Find(id);
        }
    }
}
