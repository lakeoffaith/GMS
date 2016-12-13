using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Framework.Contract
{
    public class DataTablesOrder
    {
        /// <summary>
        ///     排序的列的索引
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        ///     排序模式
        /// </summary>
        public DataTablesOrderDir Dir { get; set; }
    }
}
