using ZstdSharp;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes;
using MongoDB.Driver.Core.Compression;
using CompressionTesting.DataGenerator;

namespace CompressionTesting.CompressionBenchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class ZstdSharpBenchmarks
	{
        [Params("2.9mb_text_file", "490kB_text_file", "156kB_text_file", "49mb_json_file", "27mb_json_file", "39kB_json_file", "randomData", "repetitiveData")]
        public string which_data;

		private byte[] testdata;
        private byte[] managedCompressedBlock;
        private byte[] managedUncompressedBlock;

        private MemoryStream managedCompressedStream;
        private MemoryStream managedTempStream;

        private MemoryStream unmanagedCompressedStream;
        private MemoryStream unmanagedUncompressedStream;

        private ZstandardCompressor unmanagedCompressor;


        [GlobalSetup]
         /* Runs before any of the functions marked as benchmark are run.
          *  This setup is used to store the compressed versions of the datafile currently used
          *  for benchmarking so they can be used in the decompress benchmarks.
          */
		public void Setup()
		{
            var dataGenerator = new TestDataGenerator(which_data);
            testdata = dataGenerator.GetData();

            using (var zstdsharpCompressor = new Compressor(6))
            {
                managedCompressedBlock = zstdsharpCompressor.Wrap(testdata).ToArray();
            }

            managedUncompressedBlock = new byte[testdata.Length];
            managedTempStream = new MemoryStream();
            managedCompressedStream = new MemoryStream();
            using (var compressionStream = new CompressionStream(managedCompressedStream))
            {
                compressionStream.Write(testdata);
            }

            unmanagedCompressor = new ZstandardCompressor();
            unmanagedCompressedStream = new MemoryStream();
            unmanagedUncompressedStream = new MemoryStream();

            unmanagedUncompressedStream.Write(testdata);
            unmanagedUncompressedStream.Seek(0, SeekOrigin.Begin);
            unmanagedCompressor.Compress(unmanagedUncompressedStream, unmanagedCompressedStream);
        }


        [BenchmarkCategory("Compress"), Benchmark(Baseline = true)]
        public long UnmanagedCompress()
        {
            using (MemoryStream output = new MemoryStream())
            {
                unmanagedUncompressedStream.Position = 0;
                unmanagedCompressor.Compress(unmanagedUncompressedStream, output);
                return output.Length; 
            }
        }


        [BenchmarkCategory("Decompress"), Benchmark(Baseline = true)]
        public long UnmanagedDecompress()
        {
            using (MemoryStream output = new MemoryStream())
            {
                unmanagedCompressedStream.Position = 0;
                unmanagedCompressor.Decompress(unmanagedCompressedStream, output);
                return output.Length;
            }
        }


        [BenchmarkCategory("Compress"), Benchmark]
        public Span<byte> ZstdCompressBlock()
        {
            using var compressor = new Compressor(6);
            return compressor.Wrap(testdata);
        }


        [BenchmarkCategory("Decompress"), Benchmark]
        public Span<byte> ZstdDecompressBlock()
        {
            using var decompressor = new Decompressor();
            return decompressor.Unwrap(managedCompressedBlock);
        }


        [BenchmarkCategory("Compress"), Benchmark]
        public int ZstdCompressStream()
        {
            managedTempStream.Position = 0;
            managedTempStream.SetLength(0);
            using (var compressionStream = new CompressionStream(managedTempStream, 6))
            {
                compressionStream.Write(testdata, 0, testdata.Length);
                return testdata.Length;
            }
        }


        [BenchmarkCategory("Decompress"), Benchmark]
        public int ZstdDecompressStream()
        {
            managedCompressedStream.Seek(0, SeekOrigin.Begin);
            using (var decompressionStream = new DecompressionStream(managedCompressedStream))
            {
                decompressionStream.Read(managedUncompressedBlock, 0, testdata.Length);
                return managedUncompressedBlock.Length;
            }
        }


        [GlobalCleanup]
        public void Cleanup()
        {
            managedCompressedStream.Dispose();
            unmanagedCompressedStream.Dispose();
            unmanagedUncompressedStream.Dispose();
            managedTempStream.Dispose();
        }
    }
}