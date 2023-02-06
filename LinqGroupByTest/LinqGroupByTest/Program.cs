namespace LinqGroupByTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new Parser();
            var ret = p.ReadCsv("D:\\repository\\Tests\\LinqGroupByTest\\LinqGroupByTest\\sample.csv");
            p.OutputReport(ret);
            Console.ReadLine();
        }
    }
}