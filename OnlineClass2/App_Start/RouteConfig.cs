using System;
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
                name: "Join Course",
                url: "tham-gia",
                defaults: new { controller = "Enrollment", action = "JoinCourse", id = UrlParameter.Optional },
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
                name: "Course Lesson",
                url: "bai-giang/{CourseMetatitle}-{couid}/{LessonMetatitle}-{lessid}",
                defaults: new { controller = "Course", action = "Lesson", id = UrlParameter.Optional },
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
