using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqGroupByTest
{
    internal class InputCsv
    {
        public IEnumerable<string> Header { get; set; }
        public IEnumerable<IEnumerable<string>> Data { get; set; }

        public InputCsv(string[] header, List<string[]> data) 
        {
            Header = header;
            Data = data;
        }
    }
}
