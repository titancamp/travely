using FileService.Models;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog.Fluent;
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
        private readonly string _configPath = "";

        public FileSystemJsonConfigurator(IConfiguration configuration)
        {
            _configPath = Path.Combine(configuration["storage:path"] ?? Directory.GetCurrentDirectory(), "FileSystemConfig.json");
        }

        public async Task AddConfigurationAsync(int companyId, FileMetadata fileMetadata)
        {
            JToken rootToken = null;
            StreamReader fileReader = null;
            StreamWriter fileWriter = null;
            try
            {
                using (fileReader = File.OpenText(_configPath))
                {
                    using (JsonTextReader reader = new JsonTextReader(fileReader))
                    {
                        rootToken = await JToken.ReadFromAsync(reader);
                    }
                }

                if (rootToken != null)
                {
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

                        CompanyMetadata company = new CompanyMetadata() { companyId = companyId, files = new List<FileMetadata>() { fileMetadata } };
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
                else
                {
                    Log.Error("FileSystemConfig.json is not found");
                }
            }

            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                fileReader?.Close();
                fileWriter?.Close();
            }
        }

        public async IAsyncEnumerable<FileMetadata> GetAllConfigurationsAsync(int companyId)
        {
            JToken rootToken = null;
            StreamReader file = null;
            JToken filesToken = null;
            try
            {
                using (file = File.OpenText(_configPath))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        rootToken = await JToken.ReadFromAsync(reader);
                    }
                }

                if (rootToken != null)
                {
                    filesToken = rootToken.SelectToken($"$.companies[?(@.companyId == {companyId})]")?.SelectToken($"$..files");
                }
                else
                {
                    Log.Error("FileSystemConfig.json is not found");
                }
            }

            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            finally
            {
                file?.Close();
            }

            if (filesToken == null)
            {
                Log.Error($"No file for company ID = {companyId}");
            }
            else
            {
                foreach (var fileToken in filesToken)
                {
                    yield return fileToken.ToObject<FileMetadata>();
                }
            }
        }

        public async Task<FileMetadata> GetConfigurationAsync(int companyId, Guid fileId)
        {
            JToken rootToken = null;
            StreamReader file = null;
            try
            {
                using (file = File.OpenText(_configPath))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        rootToken = await JToken.ReadFromAsync(reader);
                    }
                }

                if (rootToken != null)
                {
                    JToken filesToken = rootToken.SelectToken($"$.companies[?(@.companyId == {companyId})]")?.SelectToken($"$..files[?(@.Id == '{fileId}')]");

                    if (filesToken != null)
                    {
                        return filesToken.ToObject<FileMetadata>();
                    }
                    else
                    {
                        Log.Error($"No file with id = {fileId} for company ID = {companyId}");
                    }
                }
                else
                {
                    Log.Error("FileSystemConfig.json is not found");
                }
            }

            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            finally
            {
                file?.Close();
            }
            return null;
        }

        public async Task RemoveConfigurationAsync(int companyId, Guid fileId)
        {
            JToken rootToken = null;
            StreamReader fileReader = null;
            StreamWriter fileWriter = null;
            try
            {
                using (fileReader = File.OpenText(_configPath))
                {
                    using (JsonTextReader reader = new JsonTextReader(fileReader))
                    {
                        rootToken = await JToken.ReadFromAsync(reader);
                    }
                }

                if (rootToken != null)
                {
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
                else
                {
                    Log.Error("FileSystemConfig.json is not found");
                }
            }

            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                fileReader?.Close();
                fileWriter?.Close();
            }
        }
    }
}
