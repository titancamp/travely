using System;
using System.Linq;

namespace FileService.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Method that checks whether signature of file is in allowed list
        /// </summary>
        /// <param name="fileByteArray"></param>
        /// <param name="allowedExtensions"></param>
        /// <returns></returns>
        public static bool IsAllowedFileSignature(byte[] fileByteArray, FileExtension[] allowedExtensions)
        {
            foreach (var allowedExtension in allowedExtensions)
            {
                if (allowedExtension.Signatures.Any(signature => fileByteArray.Take(signature.Length).SequenceEqual(signature)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
