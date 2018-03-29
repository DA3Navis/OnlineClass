using Model.EF;
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

        public List<CourseCategory> ListAll()
        {
            return db.CourseCategories.Where(x => x.Status == true).ToList();
        }
    }
}
