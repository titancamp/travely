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
        Task<Guid> UploadFileAsync(IFormFile file, string fileCreator);

        Task<IEnumerable<FileMetadata>> GetAllFilesAsync(string fileCreator);

        Task<FileMetadata> DownLoadFileAsync(Guid fileId);

        Task<bool> RemoveFileAsync(Guid fileId);

    }
}