using FileService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileService.DAL
{
    public class FileSystemStorage : IStorage
    {
        private readonly IConfiguration _configuration;
        public FileSystemStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<FileMetadata> DownLoadFileAsync(Guid fileId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FileMetadata>> GetAllFilesAsync(string companyName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFileAsync(Guid fileId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UploadFileAsync(IFormFile file, string companyName)
        {
            throw new NotImplementedException();
            //var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
            //bool basePathExists = System.IO.Directory.Exists(basePath);
            //if (!basePathExists) Directory.CreateDirectory(basePath);
            //var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            //var filePath = Path.Combine(basePath, file.FileName);
            //var extension = Path.GetExtension(file.FileName);
            //if (!File.Exists(filePath))
            //{
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await file.CopyToAsync(stream);
            //    }
            //    var fileModel = new FileMetadata
            //    {
            //        Id = Guid.NewGuid(),
            //        CreatedOn = DateTime.UtcNow,
            //        Extension = extension,
            //        Name = fileName,
            //        FilePath = filePath
            //    };

            //    //
            //}
            //else
            //{
            //    throw new RESTException();
            //}
        }
    }
}
