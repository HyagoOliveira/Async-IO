using System.IO;
using System.Threading.Tasks;

namespace ActionCode.AsyncIO
{
    /// <summary>
    /// Asynchronously streaming a sequence of bytes.
    /// </summary>
    public sealed class AsynchronousStream : IStream
    {
        public async Task<string> Read(string path)
        {
            using var reader = new StreamReader(path);
            return await Read(reader);
        }

        public async Task<string> Read(Stream stream)
        {
            using var reader = new StreamReader(stream);
            return await Read(reader);
        }

        public async Task<string> Read(StreamReader reader) =>
            await reader.ReadToEndAsync();

        public async Task Write(string path, string content)
        {
            await using var writer = new StreamWriter(path);
            await writer.WriteAsync(content);
        }

        public async Task Write(Stream stream, string content)
        {
            await using var writer = new StreamWriter(stream);
            await writer.WriteAsync(content);
        }

        public async Task Write(Stream stream, byte[] bytes) =>
            await stream.WriteAsync(bytes, 0, bytes.Length);
    }
}