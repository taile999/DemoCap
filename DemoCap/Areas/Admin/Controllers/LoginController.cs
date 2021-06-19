using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoCap.Areas.Admin.Models;
using DemoCap.Common;
using DemoCap.Models.DAO;

namespace DemoCap.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tai khoan khong ton tai");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tai khoan bi khoa");

                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mat khau ");

                }
                else
                {
                    ModelState.AddModelError("", "dang nhap khong dung ");
                }
                
            }
            return View("Index");
        }

    }
}