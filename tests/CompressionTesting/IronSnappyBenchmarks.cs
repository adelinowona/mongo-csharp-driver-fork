using IronSnappy;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes;
using MongoDB.Driver.Core.Compression.Snappy;
using CompressionTesting.DataGenerator;


namespace CompressionTesting.CompressionBenchmarks
{
	[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    public class IronSnappyBenchmarks
	{
        
		[Params("2.9mb_text_file", "490kB_text_file", "156kB_text_file", "49mb_json_file", "27mb_json_file", "39kB_json_file", "randomData", "repetitiveData")]
		public string which_data;

		private byte[] testdata;

        private byte[] unmanagedCompressBuffer;
        private byte[] unmanagedDecompressBuffer;
        private byte[] unmanagedCompressedBlock;

		private byte[] managedCompressedBlock;
        private byte[] managedUncompressedBuffer;
		private MemoryStream managedCompressedStream;
        private MemoryStream managedTempStream;


        [GlobalSetup]
        /* Runs before any of the functions marked as benchmark are run.
         *  This setup is used to store the compressed versions of the datafile currently used
         *  for benchmarking so they can be used in the decompress benchmarks.
         */
		public void Setup()
		{
			var dataGenerator = new TestDataGenerator(which_data);
			testdata = dataGenerator.GetData();
			
			managedCompressedBlock = Snappy.Encode(testdata);
            managedUncompressedBuffer = new byte[testdata.Length];

            managedTempStream = new MemoryStream();
			managedCompressedStream = new MemoryStream();
			using (Stream snappyStream = Snappy.OpenWriter(managedCompressedStream))
			{
				snappyStream.Write(testdata);
			}

            UnmanagedCodeSetup();
        }


        // Setup for unmanaged code benchmarks
        private void UnmanagedCodeSetup()
        {
            var maxCompressedSize = SnappyCodec.GetMaxCompressedLength(testdata.Length);
            var tempBuffer = new byte[maxCompressedSize];
            unmanagedCompressBuffer = new byte[maxCompressedSize];
            var compressedSize = SnappyCodec.Compress(
                input: testdata,
                inputOffset: 0,
                inputLength: testdata.Length,
                output: tempBuffer,
                outputOffset: 0,
                outputLength: tempBuffer.Length);

            unmanagedCompressedBlock = new byte[compressedSize];
            Array.Copy(tempBuffer, unmanagedCompressedBlock, compressedSize);

            var uncompressedSize = SnappyCodec.GetUncompressedLength(unmanagedCompressedBlock);
            unmanagedDecompressBuffer = new byte[uncompressedSize];
        }


        [BenchmarkCategory("Compress"), Benchmark(Baseline = true)]
        public int UnmanagedCompress()
        {
           SnappyCodec.Compress(
                input: testdata,
                inputOffset: 0,
                inputLength: testdata.Length,
                output: unmanagedCompressBuffer,
                outputOffset: 0,
                outputLength: unmanagedCompressBuffer.Length);
            return  unmanagedCompressBuffer.Length;
        }


        [BenchmarkCategory("Decompress"), Benchmark(Baseline = true)]
        public int UnmanagedDecompress()
        {
           SnappyCodec.Uncompress(
                input: unmanagedCompressedBlock,
                inputOffset: 0,
                inputLength: unmanagedCompressedBlock.Length,
                output: unmanagedDecompressBuffer,
                outputOffset: 0,
                outputLength: unmanagedDecompressBuffer.Length);
            return  unmanagedDecompressBuffer.Length; 
        }


		[BenchmarkCategory("Compress"), Benchmark]
		public byte[] IronSnappyCompressBlock() => Snappy.Encode(testdata);


		[BenchmarkCategory("Decompress"), Benchmark]
		public byte[] IronSnappyDecompressBlock() => Snappy.Decode(managedCompressedBlock);


		[BenchmarkCategory("Compress"), Benchmark]
		public long IronSnappyCompressStream()
		{
            managedTempStream.Position = 0;
            managedTempStream.SetLength(0);
			using (Stream snappyWriter = Snappy.OpenWriter(managedTempStream))
			{
				snappyWriter.Write(testdata, 0, testdata.Length);
			    return managedTempStream.Length;
			}
		}


		[BenchmarkCategory("Decompress"), Benchmark]
		public int IronSnappyDecompressStream()
		{
			managedCompressedStream.Seek(0, SeekOrigin.Begin);
            using (Stream snappyReader = Snappy.OpenReader(managedCompressedStream))
            {
                snappyReader.Read(managedUncompressedBuffer, 0, managedUncompressedBuffer.Length);
                return managedUncompressedBuffer.Length;
            }         
		}


        [GlobalCleanup]
        public void Cleanup()
        {
            managedCompressedStream.Dispose();
            managedTempStream.Dispose();
        }
    }
}