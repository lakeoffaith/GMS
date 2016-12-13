using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Web.Admin.Common;
using GMS.Framework.Web;
using GMS.Framework.Utility;
using GMS.Web;

namespace GMS.Web.Admin.Areas.Account.Controllers
{
    public class CommonController : AdminControlerBase
    {
        //
        // GET: /Account/Common/
        [AuthorizeIgnore]
        public virtual ActionResult VerifyImage()
        {
            var validateCodeType = new ValidateCode_Style10();
            string code = "6666";
            byte[] bytes = validateCodeType.CreateImage(out code);
            this.CookieContext.VerifyCodeGuid = VerifyCodeHelper.SaveVerifyCode(code);
            return File(bytes, @"image/jpeg");
        }

    }
}
