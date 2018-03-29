using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineClass2.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

}