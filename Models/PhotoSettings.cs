using System.IO;
using System.Linq;

namespace ProgrammingLog.Models
{
    public class PhotoSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsSupportedFileType(string fileName)
        {
            return AcceptedFileTypes.Any(s => s == Path.GetExtension(fileName).ToLower());
        }
    }
}