using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GMS.Core.Cache;

namespace GMS.Web.Admin.Common
{
    public class AdminCookieContext:CookieContext
    {
        public static AdminCookieContext Current
        {
            get
            {
                return CacheHelper.GetItem<AdminCookieContext>();
            }
        }
    }
}