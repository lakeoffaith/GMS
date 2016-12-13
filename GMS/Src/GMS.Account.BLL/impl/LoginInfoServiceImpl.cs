using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Framework.BLL;
using GMS.Framework.BLL.Impl;
using GMS.Framework.DAL;
using GMS.Framework.Contract;
using GMS.Account.Contract;

namespace GMS.Account.BLL.Impl
{
    public class LoginInfoServiceImpl: BaseAccountServiceImpl<LoginInfo>,ILoginInfoService
    {
        public LoginInfo LoadByLoginToken(Guid guid)
        {
          return   Load(u => u.LoginToken.Equals(guid)).FirstOrDefault();
        }
    }
}
