using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Account.BLL;
using GMS.Account.BLL.Impl;
using GMS.Account.Contract;

namespace GMS.Web
{
    public class VerifyCodeHelper
    {
        public static Guid SaveVerifyCode(string verifyCodeText)
        {
            IVerifyCodeService verifyCodeService = new VerifyCodeServiceImpl();
            var verifyCode = new VerifyCode() { VerifyText = verifyCodeText, Guid = Guid.NewGuid() };

            var list = verifyCodeService.Load(u => true);
            return verifyCodeService.InsertReturnGuid(verifyCode);
        }

        public static bool CheckVerifyCode(string verifycode, Guid guid)
        {
            IVerifyCodeService verifyCodeService = new VerifyCodeServiceImpl();
            var result = verifyCodeService.CheckVerifyCode(verifycode, guid);
            return result;
        }
    }
}
