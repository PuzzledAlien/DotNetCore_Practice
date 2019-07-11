using System;
using System.Collections.Generic;
using System.Threading;
using Nest;
using static System.Console;

namespace BulkAll
{
    public class ElasticSearchBulk
    {
        public static bool CreateIndex<T>(IElasticClient elasticClient, string indexName) where T : class
        {
            var existsResponse = elasticClient.Indices.Exists(indexName);
            // 存在则返回true 不存在创建
            if (existsResponse.Exists)
            {
                return true;
            }
            //基本配置
            IIndexState indexState = new IndexState
            {
                Settings = new IndexSettings
                {
                    NumberOfReplicas = 1,//副本数
                    NumberOfShards = 6//分片数
                }
            };

            CreateIndexResponse response = elasticClient.Indices.Create(indexName, p => p
                .InitializeUsing(indexState).Map<T>(r => r.AutoMap())
            );

            return response.IsValid;
        }
        public static ElasticClient GetElasticClient()
        {
            var client = new ElasticClient();
            return client;
        }
        public static bool BulkAll<T>(IElasticClient elasticClient, IndexName indexName, IEnumerable<T> list) where T : class
        {
            const int size = 1000;
            var tokenSource = new CancellationTokenSource();

            var observableBulk = elasticClient.BulkAll(list, f => f
                    .MaxDegreeOfParallelism(8)
                    .BackOffTime(TimeSpan.FromSeconds(10))
                    .BackOffRetries(2)
                    .Size(size)
                    .RefreshOnCompleted()
                    .Index(indexName)
                    .BufferToBulk((r, buffer) => r.IndexMany(buffer))
                , tokenSource.Token);

            var countdownEvent = new CountdownEvent(1);

            Exception exception = null;

            void OnCompleted()
            {
                WriteLine("BulkAll Finished");
                countdownEvent.Signal();
            }

            var bulkAllObserver = new BulkAllObserver(
                onNext: response =>
                {
                    WriteLine($"Indexed {response.Page * size} with {response.Retries} retries");
                },
                onError: ex =>
                {
                    WriteLine("BulkAll Error : {0}", ex);
                    exception = ex;
                    countdownEvent.Signal();
                },
                OnCompleted);

            observableBulk.Subscribe(bulkAllObserver);

            countdownEvent.Wait(tokenSource.Token);

            if (exception != null)
            {
                WriteLine("BulkHotelGeo Error : {0}", exception);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
