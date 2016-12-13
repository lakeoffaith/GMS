using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Framework.Contract;
namespace GMS.Loc.Contract.request
{
    public  class HostRequestForDT:DataTablesRequest
    {
        public string HostName { set; get; }

        public string HostExternalId { set; get; }

        public string tagBindingSelectedValue { get; set;}

        public string tagOnlineSelectedValue { get; set; }

    }
}
