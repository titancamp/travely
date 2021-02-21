using FileService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Configuration;
using FileService.Helpers;

namespace FileService.DAL
{
    public class FileSystemStorage : IStorage
    {
        private readonly string _basePath;
        private readonly int _fileSizeLimit;
        private readonly IEnumerable<string> _allowedExtensions;
        private readonly IFileSystemConfigurator _fileSystemConfigurator;

        public FileSystemStorage(IConfiguration configuration, IFileSystemConfigurator fileSystemConfigurator)
        {
            _basePath = Path.Combine((configuration["storage:path"] ?? Directory.GetCurrentDirectory()) + "\\Files\\");

            if (!int.TryParse(configuration["file:sizeLimit"], out int fileSizeLimit))
            {
                fileSizeLimit = int.MaxValue;
            }

            _fileSizeLimit = fileSizeLimit;

            _fileSystemConfigurator = fileSystemConfigurator;

            _allowedExtensions = configuration.GetSection("file:allowedextensions").Get<IEnumerable<string>>()?? new List<string>();
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
                throw new RESTException($"File ID = {fileId} is not found for company = {companyId}");
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
                    File.Delete(fileInfo.FilePath);

                    await _fileSystemConfigurator.RemoveConfigurationAsync(companyId, fileId);

                    return true;
                }
            }

            return false;
        }

        public async Task<Guid> UploadFileAsync(IFormFile file, int companyId)
        {

            var companyBasePath = Path.Combine(_basePath + companyId.ToString());

            if (!Directory.Exists(companyBasePath))
            {
                Directory.CreateDirectory(companyBasePath);
            }

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var filePath = Path.Combine(companyBasePath, file.FileName);
            var extension = Path.GetExtension(file.FileName);

            if (ImageHelper.CheckExtension(extension, _allowedExtensions))
            {
                if (ImageHelper.CheckFileSize(file, _fileSizeLimit))
                {
                    if (!File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var fileMetadata = new FileMetadata()
                        {
                            Id = Guid.NewGuid(),
                            Extension = extension,
                            FilePath = filePath,
                            Name = fileName,
                            CreatedOn = DateTime.UtcNow,
                            FileType = file.ContentType
                        };

                        await _fileSystemConfigurator.AddConfigurationAsync(companyId, fileMetadata);

                        return fileMetadata.Id;
                    }
                    else
                    {
                        throw new RESTException($"File with name {fileName} already exists");
                    }
                }
                else
                {
                    throw new RESTException($"File size limit = {_fileSizeLimit / (1024 * 1024)} is exceeded");
                }
            }
            else
            {
                throw new RESTException($"File with extension = {extension} is not allowed");
            }
        }
    }
}

