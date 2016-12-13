using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GMS.Core.Cache;

namespace GMS.Web.Admin.Common
{
    public class AdminUserContext:UserContext
    {
        public AdminUserContext()
            :base(AdminCookieContext.Current)
        {

        }

        public static AdminUserContext Current
        {
            get
            {
                return CacheHelper.GetItem<AdminUserContext>();
            }
        }
    }
}