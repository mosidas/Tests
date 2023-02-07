using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace JsonTest
{
    internal class Parser
    {
        public static JObject Parse(string str)
        {
            
            return JObject.Parse(str);
        }
    }
}
