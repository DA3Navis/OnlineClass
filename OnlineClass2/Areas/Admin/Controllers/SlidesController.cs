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
    public class SlidesController : BaseController
    {
        private OnlineClassContext db = new OnlineClassContext();

        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SlideDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Slide slide)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();

                long id = dao.Insert(slide);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Slides");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new SlideDao();
            var less = dao.GetById(id);
            return View(less);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Slide model)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();

                var result = dao.Update(model);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Slides");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SlideDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}

