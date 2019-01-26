using System.IO;
using K4os.Compression.LZ4.Streams;
using Microsoft.AspNetCore.ResponseCompression;

namespace hu.jia.ZippedWebAPI.Filters
{
    public class LZ4CompressionProvider : ICompressionProvider
    {
        public string EncodingName => "lz4";
        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream)
        {
            // Create the lz4 compression stream
            return LZ4Stream.Encode(outputStream);
            //return new GZipStream(outputStream, CompressionMode.Compress, false);
        }
    }
}
