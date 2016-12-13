using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Loc.Contract
{
    [Serializable]
    [Table("object_HostTag")]
    public  class Host
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HostId { get; set; }

        public int TagId { get; set; }

        [StringLength(50)]
        public string HostExternalId { get; set; }

        public byte HostType { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage="请输入用户名")]
        [Display(Name="用户名")]
        public string HostName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        public DateTime WriteTime { get; set; }
    }
}
