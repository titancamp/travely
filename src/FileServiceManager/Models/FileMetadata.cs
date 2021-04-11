using System;
using Newtonsoft.Json;

namespace FileService.Models
{
    public class FileMetadata
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("extension")]
        public string Extension { get; set; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }
        [JsonProperty("file_path")]
        public string FilePath { get; set; }
        [JsonProperty("file_content_type")]
        public string FileContentType { get; set; }
    }
}
