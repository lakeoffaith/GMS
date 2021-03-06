﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Framework.Contract
{
    public class DataTablesSearch
    {
        /// <summary>
        ///     全局的搜索条件的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     是否为正则表达式处理
        /// </summary>
        public bool Regex { get; set; }
    }
}
