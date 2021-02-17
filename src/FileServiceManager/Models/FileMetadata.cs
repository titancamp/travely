using System;

namespace FileService.Models
{
    public class FileMetadata
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string FilePath { get; set; }
        public byte[] Content { get; set; }

    }
}

