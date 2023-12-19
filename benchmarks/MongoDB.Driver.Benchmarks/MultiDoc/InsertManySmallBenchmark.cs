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
using MongoDB.Driver.TestHelpers;
using static MongoDB.Benchmarks.BenchmarkHelper;

namespace MongoDB.Benchmarks.MultiDoc
{
    [IterationCount(100)]
    [BenchmarkCategory(DriverBenchmarkCategory.MultiBench, DriverBenchmarkCategory.WriteBench, DriverBenchmarkCategory.DriverBench)]
    public class InsertManySmallBenchmark
    {
        private DisposableMongoClient _client;
        private IMongoCollection<BsonDocument> _collection;
        private IMongoDatabase _database;
        private IEnumerable<BsonDocument> _smallDocuments;

        [Params(2750000)]
        public int BenchmarkDataSetSize { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _client = MongoConfiguration.CreateDisposableClient();
            _database = _client.GetDatabase("perftest");

            var smallDocument = ReadExtendedJson("single_and_multi_document/small_doc.json");
            _smallDocuments = Enumerable.Range(0, 10000).Select(_ => smallDocument.DeepClone().AsBsonDocument);
        }

        [IterationSetup]
        public void BeforeTask()
        {
            _database.DropCollection("corpus");
            _collection = _database.GetCollection<BsonDocument>("corpus");
        }

        [Benchmark]
        public void InsertManySmall()
        {
            _collection.InsertMany(_smallDocuments, new InsertManyOptions());
        }

        [GlobalCleanup]
        public void Teardown()
        {
            _client.Dispose();
        }
    }
}
