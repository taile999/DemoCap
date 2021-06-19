using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoCap.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Vui long nhap tai khoan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui long nhap mat khau")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}