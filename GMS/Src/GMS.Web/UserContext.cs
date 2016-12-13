using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Core.Cache;
using GMS.Account.Contract;
using GMS.Account.BLL.Impl;
using GMS.Account.BLL;

namespace GMS.Web
{
    public class UserContext
    {
        private ILoginInfoService loginInfoService = new LoginInfoServiceImpl();
        protected IAuthCookie authCookie;
        public UserContext(IAuthCookie authCookie)
        {
            this.authCookie = authCookie;
        }

        public LoginInfo LoginInfo
        {
            get
            {
                return CacheHelper.GetItem<LoginInfo>("LoginInfo", () =>
                {
                    if (authCookie.UserToken == Guid.Empty)
                        return null;
                    var loginInfo = loginInfoService.LoadByLoginToken(authCookie.UserToken);
                    if (loginInfo != null && loginInfo.UserID > 0 && loginInfo.UserID != this.authCookie.UserId)
                        throw new Exception("非法操作，视图通过网站修改Cookie取得用户信息！");

                    return loginInfo;
                    return null;
                });
            }
        }
    }
}
