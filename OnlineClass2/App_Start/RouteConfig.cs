﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineClass2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Intro",
                url: "gioi-thieu",
                defaults: new { controller = "Home", action = "Intro", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Course Enrollment",
                url: "danh-sach-khoa-hoc-tham-gia",
                defaults: new { controller = "User", action = "EnrollCourse", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
               name: "Profile",
               url: "thong-tin/{userID}",
               defaults: new { controller = "User", action = "Profile", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineClass2.Controllers" }
           );

            routes.MapRoute(
                name: "Category",
                url: "{metatitle}-{cateid}",
                defaults: new { controller = "Course", action = "Cate", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Course Detail",
                url: "khoa-hoc/{metatitle}-{couid}",
                defaults: new { controller = "Course", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Course Learn",
                url: "hoc/{metatitle}-{courseID}-{userID}",
                defaults: new { controller = "Course", action = "Learn", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Course Demo",
                url: "hoc-thu/{CourseMetatitle}-{couid}/{LessonMetatitle}-{lessid}",
                defaults: new { controller = "Course", action = "Demo", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Course lesson",
                url: "bai-giang/{CourseMetatitle}-{courseID}-{userID}/{LessonMetatitle}-{lessonID}",
                defaults: new { controller = "Course", action = "Lesson", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Check Code",
                url: "tham-gia/{courseID}-{userID}",
                defaults: new { controller = "Enrollment", action = "CheckCode", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineClass2.Controllers" }
            );
        }
    }
}
