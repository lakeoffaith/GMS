using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using GMS.Loc.Contract;
using GMS.Loc.BLL;
using GMS.Loc.BLL.Impl;
using GMS.Loc.Contract.request;
using GMS.Framework.Contract;

namespace GMS.Web.Admin.Areas.Loc.Controllers
{
    public class TagController :Controller
    {
        private ITagService tagService = new TagServiceImpl();
        public ActionResult Index()
        {
            return View();
        }
        

        public string JsonForDT(TagRequestForDT request)
        {
            var data = tagService.Load(u => true);
            DataTablesResult<Tag> dt = new DataTablesResult<Tag>(1,data.Count(),data.Count(),data.ToList<Tag>());
            JavaScriptSerializer zz = new JavaScriptSerializer();
            return zz.Serialize(dt);
        }

    }
}
