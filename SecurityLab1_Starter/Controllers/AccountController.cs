using SecurityLab1_Starter.Infrastructure.Abstract;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityLab1_Starter.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }

        public EmptyResult Logout()
        {
            
            LogUtil lu = new LogUtil();
            StreamWriter w = new StreamWriter("C:\\Temp\\loginLog.txt", true);

            lu.LogAccess("Logout:" + User.Identity.Name + ",", w);
            w.Close();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {

                    LogUtil lu = new LogUtil();
                    StreamWriter w = new StreamWriter("C:\\Temp\\loginLog.txt", true);

                    lu.LogAccess("Login:" + model.UserName + ",", w);
                    w.Close();
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}