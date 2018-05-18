using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace OnlineClass2.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cate(long cateid)
        {
            ViewBag.Cou = new CourseDao().ListCour(cateid);
            return View();
        }

        public ActionResult Detail(long couid)
        {
            ViewBag.Lesson = new LessonDao().ListLess(couid);
            var dao = new CourseDao();
            var course = dao.GetByID(couid);
            return View(course);
        }

        public ActionResult Demo(long lessid, long couid)
        {
            ViewBag.Cou = new CourseDao().GetByID(couid);
            ViewBag.Lesson = new LessonDao().ListLess(couid);
            var dao = new LessonDao();
            var lesson = dao.GetByID(lessid);
            return View(lesson);
        }
        
        public ActionResult Learn(long courseID, long userID)
        {
            ViewBag.Lesson = new LessonDao().ListLess(courseID);
            var dao = new CourseDao();
            var course = dao.GetByID(courseID);
            return View(course);
        }

        public ActionResult Lesson(long courseID, long userID, long lessonID)
        {
            ViewBag.Cou = new CourseDao().GetByID(courseID);
            ViewBag.Lesson = new LessonDao().ListLess(courseID);
            var dao = new LessonDao();
            var lesson = dao.GetByID(lessonID);
            return View(lesson);
        }
    }
}