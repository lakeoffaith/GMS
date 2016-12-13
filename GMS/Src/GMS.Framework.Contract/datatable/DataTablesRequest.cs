using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Framework.Contract
{
    public abstract class DataTablesRequest
    {
        /// <summary>
        ///     请求次数计数器
        /// </summary>
        public int sEcho { get; set; }

        /// <summary>
        ///     第一条数据的起始位置
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        ///     每页显示的数据条数
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///     数据列
        /// </summary>
        public List<DataTablesColumns> Columns { get; set; }

        /// <summary>
        ///     排序
        /// </summary>
        public List<DataTablesOrder> Order { get; set; }

        /// <summary>
        ///     搜索
        /// </summary>
        public DataTablesSearch Search { get; set; }

        /// <summary>
        ///     排序字段
        /// </summary>
        public string OrderBy
        {
            get
            {
                return Columns != null && Columns.Any() && Order != null && Order.Any()
                    ? Columns[Order[0].Column].Data
                    : string.Empty;
            }
        }

        /// <summary>
        ///     排序模式
        /// </summary>
        public DataTablesOrderDir OrderDir
        {
            get
            {
                return Order != null && Order.Any()
                    ? Order[0].Dir
                    : DataTablesOrderDir.Desc;
            }
        }
    }
}
