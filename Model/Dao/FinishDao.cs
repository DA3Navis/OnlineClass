using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FinishDao
    {
        OnlineClassContext db = null;

        public FinishDao()
        {
            db = new OnlineClassContext();
        }

        public List<Finish> ListDone(long userID, long courseID)
        {
            return db.Finishes.Where(x => x.UserID == userID && x.CourseID== courseID).ToList();
        }

        public void Insert(Finish entity)
        {
            db.Finishes.Add(entity);
            db.SaveChanges();
        }

        public bool Check(long lessonID, long userID)
        {
            return db.Finishes.Count(x => x.LessonID == lessonID && x.UserID == userID) > 0;
        }
    }
}
