using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FileService.Helpers
{
    public static class ImageHelper
    {
        public static bool CheckExtension(string extension, IEnumerable<string> allowedExtensions)
        {
            return allowedExtensions.Contains(extension);
        }

        public static bool CheckFileSize(IFormFile file, int SizeLimit)
        {
            byte[] fileByteArray;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileByteArray = ms.ToArray();
            }

            if(fileByteArray.Length > SizeLimit)
            {
                return false;
            }

            return true;
        }
    }
}
