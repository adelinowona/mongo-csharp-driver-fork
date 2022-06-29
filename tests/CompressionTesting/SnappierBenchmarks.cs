using Snappier;
using System.IO.Compression;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes;
using MongoDB.Driver.Core.Compression.Snappy;
using CompressionTesting.DataGenerator;


namespace CompressionTesting.CompressionBenchmarks
{
	[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
	[CategoriesColumn]
	public class SnappierBenchmarks
	{
		
		[Params("2.9mb_text_file", "490kB_text_file", "156kB_text_file", "49mb_json_file", "27mb_json_file", "39kB_json_file", "randomData", "repetitiveData")]
		public string which_data;

		private byte[] testdata;

		private byte[] managedCompressBuffer;
		private byte[] managedCompressedBlock;
		private byte[] managedDecompressBuffer;

		private byte[] unmanagedCompressBuffer;
		private byte[] unmanagedCompressedBlock;
		private byte[] unmanagedDecompressBuffer;

		private int managedCompressedSize;
		private MemoryStream managedCompressedStream;


		[GlobalSetup]
		 /* Runs before any of the functions marked as benchmark are run.
		  *  This setup is used to store the compressed versions of the datafile currently used
		  *  for benchmarking so they can be used in the decompress benchmarks.
		  */
		public void Setup()
		{
			var dataGenerator = new TestDataGenerator(which_data);
			testdata = dataGenerator.GetData();
			
			ManagedCodeSetup();
			UnmanagedCodeSetup();
		}


		// Setup for managed code benchmarks
		private void ManagedCodeSetup()
		{
			managedCompressedBlock = new byte[Snappy.GetMaxCompressedLength(testdata.Length)];
			managedCompressedSize = Snappy.Compress(testdata, managedCompressedBlock);

			managedCompressBuffer = new byte[Snappy.GetMaxCompressedLength(testdata.Length)];
			managedDecompressBuffer = new byte[Snappy.GetUncompressedLength(managedCompressedBlock.AsSpan(0, managedCompressedSize))];

			managedCompressedStream = new MemoryStream();
			using (Stream snappierStream = new SnappyStream(managedCompressedStream, CompressionMode.Compress, true))
			{
				snappierStream.Write(testdata.AsSpan(0, testdata.Length));
			}
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
        public byte[] UnmanagedCompress()
        {
           SnappyCodec.Compress(
                input: testdata,
                inputOffset: 0,
                inputLength: testdata.Length,
                output: unmanagedCompressBuffer,
                outputOffset: 0,
                outputLength: unmanagedCompressBuffer.Length);
            return  unmanagedCompressBuffer;
        }


        [BenchmarkCategory("Decompress"), Benchmark(Baseline = true)]
        public byte[] UnmanagedDecompress()
        {
           SnappyCodec.Uncompress(
                input: unmanagedCompressedBlock,
                inputOffset: 0,
                inputLength: unmanagedCompressedBlock.Length,
                output: unmanagedDecompressBuffer,
                outputOffset: 0,
                outputLength: unmanagedDecompressBuffer.Length);
            return  unmanagedDecompressBuffer; 
        }


		[BenchmarkCategory("Compress"), Benchmark]
		public byte[] SnappierCompressBlock()
		{
			Snappy.Compress(testdata, managedCompressBuffer);
			return managedCompressBuffer;
		}


		[BenchmarkCategory("Decompress"), Benchmark]
		public byte[] SnappierDecompressBlock()
        {
			Snappy.Decompress(managedCompressedBlock.AsSpan(0, managedCompressedSize), managedDecompressBuffer);
			return managedDecompressBuffer;
		}


		[BenchmarkCategory("Compress"), Benchmark]
		public byte[] SnappierCompressStream()
		{
			using (MemoryStream tempStream = new MemoryStream())
			using (Stream snappierStream = new SnappyStream(tempStream, CompressionMode.Compress, true))
			{
				snappierStream.Write(testdata);
				tempStream.Seek(0, SeekOrigin.Begin);

				return tempStream.ToArray();
			}
		}


		[BenchmarkCategory("Decompress"), Benchmark]
		public byte[] SnappierDecompressStream()
		{
			managedCompressedStream.Seek(0, SeekOrigin.Begin);
			using (Stream snappierStream = new SnappyStream(managedCompressedStream, CompressionMode.Decompress, true))
			{
				var uncompressed = new byte[testdata.Length];
				snappierStream.Read(uncompressed, 0, testdata.Length);
				return uncompressed;
			}
		}


		[GlobalCleanup]
		public void Cleanup()
		{
			managedCompressedStream.Dispose();
		}
	}
}