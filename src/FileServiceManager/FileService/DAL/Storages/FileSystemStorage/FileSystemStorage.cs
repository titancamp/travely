using FileService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using FileService.Helpers;
using FileService.DAL.Storages.Options;
using Microsoft.Extensions.Options;

namespace FileService.DAL
{
    public class FileSystemStorage : IStorage
    {
        private readonly string _basePath;
        private readonly int _fileSizeLimit;
        private readonly FileExtension[] _allowedExtensions;
        private readonly IFileSystemConfigurator _fileSystemConfigurator;

        public FileSystemStorage(IOptions<StorageOption> options, IFileSystemConfigurator fileSystemConfigurator)
        {
            _basePath = Path.Combine((string.IsNullOrEmpty(options.Value.Path) ? Directory.GetCurrentDirectory() : options.Value.Path) + "/Files/");

            _fileSizeLimit = options.Value.FileSizeLimit??int.MaxValue;

            _fileSystemConfigurator = fileSystemConfigurator;

            _allowedExtensions = options.Value.AllowedExtensions;

        }
        public async Task<FileMetadata> GetFileAsync(Guid fileId, int companyId)
        {
            var fileInfo = await _fileSystemConfigurator.GetConfigurationAsync(companyId, fileId);

            if (fileInfo != null)
            {
                return fileInfo;
            }
            else
            {
                throw new InvalidOperationException($"File ID = {fileId} is not found for company = {companyId}");
            }
        }

        public async IAsyncEnumerable<FileMetadata> GetAllFilesAsync(int companyId)
        {
            await foreach (var file in _fileSystemConfigurator.GetAllConfigurationsAsync(companyId))
            {
                yield return file;
            }
        }

        public async Task<bool> RemoveFileAsync(Guid fileId, int companyId)
        {
            var fileInfo = await _fileSystemConfigurator.GetConfigurationAsync(companyId, fileId);

            if(fileInfo != null)
            {
                if (File.Exists(fileInfo.FilePath))
                {
                    await _fileSystemConfigurator.RemoveConfigurationAsync(companyId, fileId);

                    File.Delete(fileInfo.FilePath);

                    return true;
                }
            }

            return false;
        }

        public async Task<Guid> UploadFileAsync(IFormFile file, int companyId)
        {
            byte[] fileByteArray;

            var companyBasePath = Path.Combine(_basePath + companyId.ToString());

            if (!Directory.Exists(companyBasePath))
            {
                Directory.CreateDirectory(companyBasePath);
            }

            var fileName = Guid.NewGuid();
            var filePath = Path.Combine(companyBasePath, fileName.ToString("N"));
            var extension = Path.GetExtension(file.FileName);


            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileByteArray = ms.ToArray();
            }

            // check whether file signature is in allowed list
            if (!FileHelper.IsAllowedFileSignature(fileByteArray, _allowedExtensions))
            {
                throw new InvalidOperationException($"File with extension = {extension} is not allowed");
            }

            //checking for file size limit
            if(file.Length > _fileSizeLimit || fileByteArray.Length > _fileSizeLimit)
            {
                throw new InvalidOperationException($"File size limit = {(double)_fileSizeLimit / (1024 * 1024):0.##} MB is exceeded");
            }

            if (File.Exists(filePath))
            {
                throw new InvalidOperationException($"File with name {fileName} already exists");
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileMetadata = new FileMetadata()
            {
                Id = fileName,
                Extension = extension,
                FilePath = filePath,
                Name = fileName.ToString("N"),
                CreatedOn = DateTime.UtcNow,
                FileContentType = file.ContentType
            };

            await _fileSystemConfigurator.AddConfigurationAsync(companyId, fileMetadata);

            return fileMetadata.Id;
        }
    }
}

