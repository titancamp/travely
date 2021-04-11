using FileService.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models
{
    public class CompanyMetadata
    {
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }

        public IEnumerable<FileMetadata> files { get; set; }
    }
}
