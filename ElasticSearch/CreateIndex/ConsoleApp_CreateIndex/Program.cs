using System;
using Elasticsearch.Net;
using Nest;

namespace ConsoleApp_CreateIndex
{
    class Program
    {
        private static ElasticClient _elasticClient;
        private static string _indexName;
        static void Main(string[] args)
        {
            _indexName = "TEST";
            _indexName = _indexName.ToLower();//索引名称一定要小写
            _elasticClient = GetElasticClientByPool();
            
            var existsResponse = _elasticClient.Indices.Exists(_indexName);
            if (!existsResponse.Exists)
            {
                //基本配置
                IIndexState indexState = new IndexState
                {
                    Settings = new IndexSettings
                    {
                        NumberOfReplicas = 1,//副本数
                        NumberOfShards = 6//分片数
                    }
                };

                CreateIndexResponse response = _elasticClient.Indices.Create(_indexName, p => p
                    .InitializeUsing(indexState)
                    .Map<People>(r => r.AutoMap())
                );

                if (response.IsValid)
                {
                    Console.WriteLine("索引创建成功");
                }
                else
                {
                    Console.WriteLine("索引创建失败");
                }
            }

            Console.ReadLine();
        }

        public static ElasticClient GetElasticClient()
        {
            var client = new ElasticClient();
            return client;
        }

        public static ElasticClient GetElasticClient(string uri)
        {
            var settings = new ConnectionSettings(new Uri(uri)).
            DefaultIndex(_indexName);
            settings.EnableDebugMode();
            var client = new ElasticClient(settings);
            return client;
        }

        public static ElasticClient GetElasticClient(Uri uri)
        {
            var client = new ElasticClient(uri);
            return client;
        }

        public static ElasticClient GetElasticClientByPool()
        {
            var uris = new[]
            {
                new Uri("http://localhost:9200")
            };

            var connectionPool = new SniffingConnectionPool(uris);

            var settings = new ConnectionSettings(connectionPool)
                .DefaultIndex(_indexName);

            settings.EnableDebugMode();//调试debug使用该模式，正式环境请去掉

            var client = new ElasticClient(settings);

            return client;
        }
    }
}
