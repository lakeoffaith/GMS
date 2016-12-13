using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Web;
using GMS.Framework.Web;
using GMS.Account.Contract;

namespace GMS.Web.Admin.Common
{
    public class AdminControlerBase : ControllerBase
    {
       
        ///方法执行前，如果没有登录就调整到Passport登录页面，没有权限就抛出信息
        ///
        ///
        public AdminCookieContext CookieContext
        {
            get
            {
                return AdminCookieContext.Current;
            }
        }
        public AdminUserContext UserContext
        {
            get
            {
                return AdminUserContext.Current;
            }
        }

        public virtual LoginInfo LoginInfo
        {
            get
            {
                return UserContext.LoginInfo;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Console.WriteLine("admin _ Action方法执行之后");
            base.OnActionExecuted(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Console.WriteLine("admin _ Action方法执行之前");
            var noAuthorizeAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizeIgnoreAttribute), false);
            if (noAuthorizeAttributes.Length > 0) return;
            base.OnActionExecuting(filterContext);
            if (this.LoginInfo == null)
            {
                filterContext.Result = RedirectToAction("Login", "Auth", new { Area="Account"});
            }
            
        }



    }
}
