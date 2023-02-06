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
        public Dictionary<string, Dictionary<string, List<string[]>>> Data { get; set; }

        public InputCsv(IEnumerable<string> header, Dictionary<string, Dictionary<string, List<string[]>>> data) 
        {
            Header = header;
            Data = data;
        }
    }
}
