using System.IO;
using System.Threading.Tasks;

namespace ActionCode.AsyncIO
{
    /// <summary>
    /// Synchronously streaming a sequence of bytes.
    /// </summary>
    public sealed class SynchronousStream : IStream
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

        public async Task<string> Read(StreamReader reader)
        {
            await Task.Yield();
            return reader.ReadToEnd();
        }

        public async Task Write(string path, string content)
        {
            await Task.Yield();
            using var writer = new StreamWriter(path);
            writer.Write(content);
        }

        public async Task Write(Stream stream, string content)
        {
            await Task.Yield();
            using var writer = new StreamWriter(stream);
            writer.Write(content);
        }

        public async Task Write(Stream stream, byte[] bytes)
        {
            await Task.Yield();
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}