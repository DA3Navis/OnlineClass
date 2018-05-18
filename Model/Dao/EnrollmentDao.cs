﻿using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class EnrollmentDao
    {
        OnlineClassContext db = null;

        public EnrollmentDao()
        {
            db = new OnlineClassContext();
        }

        public long Insert(Enrollment entity)
        {
            db.Enrollments.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Check(long courseID, long userID)
        {
            return db.Enrollments.Count(x => x.CourseID == courseID && x.UserID == userID) > 0;
        }

        public List<CourseUserEnroll> ListEnroll(long userID)
        {
            var model = from a in db.Courses
                        join b in db.Enrollments
                        on a.ID equals b.CourseID
                        join c in db.Users
                        on b.UserID equals c.ID
                        where c.ID == userID
                        select new CourseUserEnroll()
                        {
                            ID = a.ID,
                            Name = a.Name,
                            MetaTitle = a.MetaTitle,
                            Description = a.Description,
                            Image = a.Image,
                            Price = a.Price,
                            PromotonPrice = a.PromotonPrice,
                            CategoryID = a.CategoryID,
                            CountLesson = a.CountLesson,
                            UserID = userID,
                            Advance = b.Advance
                        };
            return model.ToList();
        }
    }
}
