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

using BenchmarkDotNet.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.TestHelpers;

using static MongoDB.Benchmarks.BenchmarkHelper;

namespace MongoDB.Benchmarks.SingleDoc
{
    [IterationCount(100)]
    [BenchmarkCategory(DriverBenchmarkCategory.SingleBench, DriverBenchmarkCategory.WriteBench, DriverBenchmarkCategory.DriverBench)]
    public class InsertOneLargeBenchmark
    {
        private DisposableMongoClient _client;
        private IMongoDatabase _database;
        private BsonDocument _largeDocument;
        private IMongoCollection<BsonDocument> _collection;

        [GlobalSetup]
        public void Setup()
        {
            _client = MongoConfiguration.CreateDisposableClient();
            _database = _client.GetDatabase("perftest");
            _largeDocument = ReadExtendedJson("single_and_multi_document/large_doc.json");
        }

        [IterationSetup]
        public void BeforeTask()
        {
            _database.DropCollection("corpus");
            _collection = _database.GetCollection<BsonDocument>("corpus");
        }

        [Benchmark]
        public void InsertOneLarge()
        {
            for (int i = 0; i < 10; i++)
            {
                _largeDocument.Remove("_id");
                _collection.InsertOne(_largeDocument);
            }
        }

        [GlobalCleanup]
        public void Teardown()
        {
            _client.Dispose();
        }
    }
}
