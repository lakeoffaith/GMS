using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GMS.Framework.Contract;
namespace GMS.Account.Contract
{
    [Auditable]
    [Table("Role")]
    public class Role
    {
        public int ID { set; get; }
        public DateTime CreateTime { set; get; }

        public string Name { set; get; }

        public string Info { set; get; }

        public virtual List<User> Users { set; get; }

        public string BusinessPermissionString { set; get; }

        public List<EnumBusinessPermission> BusinessPermissionList
        {
            get
            {
                if (string.IsNullOrEmpty(BusinessPermissionString))
                    return new List<EnumBusinessPermission>();
                else
                    return BusinessPermissionString.Split(",".ToCharArray()).Select(p => int.Parse(p)).Cast<EnumBusinessPermission>().ToList();
            }
            set
            {
                BusinessPermissionString = string.Join(",",value.Select(p=>(int)p));
            }
        }
    }
}
