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
    public class HostController :Controller
    {
        private IHostService hostService = new HostServiceImpl();
        public ActionResult Index()
        {
          
            return View();
        }


        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Save(Host host)
        {
            if (ModelState.IsValid)
            {
                host.WriteTime = DateTime.Now;
                hostService.Insert(host);
                return RedirectToAction("Index");
            }
            return View("Edit");
            
        }
        public string JsonForDT(HostRequestForDT request)
        {
            JavaScriptSerializer zz = new JavaScriptSerializer();
            return zz.Serialize( hostService.JsonForDT(request));
        }

    }
}
