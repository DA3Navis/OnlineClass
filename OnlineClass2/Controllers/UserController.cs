using Model.Dao;
using Model.EF;
using OnlineClass2.Common;
using OnlineClass2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                else if(dao.CheckEmail(model.Email))
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

                        //gửi mail
                        string username = "pokemonred97@gmail.com";
                        string password = "concho123";
                        string smtpHost = "smtp.gmail.com";
                        int smtpPort = 587;

                        string emailTo = user.Email;
                        string subject = "Active Account";
                        string link = Request.Url.GetLeftPart(UriPartial.Authority) + "/User/ComfirmEmail/" + user.ID;
                        link = "You can go to link active account in BookOnlineShop: " + link;
                        string content = String.Format("Email sent form: {0} <br> Email: {1} <br> Content: {2}", "Tinh Ngo", "gjundat2@gmail.com", link);

                        EmailService emailService = new EmailService();
                        bool ketqua = emailService.sendEmail(username, password, smtpHost, smtpPort, emailTo, subject, content);

                        if (ketqua) ModelState.AddModelError("", "Thank you send email");
                        else ModelState.AddModelError("", "Send email fail");
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
            if(user != null)
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
            if(ModelState.IsValid)
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
    }
}