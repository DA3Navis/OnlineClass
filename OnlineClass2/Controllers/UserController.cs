using Model.Dao;
using Model.EF;
using OnlineClass2.Common;
using OnlineClass2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineClass2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.Name = model.Name;
                    user.Password = Encrytor.MD5Hash(model.Password);
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.UserName = model.UserName;
                    user.CreatedDate = DateTime.Now;
                    user.Status = false; //Kích hoạt thì lên true qua email
                    user.Quyen = false;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công. Bạn hay truy cập vào email để kích hoạt tài khoản";
                        model = new RegisterModel();

                        string link = Request.Url.GetLeftPart(UriPartial.Authority) + "/User/ComfirmEmail/" + user.ID;
                        link = "Bấm vào link để kích hoạt tài khoản: " + link;
                        string content = String.Format("Email gửi từ: {0} <br> Website: {1} <br> Nội dung: {2}", "Học trực tuyến", "OnlineClass.com", link);

                        //using (var smtp = new SmtpClient("smtp.mailtrap.io", 2525)
                        //{
                        //    Credentials = new NetworkCredential("f7b25ce12924a9", "5e7d85625cd3d0"),
                        //    EnableSsl = true
                        //})
                        //{
                        //    var mail = new MailMessage();
                        //    mail.From = new MailAddress("tuandht97@gmail.com");
                        //    mail.Subject = "Active Account";
                        //    mail.Body = content;

                        //    mail.To.Add(user.Email);
                        //    smtp.Send(mail);                            
                        //}
                        using (var smtp = new SmtpClient("smtp.gmail.com", 587)
                        {
                            Credentials = new NetworkCredential("btlnhom11@gmail.com", "Tuan1234"),
                            EnableSsl = true
                        })
                        {
                            var mail = new MailMessage();
                            mail.From = new MailAddress("btlnhom11@gmail.com");
                            mail.Subject = "Kích hoạt tài khoản";
                            mail.Body = content;
                            mail.IsBodyHtml = true;

                            mail.To.Add(user.Email);
                            smtp.Send(mail);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }

        public ActionResult ComfirmEmail(long? id)
        {
            OnlineClassContext db = new OnlineClassContext();
            var user = db.Users.Find(id);
            if (user != null)
            {
                user.Status = true;
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                // var result = dao.Login(model.UserName, model.Password);
                // mã hóa mật khẩu
                var result = dao.LoginUser(model.UserName, Encrytor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    // Lưu giá trị
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(name: CommonConstants.USER_SESSION, value: userSession);
                    // Về trang chủ
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị khóa, Kiểm tra mail để kích hoạt");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Bạn không có quyền truy cập");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult PasswordRecovery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordRecovery(PasswordRecovery model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại");
                }
                else
                {
                    var email = dao.GetEmail(model.UserName);
                    if (email.Trim() == (model.Email).Trim())
                    {
                        //ModelState.AddModelError("", "Email tồn tại");
                        string link = Request.Url.GetLeftPart(UriPartial.Authority) + "/User/Recovery/" + model.UserName;
                        link = "Bạn đặt lại mật khẩu tại link sau: " + link;
                        string content = String.Format("Email gửi từ: {0} <br> Website: {1} <br> Nội dung: {2}", "Học trực tuyến", "OnlineClass.com", link);

                        using (var smtp = new SmtpClient("smtp.gmail.com", 587)
                        {
                            Credentials = new NetworkCredential("btlnhom11@gmail.com", "Tuan1234"),
                            EnableSsl = true
                        })
                        {
                            var mail = new MailMessage();
                            mail.From = new MailAddress("btlnhom11@gmail.com");
                            mail.Subject = "Đặt lại mật khẩu";
                            mail.Body = content;
                            mail.IsBodyHtml = true;

                            mail.To.Add(model.Email);
                            smtp.Send(mail);
                        }
                    }
                    else
                        ModelState.AddModelError("", "Email không đúng với tài khoản");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Recovery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recovery(PasswordRecovery model)
        {          
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại");
                }
                else
                {
                    var email = dao.GetEmail(model.UserName);
                    if (email.Trim() == (model.Email).Trim())
                    {
                        OnlineClassContext db = new OnlineClassContext();
                        var user = db.Users.SingleOrDefault(x => x.UserName == model.UserName); ;
                        if (user != null)
                        {
                            user.Password = Encrytor.MD5Hash(model.Password);
                            db.SaveChanges();
                            ModelState.AddModelError("", "Đổi mật khẩu thành công");
                            return RedirectToAction("Login", "User");
                        }
                    }
                    else
                        ModelState.AddModelError("", "Email không đúng với tài khoản");
                }
            }
            return View(model);
        }
    }
}