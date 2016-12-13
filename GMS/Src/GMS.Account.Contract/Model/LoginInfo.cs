using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using GMS.Framework.Utility;

namespace GMS.Account.Contract
{
    [Serializable]
    [Table("LoginInfo")]
    public class LoginInfo
    {

        public LoginInfo()
        {
            CreateTime = DateTime.Now;
        }

        public LoginInfo(int UserID, string ClientIP)
        {
            // TODO: Complete member initialization
            this.UserID = UserID;
            this.ClientIP = ClientIP;
        }

        public virtual int ID { set; get; }
        public virtual DateTime CreateTime { set; get; }

        public Guid LoginToken { get; set; }

        public DateTime LastAccessTime { get; set; }

        public int UserID { set; get; }

        public string LoginName { get; set; }

        public string ClientIP { get; set; }

        public EnumLoginAccountType EnumLoginAccountType { get; set; }

        public string BusinessPermissionString { get; set; }

        [NotMapped]
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
                BusinessPermissionString = string.Join(",", value.Select(p => (int)p));
            }
        }
    }


    [Flags]
    public enum EnumLoginAccountType
    {
        [EnumTitle("[客人]",IsDisplay=false)]
        Guest=0,
        [EnumTitle("管理员")]
        Administrator=1
    }
}
