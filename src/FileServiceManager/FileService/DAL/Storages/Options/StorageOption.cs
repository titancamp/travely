using FileService.Helpers;

namespace FileService.DAL.Storages.Options
{

    public class StorageOption
    {
        public const string Storage = "Storage";

        public string Path { get; set; }

        public int? FileSizeLimit { get; set; }

        public FileExtension[] AllowedExtensions { get; set; }
    }
}
