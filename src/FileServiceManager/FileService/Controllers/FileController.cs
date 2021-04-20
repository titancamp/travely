using FileService.DAL;
using FileService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Travely.IdentityClient.Authorization;

namespace FileService.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IStorage _storage;

        public FileController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("Download")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<FileResult> DownLoadFileAsync(Guid fileId, int companyId)
        {
            var fileInfo = await _storage.GetFileAsync(fileId, companyId);

            return File(new FileStream(fileInfo.FilePath, FileMode.Open), fileInfo.FileContentType, fileInfo.Name + fileInfo.Extension);
        }

        [HttpPost("Upload")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<Guid>> UploadFileAsync(IFormFile file, int companyId)
        {
            return await _storage.UploadFileAsync(file, companyId);
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<bool>> RemoveFileAsync(Guid fileId, int companyId)
        {
            return await _storage.RemoveFileAsync(fileId, companyId);
        }

        [HttpGet("GetAllFiles")]
        [Authorize(Roles = UserRoles.User)]
        public async IAsyncEnumerable<FileMetadata> GetAllFilesAsync(int companyId)
        {
            await foreach(var fileInfo in _storage.GetAllFilesAsync(companyId))
            {
                yield return fileInfo;
            }
        }
    }
}
