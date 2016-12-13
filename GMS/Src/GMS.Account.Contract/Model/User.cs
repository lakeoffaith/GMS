using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GMS.Framework.Contract;
namespace GMS.Account.Contract
{
    [Auditable]
    [Table("User")]
    public class User
    {
        public User()
        {
            this.Roles = new List<Role>();
            this.IsActive = true;
            this.RoleIds = new List<int>();
        }

        public int ID { set; get; }
        public DateTime CreateTime { set; get; }

        [Required(ErrorMessage="登录名不能为空")]
        public string LoginName { set; get; }

        public string Password { get; set; }

        [RegularExpression(@"^[1-9]{1}\d{10}$",ErrorMessage="不是有效的手机号码")]
        public string Mobile { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage="电子邮件地址无效")]
        public string Email { get; set; }

        public bool IsActive { set; get; }


        public virtual List<Role> Roles { get; set; }

        [NotMapped]
        public List<int> RoleIds { get; set; }

        [NotMapped]
        public string NewPassword { get; set; }

        public List<EnumBusinessPermission> BusinessPermissionList
        {
            get
            {
                var permissions = new List<EnumBusinessPermission>();
                foreach (var role in Roles)
                {
                    permissions.AddRange(role.BusinessPermissionList);
                }
                return permissions.Distinct().ToList();
            }
        }
    }
}
