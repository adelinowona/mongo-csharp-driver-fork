using System.IO;
using System.Threading;
using MongoDB.Driver.Core.Misc;


namespace MongoDB.Driver.Core.Compression
{
    internal class SnappierCompressor : ICompressor
    {
        public CompressorType Type => CompressorType.Snappy;

        /// <summary>
        /// Compresses the remainder of <paramref name="input"/>, writing the compressed data to
        /// <paramref name="output"/>.
        /// </summary>
        /// <param name="input"> The input stream.</param>
        /// <param name="output">The output stream.</param>
        public void Compress(Stream input, Stream output)
        {
            var uncompressedSize = (int)(input.Length - input.Position);
            var uncompressedBytes = new byte[uncompressedSize];
            input.ReadBytes(uncompressedBytes, offset: 0, count: uncompressedSize, CancellationToken.None);
            var maxCompressedSize = Snappier.Snappy.GetMaxCompressedLength(uncompressedSize);
            var compressedBytes = new byte[maxCompressedSize];
            var compressedSize = Snappier.Snappy.Compress(uncompressedBytes, compressedBytes);
            output.Write(compressedBytes, 0, compressedSize);
        }


        /// <summary>
        /// Decompresses the remainder of  <paramref name="input"/>, writing the uncompressed data to <paramref name="output"/>.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <param name="output">The output stream.</param>
        public void Decompress(Stream input, Stream output)
        {
            var compressedSize = (int)(input.Length - input.Position);
            var compressedBytes = new byte[compressedSize];
            input.ReadBytes(compressedBytes, offset: 0, count: compressedSize, CancellationToken.None);
            var uncompressedSize = Snappier.Snappy.GetUncompressedLength(compressedBytes);
            var decompressedBytes = new byte[uncompressedSize];
            var decompressedSize = Snappier.Snappy.Decompress(compressedBytes, decompressedBytes);
            output.Write(decompressedBytes, offset: 0, count: decompressedSize);
        }
    }
}

