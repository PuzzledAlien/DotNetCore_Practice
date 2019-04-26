using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BulkAll
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfCycles = 20000;

            var sw = Stopwatch.StartNew();

            var client = ElasticSearchBulk.GetElasticClient();
            var indexName = nameof(TestNum).ToLower();//索引名称小写
            var createSuccess = ElasticSearchBulk.CreateIndex<TestNum>(client, indexName);
            if (createSuccess)
            {
                var list = new List<TestNum>(numberOfCycles);
                for (var i = 0; i < numberOfCycles; i++)
                {
                    var item = new TestNum { I = i, Msg = $"testNum: {i} " };
                    list.Add(item);
                }

                ElasticSearchBulk.BulkAll(client, indexName, list);
            }
            

            sw.Stop();

            Console.WriteLine();
            Console.WriteLine("Ellapsed: {0}, numPerSec: {1}", sw.ElapsedMilliseconds, numberOfCycles / (sw.ElapsedMilliseconds / (double)1000));
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }

    public class TestNum
    {
        public int I { get; set; }
        public string Msg { get; set; }
    }
}
