/* Copyright 2010-present MongoDB Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using static MongoDB.Benchmarks.BenchmarkHelper;

namespace MongoDB.Benchmarks.MultiDoc
{
    [IterationCount(100)]
    [BenchmarkCategory(DriverBenchmarkCategory.BulkWriteBench, DriverBenchmarkCategory.MultiBench, DriverBenchmarkCategory.WriteBench, DriverBenchmarkCategory.DriverBench)]
    public class SmallDocBulkInsertBenchmark
    {
        private IMongoClient _client;
        private IMongoCollection<BsonDocument> _collection;
        private IMongoDatabase _database;
        private List<BsonDocument> _smallDocuments;
        private List<InsertOneModel<BsonDocument>> _collectionBulkWriteInsertModels;
        private List<BulkWriteInsertOneModel<BsonDocument>> _clientBulkWriteInsertModels;

        private static readonly CollectionNamespace __collectionNamespace =
            CollectionNamespace.FromFullName($"{MongoConfiguration.PerfTestDatabaseName}.{MongoConfiguration.PerfTestCollectionName}");

        [Params(2_750_000)]
        public int BenchmarkDataSetSize { get; set; } // used in BenchmarkResult.cs

        [GlobalSetup]
        public void Setup()
        {
            _client = MongoConfiguration.CreateClient();
            _database = _client.GetDatabase(MongoConfiguration.PerfTestDatabaseName);

            var smallDocument = ReadExtendedJson("single_and_multi_document/small_doc.json");
            _smallDocuments = Enumerable.Range(0, 10000).Select(_ => smallDocument.DeepClone().AsBsonDocument).ToList();
            _collectionBulkWriteInsertModels = _smallDocuments.Select(x => new InsertOneModel<BsonDocument>(x.DeepClone().AsBsonDocument)).ToList();
            _clientBulkWriteInsertModels = _smallDocuments.Select(x => new BulkWriteInsertOneModel<BsonDocument>(__collectionNamespace, x.DeepClone().AsBsonDocument)).ToList();
        }

        [IterationSetup]
        public void BeforeTask()
        {
            _database.DropCollection(MongoConfiguration.PerfTestCollectionName);
            _collection = _database.GetCollection<BsonDocument>(MongoConfiguration.PerfTestCollectionName);
        }

        [Benchmark]
        public void InsertManySmallBenchmark()
        {
            _collection.InsertMany(_smallDocuments, new InsertManyOptions());
        }
        
        [Benchmark]
        public void SmallDocCollectionBulkWriteInsertBenchmark()
        {
            _collection.BulkWrite(_collectionBulkWriteInsertModels, new BulkWriteOptions());
        }
        
        [Benchmark]
        public void SmallDocClientBulkWriteInsertBenchmark()
        {
            _client.BulkWrite(_clientBulkWriteInsertModels, new ClientBulkWriteOptions());
        }

        [GlobalCleanup]
        public void Teardown()
        {
            _client.Dispose();
        }
    }
}
