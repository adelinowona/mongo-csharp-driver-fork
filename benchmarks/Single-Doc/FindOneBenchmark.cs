using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using static benchmarks.BenchmarkExtensions;

namespace benchmarks.Single_Doc
{
    [IterationTime(3000)]
    [BenchmarkCategory("SingleBench", "ReadBench", "DriverBench")]
    public class FindOneBenchmark
    {
        private MongoClient _client;
        private BsonDocument _tweetDocument;
        private IMongoCollection<BsonDocument> _collection;

        [GlobalSetup]
        public void Setup()
        {
            string mongoUri = Environment.GetEnvironmentVariable("MONGODB_URI");
            _client = mongoUri != null ? new MongoClient(mongoUri) : new MongoClient();
            _client.DropDatabase("perftest");
            _tweetDocument = ReadExtendedJson("../../../../../../../data/single_and_multi_document/tweet.json");
            _collection = _client.GetDatabase("perftest").GetCollection<BsonDocument>("corpus");
            PopulateCollection();
        }

        [Benchmark]
        public void FindOne()
        {
            for (int i = 0; i < 10000; i++)
            {
                _collection.Find(new BsonDocument("_id", i)).First();
            }
        }

        [GlobalCleanup]
        public void Teardown()
        {
            _client.DropDatabase("perftest");
        }

        private void PopulateCollection()
        {
            var documents = new List<BsonDocument>();
            for (int i = 0; i < 10000; i++)
            {
                var documentCopy = _tweetDocument.DeepClone().AsBsonDocument;
                documentCopy.Add("_id", i);
                documents.Add(documentCopy);
            }
            _collection.InsertMany(documents);
        }
    }
}
