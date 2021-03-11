using FileService.DAL.Storages.Options;
using FileService.Models;
using Microsoft.Extensions.Options;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// FileSystemJsonConfigurator implementing IFileSystemConfigurator. Used to read/write/remove json configuration about company's file system structure
/// </summary>

namespace FileService.DAL
{
    public class FileSystemJsonConfigurator : IFileSystemConfigurator
    {
        private readonly string _configPath;

        public FileSystemJsonConfigurator(IOptions<StorageOption> options)
        {
            _configPath = Path.Combine(string.IsNullOrEmpty(options.Value.Path) ? Directory.GetCurrentDirectory(): options.Value.Path, "FileSystemConfig.json");
        }

        public async Task AddConfigurationAsync(int companyId, FileMetadata fileMetadata)
        {
            StreamWriter fileWriter = null;
            try
            {
                JToken rootToken = await GetRootTokenAsync();

                if (rootToken == null)
                {
                    throw new FileNotFoundException("Configuration file is not found");
                }

                JToken companiesToken = rootToken.SelectToken($"$.companies[?(@.companyId == {companyId})]");

                //if company node exists, add new file to files array
                if (companiesToken != null)
                {
                    JArray filesArrayToken = (JArray)companiesToken.SelectToken($"$..files");
                    filesArrayToken.Add(JToken.FromObject(fileMetadata));
                }
                else
                {
                    //if company node does not exist, add company first, then files array to that company
                    var compArray = (JArray)rootToken.SelectToken($"$.companies");

                    CompanyMetadata company = new CompanyMetadata() { CompanyId = companyId, files = new List<FileMetadata>() { fileMetadata } };
                    compArray.Add(JToken.FromObject(company));
                }

                using (fileWriter = File.CreateText(_configPath))
                {
                    using (JsonTextWriter writer = new JsonTextWriter(fileWriter) { Formatting = Formatting.Indented })
                    {
                        await rootToken.WriteToAsync(writer);
                    }
                }
            }

            finally
            {
                fileWriter?.Close();
            }
        }

        public async IAsyncEnumerable<FileMetadata> GetAllConfigurationsAsync(int companyId)
        {
            JToken filesToken;
    
            JToken rootToken = await GetRootTokenAsync();

            if(rootToken == null)
            {
                throw new FileNotFoundException("Configuration file is not found");
            }

            filesToken = rootToken.SelectToken($"$.companies[?(@.companyId == {companyId})]")?.SelectToken($"$..files");

            if (filesToken == null)
            {
                throw new InvalidOperationException($"Company ID = {companyId} is not found");
            }

            foreach (var fileToken in filesToken)
            {
                yield return fileToken.ToObject<FileMetadata>();
            }
        }

        public async Task<FileMetadata> GetConfigurationAsync(int companyId, Guid fileId)
        {
 
            JToken rootToken = await GetRootTokenAsync();

            if (rootToken == null)
            {
                throw new FileNotFoundException("Configuration file is not found");
            }

            JToken filesToken = rootToken.SelectToken($"$.companies[?(@.companyId == {companyId})]")?.SelectToken($"$..files[?(@.Id == '{fileId}')]");

            if (filesToken == null)
            {
                throw new InvalidOperationException($"File for Company ID = { companyId } is not found");
            }

            return filesToken.ToObject<FileMetadata>();
        }

        public async Task RemoveConfigurationAsync(int companyId, Guid fileId)
        {
            StreamWriter fileWriter = null;
            try
            {
                JToken rootToken = await GetRootTokenAsync();
                if (rootToken == null)
                {
                    throw new FileNotFoundException("Configuration file is not found");
                }

                JToken fileToken = rootToken.SelectToken($"$.companies[?(@.companyId == {companyId})]")?.SelectToken($"$..files[?(@.Id == '{fileId}')]");

                if (fileToken != null)
                {
                    fileToken.Remove();
                }

                using (fileWriter = File.CreateText(_configPath))
                {
                    using (JsonTextWriter writer = new JsonTextWriter(fileWriter) { Formatting = Formatting.Indented })
                    {
                        await rootToken.WriteToAsync(writer);
                    }
                }
            }

            finally
            {
                fileWriter?.Close();
            }
        }

        private async Task<JToken> GetRootTokenAsync()
        {
            StreamReader fileReader = null;

            try
            {
                using (fileReader = File.OpenText(_configPath))
                {
                    using (JsonTextReader reader = new JsonTextReader(fileReader))
                    {
                         return await JToken.ReadFromAsync(reader);
                    }
                }
            }
            catch(FileNotFoundException e)
            {
                throw new FileNotFoundException("Configuration file is not found", e);
            }
            finally
            {
                fileReader?.Close();
            }
        }
    }
}
