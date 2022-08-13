using System.IO;
using System.Threading.Tasks;

namespace ActionCode.AsyncIO
{
    /// <summary>
    /// Interface used on objects able to streaming a sequence of bytes.
    /// </summary>
    public interface IStream
    {
        Task Write(string path, string content);
        Task Write(Stream stream, string content);
        Task Write(Stream stream, byte[] bytes);

        Task<string> Read(string path);
        Task<string> Read(Stream stream);
        Task<string> Read(StreamReader reader);
    }
}