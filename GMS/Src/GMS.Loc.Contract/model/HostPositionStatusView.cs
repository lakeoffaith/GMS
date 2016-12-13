using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Loc.Contract
{
    [Serializable]
    [Table("view_HostPositionStatusView")]
    public class HostPositionStatusView
    {
        public int AlertCount { get; set; }

        public int CoordinatesId { get; set; }

        public string CoordinatesName { get; set; }

        public string FacilityName { get; set; }
        public string HostExternalId { get; set; }
        public int HostGroupId { get; set; }
        [Key]
        public int HostId { get; set; }
        public string HostName { get; set; }
        public byte HostStatusType { get; set; }
        public byte HostType { get; set; }
        public string ImagePath { get; set; }
        public double IsDisappeared { get; set; }
        public int MapId { get; set; }
        public int ParentGroupId { get; set; }
        public int TagId { get; set; }
    }
}
