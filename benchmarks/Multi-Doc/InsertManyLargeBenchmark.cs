using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using static benchmarks.BenchmarkExtensions;

namespace benchmarks.Multi_Doc;


[BenchmarkCategory("MultiBench", "WriteBench", "DriverBench")]
public class InsertManyLargeBenchmark
{
    private MongoClient _client;
    private IMongoDatabase _database;
    private List<BsonDocument> _largeDocuments;
    private IMongoCollection<BsonDocument> _collection;

    [GlobalSetup]
    public void Setup()
    {
        _client = new MongoClient();
        _client.DropDatabase("perftest");
        var largeDocument = ReadExtendedJson("../../../../../../../data/single_and_multi_document/large_doc.json");
        _database = _client.GetDatabase("perftest");

        _largeDocuments = new List<BsonDocument>();
        for (int i = 0; i < 10; i++)
        {
            var documentCopy = largeDocument.DeepClone().AsBsonDocument;
            _largeDocuments.Add(documentCopy);
        }
    }

    [IterationSetup]
    public void BeforeTask()
    {
        _database.DropCollection("corpus");
        _collection = _database.GetCollection<BsonDocument>("corpus");
    }

    [Benchmark]
    public void InsertManyLarge()
    {
        _collection.InsertMany(_largeDocuments, new InsertManyOptions());
    }

    [GlobalCleanup]
    public void Teardown()
    {
        _client.DropDatabase("perftest");
    }
}
