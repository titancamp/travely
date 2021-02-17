using FileService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileService.DAL
{
    public interface IStorage
    {
        Task<Guid> UploadFileAsync(IFormFile file, int companyId);

        Task<IEnumerable<FileMetadata>> GetAllFilesAsync(int companyId);

        Task<FileMetadata> DownLoadFileAsync(Guid fileId, int companyId);

        Task<bool> RemoveFileAsync(Guid fileId, int companyId);

    }
}