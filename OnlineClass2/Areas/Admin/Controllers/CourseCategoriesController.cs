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
    public class CourseCategoriesController : BaseController
    {

        // GET: Admin/CourseCategories
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/CourseCategories/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseCategory cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();

                var meta = Meta.ToMeta(cate.Name);
                cate.MetaTitle = meta;

                long id = dao.Insert(cate);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "CourseCategories");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            var cate = new CategoryDao().ViewDetail(id);
            return View(cate);
        }

        [HttpPost]
        public ActionResult Edit(CourseCategory cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();

                var meta = Meta.ToMeta(cate.Name);
                cate.MetaTitle = meta;

                var result = dao.Update(cate);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "CourseCategories");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CategoryDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
