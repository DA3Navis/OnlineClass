
using Model.Dao;
using OnlineClass2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineClass2.Controllers
{
    public class EnrollmentController : Controller
    {
        private const string CourseSession = "CourseSession";
        // GET: Enrollment
        public ActionResult Index()
        {
            var course = Session[CourseSession];
            var list = new List<Enrollment>();
            if (course != null)
            {
                list = (List<Enrollment>)course;
            }
            return View(list);
        }

        public ActionResult JoinCourse(long courseID)
        {
            var course = new CourseDao().GetById(courseID);
            var enroll = Session[CourseSession];
            if (enroll != null)
            {
                //Nếu đã tham gia thì thôi
                var list = (List<Enrollment>)enroll;
                if (list.Exists(x => x.Course.ID == courseID))
                { // Nếu list đã có khóa học

                }
                else // ko thì tạo mới
                {
                    var item = new Enrollment();
                    item.Course = course;
                    item.UserID = 1;
                    list.Add(item);
                }
                //gán vào session
                Session[CourseSession] = list;
            }
            else
            {
                // Chưa tham gia thì thêm vào
                var item = new Enrollment();
                item.Course = course;
                item.UserID = 1;
                var list = new List<Enrollment>();
                list.Add(item);

                //gán vào session
                Session[CourseSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}