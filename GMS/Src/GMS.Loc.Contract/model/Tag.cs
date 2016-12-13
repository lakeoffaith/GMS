using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Loc.Contract
{
    [Serializable]
    [Table("device_Tag")]
    public partial class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(17)]
        public string TagMac { get; set; }

        [Required]
        [StringLength(50)]
        public string TagName { get; set; }

        [StringLength(100)]
        public string SerialNo { get; set; }

        public byte ProductType { get; set; }

        public DateTime WriteTime { get; set; }
    }
}
