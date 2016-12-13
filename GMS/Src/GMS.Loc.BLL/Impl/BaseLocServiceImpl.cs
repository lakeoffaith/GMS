using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Framework.BLL.Impl;
using GMS.Framework.DAL.Impl;
using GMS.Loc.DAL.Impl;

namespace GMS.Loc.BLL.Impl
{
    public class BaseLocServiceImpl<T>: BaseServiceImpl<T> where T:class
    {

        public override BaseRepositoryImpl GetCurrentRepository()
        {
            return new LocRepositoryImpl();
        }
    }
}
