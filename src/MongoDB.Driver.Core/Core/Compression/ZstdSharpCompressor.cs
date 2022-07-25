using System.IO;
using MongoDB.Driver.Core.Misc;

namespace MongoDB.Driver.Core.Compression
{
    public class ZstdSharpCompressor : ICompressor
    {

        public CompressorType Type => CompressorType.ZStandard;

        // private constants
        private const int _defaultCompressionLevel = 6;

        // private fields
        private readonly int _compressionLevel;

        public ZstdSharpCompressor(Optional<int> compressionLevel = default)
        {
            _compressionLevel = compressionLevel.WithDefault(_defaultCompressionLevel);
        }

        public void Compress(Stream input, Stream output)
        {
            using (var zstdSharpStream = new ZstdSharp.CompressionStream(output, _compressionLevel))
            {
                input.EfficientCopyTo(zstdSharpStream);
            }
        }

        public void Decompress(Stream input, Stream output)
        {
            using (var zstdSharpStream = new ZstdSharp.DecompressionStream(input))
            {
                zstdSharpStream.CopyTo(output);
            }
        }
    }
}
