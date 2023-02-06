using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqGroupByTest
{
    internal class Parser
    {
        public InputCsv ReadCsv(string inputFilePath)
        {
            List<string[]> rows = new();
            string[] header = null;

            using (var parser = new TextFieldParser(inputFilePath, Encoding.GetEncoding("Shift_JIS")))
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

                while (!parser.EndOfData)
                {
                    var row = parser.ReadFields();

                    if (rowCount == 0)
                    {
                        header = row;
                    }
                    else
                    {
                        rows.Add(row);
                    }
                    rowCount++;
                }
            }

            var ret = new InputCsv(header, rows);
            return ret;
        }

        public void OutputReport(string path)
        {
            var input = ReadCsv(path);

            var group1Keys = new Dictionary<string, string>();
            var group2Keys = new Dictionary<string, string>();

            var group1 = input.Header
                .Select((p, i) => new { Content = p, Index = i })
                .Where(h => group1Keys.ContainsKey(h.Content));

            var group2 = input.Header
                .Select((p, i) => new { Content = p, Index = i })
                .Where(h => group2Keys.ContainsKey(h.Content));

            var inputGroup = input.Data.GroupBy(i => new { Data = i.Select((content, index) => new { Content = content, Index = index }).Where(x => sheetGroup.Any(y => y.Index == x.Index)) });
        }
    }
}
