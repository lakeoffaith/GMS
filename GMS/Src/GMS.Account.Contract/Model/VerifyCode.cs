using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GMS.Account.Contract
{
    [Serializable]
    [Table("VerifyCode")]
    public  class VerifyCode
    {
        public VerifyCode()
        {
            CreateTime = DateTime.Now;
        }
        public int ID { set; get; }

        public Guid Guid { set; get; }

        public string VerifyText { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
