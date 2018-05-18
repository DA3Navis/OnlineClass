
using Model.Dao;
using Model.EF;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Model.ViewModel;

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

        //public ActionResult JoinCourse(long courseID)
        //{
        //    var course = new CourseDao().GetById(courseID);
        //    var enroll = Session[CourseSession];
        //    if (enroll != null)
        //    {
        //        //Nếu đã tham gia thì thôi
        //        var list = (List<Enrollment>)enroll;
        //        if (list.Exists(x => x.Course.ID == courseID))
        //        { // Nếu list đã có khóa học

        //        }
        //        else // ko thì tạo mới
        //        {
        //            var item = new Enrollment();
        //            item.Course = course;
        //            item.UserID = 1;
        //            list.Add(item);
        //        }
        //        //gán vào session
        //        Session[CourseSession] = list;
        //    }
        //    else
        //    {
        //        // Chưa tham gia thì thêm vào
        //        var item = new Enrollment();
        //        item.Course = course;
        //        item.UserID = 1;
        //        var list = new List<Enrollment>();
        //        list.Add(item);

        //        //gán vào session
        //        Session[CourseSession] = list;
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult SendCode(long courseID, long userID)
        {
            var user = new UserDao().ViewDetail(userID);
            var course = new CourseDao().GetByID(courseID);
            var email = new UserDao().GetEmail(user.Name);

            //ModelState.AddModelError("", "Email tồn tại");
            string link = Request.Url.GetLeftPart(UriPartial.Authority) + "/tham-gia/" + courseID + "-" + userID;
            link = "Nhập mã khóa học tại link sau: " + link;
            string code = course.Code;
            string content = String.Format("Email gửi từ: {0} <br> Website: {1} <br> Mã khóa học: {3} <br> Nội dung: {2}", "Học trực tuyến", "OnlineClass.com", link, code);

            using (var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("btlnhom11@gmail.com", "Tuan1234"),
                EnableSsl = true
            })
            {
                var mail = new MailMessage();
                mail.From = new MailAddress("btlnhom11@gmail.com");
                mail.Subject = "Mã khóa học";
                mail.Body = content;
                mail.IsBodyHtml = true;

                mail.To.Add(user.Email);
                smtp.Send(mail);
            }
            return Json(new { success = true });

        }

        [HttpGet]
        public ActionResult CheckCode(long courseID)
        {
            var model = new CourseDao().GetById(courseID);
            return View(model);
        }

        [HttpPost]
        public ActionResult JoinCourse(long courseID, long userID)
        {
            var dao = new EnrollmentDao();
            if (dao.Check(courseID, userID))
            {
            }
            else
            {
                var enroll = new Enrollment();
                enroll.UserID = userID;
                enroll.CourseID = courseID;
                enroll.Advance = 0;

                var result = dao.Insert(enroll);
                var course = new CourseDao().GetByID(courseID);
                var enrollCourse = new CourseUserEnroll();
                enrollCourse.ID = course.ID;
                enrollCourse.Name = course.Name;
                enrollCourse.MetaTitle = course.MetaTitle;
                enrollCourse.Description = course.Description;
                enrollCourse.Image = course.Image;
                enrollCourse.Price = course.Price;
                enrollCourse.PromotonPrice = course.PromotonPrice;
                enrollCourse.CategoryID = course.CategoryID;
                enrollCourse.CountLesson = course.CountLesson;
                enrollCourse.UserID = userID;
                enrollCourse.Advance = 0;

                var session = (UserLogin)Session[OnlineClass2.Common.CommonConstants.USER_SESSION];
                session.ListEnroll.Add(enrollCourse);

            }
            return Json(new { success = true });

        }
    }
}