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
using OnlineClass2.Common;

namespace OnlineClass2.Areas.Admin.Controllers
{
    public class LessonsController : BaseController
    {
        private OnlineClassContext db = new OnlineClassContext();

        // GET: Admin/Lessons
        //public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        //{
        //    var dao = new LessonDao();
        //    var model = dao.ListAllPaging(searchString, page, pageSize);
        //    ViewBag.SearchString = searchString;
        //    SetViewBagCate();
        //    SetViewBagCou();
        //    return View(model);
        //}

        public ActionResult Index()
        {
            var dao = new CategoryDao();
            ViewBag.Cate = dao.ListAll();
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            var dao = new CategoryDao();
            ViewBag.Cate = dao.ListAll();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Lesson less)
        {
            if (ModelState.IsValid)
            {
                var dao = new LessonDao();

                var meta = Meta.ToMeta(less.Title);
                less.MetaTitle = meta;

                long id = dao.Insert(less);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Lessons");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }

            }
            return View();
        }


        //[HttpDelete]
        //public ActionResult Delete(long id)
        //{
        //    new LessonDao().Delete(id);
        //    return RedirectToAction("Index");
        //}


        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson less = db.Lessons.Find(id);
            if (less == null)
            {
                return HttpNotFound();
            }
            return View(less);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson less = db.Lessons.Find(id);
            db.Lessons.Remove(less);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new LessonDao();
            var less = dao.GetByID(id);
            return View(less);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Lesson model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LessonDao();

                var meta = Meta.ToMeta(model.Title);
                model.MetaTitle = meta;

                var result = dao.Update(model);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Lessons");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }


        public ActionResult loadCourse(long cateID)
        {
            return Json(db.Courses.Where(x => x.CategoryID == cateID).Select(s => new
            {
                ID = s.ID,
                Name = s.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult loadLesson(long couID)
        {
            return Json(db.Lessons.Where(x => x.CourseID == couID).Select(s => new
            {
                ID = s.ID,
                Title = s.Title,
                Des = s.Description,
                Img = s.Image,
                Link = s.LinkURL
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}
