using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Objects;
using GMS.Framework.Contract;
using EntityFramework.Extensions;
using Webdiyer.WebControls.Mvc;
using System.Collections;
using GMS.Framework.BLL;
using GMS.Account.Contract;
namespace GMS.Account.BLL
{
    public interface IVerifyCodeService:IBaseService<VerifyCode>
    {

        Guid InsertReturnGuid(VerifyCode verifyCode);

        Boolean CheckVerifyCode(string verifycode, Guid guid);
    }
}
