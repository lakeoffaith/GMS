﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Framework.Contract
{
    public class DataTablesColumns
    {
        /// <summary>
        ///     数据源
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     是否可以被搜索
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        ///     是否可以排序
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        ///     搜索
        /// </summary>
        public DataTablesSearch Search { get; set; }
    }
}
