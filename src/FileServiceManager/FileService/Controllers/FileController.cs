using FileService.DAL;
using FileService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileService.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IStorage _storage;

        public FileController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("Download/{fileId}")]
        public async Task<FileResult> DownLoadFileAsync(Guid fileId, int companyId)
        {
            return await _storage.DownLoadFileAsync(fileId, companyId);
        }

        [HttpPost("Upload")]
        public async Task<ActionResult<Guid>> UploadFileAsync(IFormFile file, int companyId)
        {
            return await _storage.UploadFileAsync(file, companyId);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveFileAsync(Guid fileId, int companyId)
        {
            return await _storage.RemoveFileAsync(fileId, companyId);
        }

        [HttpGet("GetAllFiles")]
        public async Task<IEnumerable<FileMetadata>> GetAllFilesAsync(int companyId)
        {
            return await _storage.GetAllFilesAsync(companyId);
        }
    }
}
