using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Framework.BLL.Impl;
using GMS.Framework.DAL.Impl;
using GMS.Account.DAL.Impl;


namespace GMS.Account.BLL.Impl
{
    public class BaseAccountServiceImpl<T>: BaseServiceImpl<T> where T:class
    {

        public override BaseRepositoryImpl GetCurrentRepository()
        {
            return new AccountRepositoryImpl();
        }
    }
}
