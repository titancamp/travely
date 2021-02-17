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
        public async Task<FileMetadata> DownLoadFileAsync(Guid fileId)
        {
            //identity check
            return await _storage.DownLoadFileAsync(fileId);
        }

        [HttpPost("Upload")]
        public async Task<ActionResult<Guid>> UploadFileAsync(IFormFile file)
        {
            //identity check
            //companyName maybe could be obtained from Identity service otherwise we can put it as controller parameter
            return await _storage.UploadFileAsync(file, "companyName");
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveFileAsync(Guid fileId)
        {
            //identity check
            return await _storage.RemoveFileAsync(fileId);
        }

        [HttpGet("GetAllFiles")]
        public async Task<IEnumerable<FileMetadata>> GetAllFilesAsync(string companyName)
        {
            //identity check
            return await _storage.GetAllFilesAsync("companyName");
        }
    }
}
