using FileService.Models;
using System.Collections.Generic;

namespace Models
{
    public class CompanyMetadata
    {
        public int CompanyId { get; set; }

        public IEnumerable<FileMetadata> files { get; set; }
    }
}
