using System.Text;
using FluentAssertions;
using MongoDB.Driver.Core.Compression;

void StreamingCompressionSimpleWrite(byte[] data, int offset, int count)
{
    var tempStream = new MemoryStream();
    using (var input = new MemoryStream(data))
    using (var compressionStream = new ZstdSharp.CompressionStream(tempStream, 1))
    {
        input.CopyTo(compressionStream);
        //compressionStream.Flush();
    }

    tempStream.Seek(0, SeekOrigin.Begin);
    Console.WriteLine(string.Join(",", tempStream.ToArray()));

    var resultStream = new MemoryStream();
    using (var decompressionStream = new ZstdSharp.DecompressionStream(tempStream))
        decompressionStream.CopyTo(resultStream);

    var dataToCompress = new byte[count];
    Array.Copy(data, offset, dataToCompress, 0, count);

    var result = string.Join(",", resultStream.ToArray());
    result.Should().Be(string.Join(",", data));
}

// class Program 
// {
//     static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
// }

var data = "abcdefghijklmnopqrstuvwxyz0123456789 abcdefghijklmnopqrstuvwxyz0123456789 abcdefghijklmnopqrstuvwxyz0123456789";
var dataBytes = Encoding.ASCII.GetBytes(data);
//Console.WriteLine(string.Join(",", dataBytes));


StreamingCompressionSimpleWrite(dataBytes, 0, dataBytes.Length);

//using var compressor = new ZstdSharp.Compressor(1);
//var compressed = compressor.Wrap(dataBytes);
//Console.WriteLine(string.Join(",", compressed.ToArray()));
using (var input = new MemoryStream(dataBytes))
using (var output = new MemoryStream())
{
    var compressor = new ZstandardCompressor(1);
    compressor.Compress(input, output);
    Console.WriteLine(string.Join(",", output.ToArray()));
}

Console.WriteLine("done");



//System.Console.WriteLine(string.Join(",", dataBytes));

////var input = new MemoryStream(dataBytes);
//var output = new MemoryStream();
//using (var zstandardStream = new ZstdSharp.CompressionStream(output, 6))
//{
//    // System.Console.WriteLine(string.Join(",", input.ToArray()));
//    // input.CopyTo(zstandardStream);
//    zstandardStream.Write(dataBytes, 0, dataBytes.Length);
//    Console.WriteLine(output.Length);
//    Console.WriteLine(string.Join(",", output.ToArray()));
//}

// using (var input = new MemoryStream())
// using (var output = new MemoryStream())
// using (var zstandardStream = new ZstdSharp.DecompressionStream(input))
// {
//     zstandardStream.CopyTo(output);
// }