using FileService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileService.DAL
{
    public interface IFileSystemConfigurator
    {
        Task AddConfigurationAsync(int companyId, FileMetadata fileMetadata);
        Task RemoveConfigurationAsync(int companyId, Guid fileId);
        Task<FileMetadata> GetConfigurationAsync(int companyId, Guid fileId);
        IAsyncEnumerable<FileMetadata> GetAllConfigurationsAsync(int companyId);
    }
}
