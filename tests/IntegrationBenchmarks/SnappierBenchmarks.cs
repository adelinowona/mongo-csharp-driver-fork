using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes;
using MongoDB.Driver.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace IntegrationBenchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class SnappierBenchmarks
    {

        private BsonDocument filter;

        private IEnumerable<BsonDocument> normalDocuments;
        private IEnumerable<BsonDocument> smallDocuments;
        private IEnumerable<BsonDocument> mediumDocuments;
        private IEnumerable<BsonDocument> largeDocuments;


        private IMongoCollection<BsonDocument> normalCollection;
        private IMongoCollection<BsonDocument> smallCollection;
        private IMongoCollection<BsonDocument> mediumCollection;
        private IMongoCollection<BsonDocument> largeCollection;

        [GlobalSetup]
        public void Setup()
        {
            filter = new BsonDocument();
            var localClient = new MongoClient();
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var normalDocument = localClient.GetDatabase("sample_airbnb").GetCollection<BsonDocument>("listingsAndReviews").Find(filter).Project(projection).Single();

            normalDocuments = Enumerable.Range(0, 3).Select(_ => normalDocument);
            smallDocuments = Enumerable.Range(0, 10).Select(_ => new BsonDocument("data", new BsonArray(Enumerable.Range(0, 500).Select(_ => "a"))));
            mediumDocuments = Enumerable.Range(0, 3).Select(_ => new BsonDocument("data", new BsonArray(Enumerable.Range(0, 5000).Select(_ => "b"))));
            largeDocuments = Enumerable.Range(0, 3).Select(_ => new BsonDocument("data", new BsonArray(Enumerable.Range(0, 16000000).Select(_ => "c"))));

            var remoteClient = new MongoClient("mongodb+srv:///?retryWrites=true&w=majority&compressors=snappy");
            normalCollection = remoteClient.GetDatabase("integration_testing").GetCollection<BsonDocument>("normalCollection");
            smallCollection = remoteClient.GetDatabase("integration_testing").GetCollection<BsonDocument>("smallCollection");
            mediumCollection = remoteClient.GetDatabase("integration_testing").GetCollection<BsonDocument>("mediumCollection");
            largeCollection = remoteClient.GetDatabase("integration_testing").GetCollection<BsonDocument>("largeCollection");
        }


        [BenchmarkCategory("Writing"), Benchmark]
        public int writeSmallDocuments()
        {
            smallCollection.InsertMany(smallDocuments);
            return 500;
        }

        [BenchmarkCategory("Writing"), Benchmark]
        public int writeNormalDocuments()
        {
            normalCollection.InsertMany(normalDocuments);
            return 1600;
        }

        [BenchmarkCategory("Writing"), Benchmark]
        public int writeMediumDocuments()
        {
            mediumCollection.InsertMany(mediumDocuments);
            return 5000;
        }

        [BenchmarkCategory("Writing"), Benchmark]
        public int writeLargeDocuments()
        {
            largeCollection.InsertMany(largeDocuments);
            return 160000;
        }

        
        [BenchmarkCategory("Reading"), Benchmark]
        public List<BsonDocument> readSmallDocuments()
        {
            return smallCollection.Find(filter).ToList();
        }

        [BenchmarkCategory("Reading"), Benchmark]
        public List<BsonDocument> readNormalDocuments()
        {
            return normalCollection.Find(filter).ToList();
        }

        [BenchmarkCategory("Reading"), Benchmark]
        public List<BsonDocument> readMediumDocuments()
        {
            return mediumCollection.Find(filter).ToList();
        }

        [BenchmarkCategory("Reading"), Benchmark]
        public List<BsonDocument> readLargeDocuments()
        {
            return largeCollection.Find(filter).ToList();
        }
    }
}