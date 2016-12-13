using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Framework.Contract
{
    public class DataTablesResult<T>
    {
        public DataTablesResult(int drawParam, int recordsTotalParam, int recordsFilteredParam, List<T> dataParam)
        {
            draw = drawParam;
            recordsTotal = recordsTotalParam;
            recordsFiltered = recordsFilteredParam;
            data = dataParam;
        }
        public DataTablesResult(string errorParam)
        {
            error = errorParam;
        }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data { get; set; }
        public string error { get; set; }
    }
}
