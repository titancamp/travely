using System.IO;

namespace TourManager.Common.Clients.PropertyManager
{
    public class FileModel
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public Stream Stream { get; set; }
    }
}
