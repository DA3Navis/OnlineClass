using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineClass2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideDao().ListAll();
            ViewBag.NewCourse = new CourseDao().ListNew(8);
            ViewBag.ProCourse = new CourseDao().ListPro(8);
            return View();
        }
        
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            //var model = new MenuDao().ListByGroupId(1);
            ViewBag.Cate = new CategoryDao().ListAll();
            return PartialView();
        }
    }
}