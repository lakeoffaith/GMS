using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Web.Admin.Common;
using GMS.Framework.Web;
using GMS.Account.BLL;
using GMS.Account.BLL.Impl;

namespace GMS.Web.Admin.Areas.Account.Controllers
{
    public class AuthController : AdminControlerBase
    {
        private IUserService userService = new UserServiceImpl();
        //
        // GET: /Account/Auth/

        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeIgnore]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AuthorizeIgnore]
        public ActionResult Login(string username, string password, string verifycode)
        {
            if (!VerifyCodeHelper.CheckVerifyCode(verifycode, this.CookieContext.VerifyCodeGuid))
            {
                ModelState.AddModelError("Error", "验证码错误");
                return View();
            }
            var loginInfo = userService.Login(username, password);
            if (loginInfo != null)
            {
                this.CookieContext.UserToken = loginInfo.LoginToken;
                this.CookieContext.UserName = loginInfo.LoginName;
                this.CookieContext.UserId = loginInfo.UserID;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error","用户名或密码错误");
                return View();
            }
            
        }
    }
}
