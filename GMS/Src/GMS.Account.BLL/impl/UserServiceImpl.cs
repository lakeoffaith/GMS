using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Framework.BLL;
using GMS.Framework.BLL.Impl;
using GMS.Framework.DAL;
using GMS.Framework.Contract;
using GMS.Account.Contract;
using GMS.Framework.Utility;
using GMS.Framework.DAL.Impl;
using GMS.Account.DAL.Impl;
namespace GMS.Account.BLL.Impl
{
    public class UserServiceImpl: BaseAccountServiceImpl<User>,IUserService
    {
        private ILoginInfoService loginInfoService = new LoginInfoServiceImpl();
        public LoginInfo Login(string loginName, string password)
        {
            LoginInfo loginInfo = null;
            password = Encrypt.MD5(password);
            loginName = loginName.Trim();
            var user=LoadWithInclude("Roles", u => u.LoginName == loginName && u.Password == password && u.IsActive).FirstOrDefault();
            if (user != null)
            {
                var ip = Fetch.UserIp;
                loginInfo = loginInfoService.Load(p => p.LoginName == loginName && p.ClientIP == ip).FirstOrDefault();
                if (loginInfo != null)
                {
                    loginInfo.LastAccessTime = DateTime.Now;
                }
                else
                {
                    loginInfo = new LoginInfo(user.ID,user.LoginName);
                    loginInfo.ClientIP = ip;
                    loginInfo.BusinessPermissionList = user.BusinessPermissionList;
                   loginInfoService.Insert(loginInfo);
                    
                }
            }
            return loginInfo;
        }
    }
}
