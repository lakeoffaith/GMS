using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Loc.Contract;
using GMS.Loc.DAL;
using GMS.Loc.DAL.Impl;
using GMS.Framework.BLL;
using GMS.Framework.BLL.Impl;
using GMS.Framework.DAL;
using GMS.Framework.Contract;
namespace GMS.Loc.BLL.Impl
{
    public class HostServiceImpl: BaseLocServiceImpl<Host>,IHostService
    {
        public DataTablesResult<Host> JsonForDT(Contract.request.HostRequestForDT request)
        {
            var data = base.Load(u => true);

            if (!string.IsNullOrEmpty(request.HostName))
            {
                data = data.Where(u => u.HostName.Contains(request.HostName));
            }
            if (!string.IsNullOrEmpty(request.HostExternalId))
            {
                data = data.Where(u => u.HostExternalId.Equals(request.HostExternalId));
            }
            if (!string.IsNullOrEmpty(request.tagBindingSelectedValue))
            {
                switch (request.tagBindingSelectedValue)
                {
                        //0为未绑定，1为已绑定，2为不限
                    case "0": data = data.Where(u => u.TagId==0); break;
                    case "1": data = data.Where(u =>u.TagId>0); break;
                    default:  break;
                }
            }
            if (!string.IsNullOrEmpty(request.tagOnlineSelectedValue))
            {
                switch (request.tagOnlineSelectedValue)
                {
                    //0为不在线，1为在线，2为不限
                    //case "0": data = data.Where(u => string.IsNullOrEmpty(u.TagId.ToString())); break;
                    //case "1": data = data.Where(u => !string.IsNullOrEmpty(u.TagId.ToString())); break;
                    default: break;
                }
            }
            return new DataTablesResult<Host>(request.sEcho, data.Count(), data.Count(), data.ToList<Host>());
           
        }
    }
}
