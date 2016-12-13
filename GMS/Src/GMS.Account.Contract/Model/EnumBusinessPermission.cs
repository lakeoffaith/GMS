using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Framework.Utility;

namespace GMS.Account.Contract
{
    public enum  EnumBusinessPermission
    {
        [EnumTitle("[无]",IsDisplay=false)]
        None=0,

        [EnumTitle("管理用户")]
        AccountManage_User=101,

        [EnumTitle("管理角色")]
        AccountManage_Role=102,
        [EnumTitle("定位系统")]
        LocManage_User = 201,
    }
}
