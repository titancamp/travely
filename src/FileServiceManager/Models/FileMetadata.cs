using System;

namespace FileService.Models
{
    public class FileMetadata
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
}
