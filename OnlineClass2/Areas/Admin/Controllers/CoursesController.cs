using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace OnlineClass2.Areas.Admin.Controllers
{
    public class CoursesController : BaseController
    {

       // GET: Admin/Courses
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CourseDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }

        //public ActionResult Index()
        //{
        //    OnlineClassContext db = new OnlineClassContext();
        //    var courses = db.Courses.Include(c => c.CourseCategory);
        //    return View(courses.ToList());
        //}

        // GET: Admin/Courses/Create      
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                var dao = new CourseDao();

                long id = dao.Insert(course);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Courses");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new CourseDao();
            var course = dao.GetByID(id);

            SetViewBag(course.CategoryID);

            return View(course);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Course model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CourseDao();

                var result = dao.Update(model);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Courses");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBag(model.CategoryID);
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new CourseDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CourseDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        public void SetViewBag(long? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }


    }
}
