using System;
using BenchmarkDotNet.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using static benchmarks.BenchmarkExtensions;

namespace benchmarks.Single_Doc;

[BenchmarkCategory("SingleBench", "WriteBench", "DriverBench")]
public class InsertOneSmallBenchmark
{
    private MongoClient _client;
    private IMongoDatabase _database;
    private BsonDocument _smallDocument;
    private IMongoCollection<BsonDocument> _collection;

    [GlobalSetup]
    public void Setup()
    {
        string mongoUri = Environment.GetEnvironmentVariable("BENCHMARKS_MONGO_URI");
        _client = mongoUri != null ? new MongoClient(mongoUri) : new MongoClient();
        _client.DropDatabase("perftest");
        _smallDocument = ReadExtendedJson("../../../../../../../data/single_and_multi_document/small_doc.json");
        _database = _client.GetDatabase("perftest");
    }

    [IterationSetup]
    public void BeforeTask()
    {
        _database.DropCollection("corpus");
        _collection = _database.GetCollection<BsonDocument>("corpus");
    }

    [Benchmark]
    public void InsertOneSmall()
    {
        for (int i = 0; i < 10000; i++)
        {
            _smallDocument.Remove("_id");
            _collection.InsertOne(_smallDocument);
        }
    }

    [GlobalCleanup]
    public void Teardown()
    {
        _client.DropDatabase("perftest");
    }
}
