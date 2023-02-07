// See https://aka.ms/new-console-template for more information
using JsonTest;
var input = 
 @"
{
'name': [
    'aaa',
    'bbb',
    'ccc'
        ],
'setA': {
    'subA-1': 'valA1',
    'subA-2': 'valA2'
    },
'setB': {
    'subB-1': 'valB1',
    'subB-2': 'valB2'
    }
}
";

var output = Parser.Parse(input);

Console.WriteLine(output["name"]);
Console.WriteLine(output["setA"]);

Console.ReadLine();