using FileService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileService.DAL
{
    public class FileSystemStorage : IStorage
    {
        public async Task<FileResult> DownLoadFileAsync(Guid fileId, int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FileMetadata>> GetAllFilesAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFileAsync(Guid fileId, int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UploadFileAsync(IFormFile file, int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
