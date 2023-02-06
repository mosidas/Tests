using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqGroupByTest
{
    internal class Parser
    {
        public InputCsv ReadCsv(string inputFilePath)
        {
            Dictionary<string, Dictionary<string, List<string[]>>> data = new();
            string[]? header = null;

            using (var parser = new TextFieldParser(inputFilePath, Encoding.UTF8))
            {
                //  区切りの指定
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                // フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = true;
                // フィールドの空白トリム設定
                parser.TrimWhiteSpace = false;

                int rowCount = 0;
                // ファイルの終端までループ

                var group1Keys = new HashSet<string>();
                group1Keys.Add("Job");
                
                var group2Keys = new HashSet<string>();
                group2Keys.Add("Age");

                var group1 = new HashSet<int>();
                var group2 = new HashSet<int>();

                while (!parser.EndOfData)
                {
                    var row = parser.ReadFields();

                    if (rowCount == 0)
                    {
                        header = row;
                        group1 = header.Select((p, i) => new { Content = p, Index = i }).Where(h => group1Keys.Contains(h.Content)).Select(s => s.Index).ToHashSet();
                        group2 = header.Select((p, i) => new { Content = p, Index = i }).Where(h => group2Keys.Contains(h.Content)).Select(s => s.Index).ToHashSet();
                    }
                    else
                    {

                        var val1 = row.Select((p, i) => new { Content = p, Index = i }).Where(h => group1.Contains(h.Index)).Select(s => s.Content);
                        var key1 = string.Join("_", val1);

                        var val2 = row.Select((p, i) => new { Content = p, Index = i }).Where(h => group2.Contains(h.Index)).Select(s => s.Content);
                        var key2 = string.Join("_", val2);

                        if (data.ContainsKey(key1))
                        {
                            if (data[key1].ContainsKey(key2))
                            {
                                data[key1][key2].Add(row); 
                            }
                            else
                            {
                                data[key1][key2] = new List<string[]> { row };
                            } 
                        }
                        else
                        {
                            data[key1] = new Dictionary<string, List<string[]>>();
                            data[key1][key2] = new List<string[]> { row };
                        }
                       
                    }
                    rowCount++;
                }
            }

            var ret = new InputCsv(header, data);
            return ret;
        }

        public void OutputReport(InputCsv input)
        {
            foreach (var val in input.Data.Keys)
            {
                foreach (var d in input.Data[val].Keys)
                {
                    foreach(var row in input.Data[val][d])
                    {
                        Debug.WriteLine($"key1:{val} key2:{d} value:{string.Join(",", row)}");
                    }
                }
            }
        }
    }
}
