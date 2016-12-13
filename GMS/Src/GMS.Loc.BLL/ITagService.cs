using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Loc.Contract;
using GMS.Loc.DAL;
using System.Data.Entity;
using System.Data.Objects;
using GMS.Framework.Contract;
using EntityFramework.Extensions;
using Webdiyer.WebControls.Mvc;
using System.Collections;
using GMS.Framework.BLL;
namespace GMS.Loc.BLL
{
    public interface ITagService:IBaseService<Tag>
    {
    }
}
