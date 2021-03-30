using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Api.Utils
{
    public static class FormFileExtensions
    {
        public static FileModel ToFileModel(this IFormFile formFile)
        {
            var stream = new MemoryStream();
            using var formFileStream = formFile.OpenReadStream();

            formFileStream.CopyTo(stream);
            stream.Position = 0;

            return new FileModel
            {
                Name = formFile.FileName,
                ContentType = formFile.ContentType,
                Stream = stream
            };
        }

        public static IEnumerable<FileModel> ToFileModelCollection(this IFormFileCollection formFileCollection)
        {
            var files = new List<FileModel>();

            foreach (var formFile in formFileCollection)
            {
                files.Add(formFile.ToFileModel());
            }

            return files;
        }

    }
}
