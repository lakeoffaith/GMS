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
    public class VerifyCodeServiceImpl: BaseAccountServiceImpl<VerifyCode>,IVerifyCodeService
    {

        public Guid InsertReturnGuid(VerifyCode verifyCode)
        {
            base.Insert(verifyCode) ;
            return verifyCode.Guid;
        }


        public bool CheckVerifyCode(string verifycode, Guid guid)
        {
            var list = base.Load(u => (u.VerifyText.Equals(verifycode) && u.Guid.Equals(guid)));
            return list.Count() > 0 ? true : false;
        }
    }
}
