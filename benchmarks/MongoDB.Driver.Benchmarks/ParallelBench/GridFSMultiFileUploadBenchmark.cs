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
using MongoDB.Bson.TestHelpers;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.TestHelpers;
using System.IO;

using static MongoDB.Benchmarks.BenchmarkHelper;

namespace MongoDB.Benchmarks.ParallelBench
{
    [IterationCount(100)]
    [BenchmarkCategory(DriverBenchmarkCategory.ParallelBench, DriverBenchmarkCategory.WriteBench, DriverBenchmarkCategory.DriverBench)]
    public class GridFSMultiFileUploadBenchmark
    {
        private DisposableMongoClient _client;
        private GridFSBucket _gridFsBucket;

        [GlobalSetup]
        public void Setup()
        {
            _client = MongoConfiguration.CreateDisposableClient();
            _gridFsBucket = new GridFSBucket(_client.GetDatabase("perftest"));
        }

        [IterationSetup]
        public void BeforeTask()
        {
            _gridFsBucket.Drop();
            _gridFsBucket.UploadFromBytes("smallfile", new byte[1]);
        }

        [Benchmark]
        public void GridFsMultiUpload()
        {
            ThreadingUtilities.ExecuteOnNewThreads(50, fileNumber =>
            {
                var filename = $"file{fileNumber:D2}.txt";
                var resourcePath = $"{DataFolderPath}parallel/gridfs_multi/{filename}";

                using var file = File.Open(resourcePath, FileMode.Open);
                _gridFsBucket.UploadFromStream(filename, file);
            });
        }

        [GlobalCleanup]
        public void Teardown()
        {
            _client.Dispose();
        }
    }
}
