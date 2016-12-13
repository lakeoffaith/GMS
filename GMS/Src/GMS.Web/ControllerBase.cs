using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace GMS.Web
{
    public abstract class ControllerBase : GMS.Framework.Web.ControllerBase
    {
       protected override void OnActionExecuted(ActionExecutedContext filterContext)
       {
           Console.WriteLine("action执行之后");
           base.OnActionExecuted(filterContext);
       }

       protected override void OnActionExecuting(ActionExecutingContext filterContext)
       {
           Console.WriteLine("action执行之前");
           base.OnActionExecuting(filterContext);
       }
    }
}
