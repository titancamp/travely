using FileService.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Options;
using FileService.DAL.Storages.Options;
using FileService.Models;
using System;
using System.Linq;


namespace FileService.Tests
{
    [TestClass]
    public class FileSystemJsonConfiguratorTest
    {   
        static IFileSystemConfigurator sut;
        static IOptions<StorageOption> option;
        static int newConfigurationCompanyID = 1001;
        static Guid newConfigurationGuid = Guid.NewGuid();
        static int companyIdToDeleteConfigFrom = 2001;
        static Guid guidToDeleteConfigFrom = Guid.Parse("cb766b03-9553-4caa-a588-9493870a2bad");

        [ClassInitializeAttribute]
        public static async Task Setup(TestContext ctx)
        {
            option = Options.Create(new StorageOption {Path = Path.Combine(Directory.GetCurrentDirectory(), "Assets").Replace("bin\\Debug\\netcoreapp5.0\\", "")});
            sut = new FileSystemJsonConfigurator(option);

            await sut.AddConfigurationAsync(companyIdToDeleteConfigFrom, new FileMetadata() {Id = guidToDeleteConfigFrom});
        }

        [TestMethod]
        public async Task FileSystemJsonConfigurator1_JsonConfigFileDoesNotExist_AddConfigurationFails()
        {
            var sut = new FileSystemJsonConfigurator(Options.Create(new StorageOption() {Path = "does-not-exist"}));
            TestUtils.AssertThrowsAsync(() => sut.AddConfigurationAsync(80, new FileMetadata()));
        }

        [TestMethod] 
        public async Task FileSystemJsonConfigurator2_JsonConfigFileAndRootTokenExistCompanyTokenDoesNotExist_AddConfigurationPasses() 
        {
            var id = newConfigurationCompanyID;
            var guid = newConfigurationGuid;
            await sut.AddConfigurationAsync(id, new FileMetadata() {Id = guid, Name = "TestName", Extension = "ext", CreatedOn = DateTime.Now, FilePath = "path", FileContentType = "type"});
            var actualFileMetadata = await sut.GetConfigurationAsync(newConfigurationCompanyID, newConfigurationGuid);
            Assert.AreEqual("TestName", actualFileMetadata.Name);
            Assert.AreEqual("ext", actualFileMetadata.Extension);
        }

        [TestMethod]
        public async Task FileSystemJsonConfigurator3_CompanyTokenAndConfigurationIdExist_RemoveConfigurationPasses() 
        {
            await sut.RemoveConfigurationAsync(newConfigurationCompanyID, newConfigurationGuid);
        }

        [TestMethod]
        public async Task FileSystemJsonConfigurator4_CompanyIdDoesNotExist_GetConfigurationFails() 
        {
            var nonExistentCompanyId = 5;
            await TestUtils.AssertThrowsAsync(() => sut.GetConfigurationAsync(nonExistentCompanyId, Guid.NewGuid()));
        }

        [TestMethod]
        public async Task FileSystemJsonConfigurator5_CompanyIdDoesNotExist_GetAllConfigurationFails()
        {
           var nonExistentComapnyId = 10; 
           await TestUtils.AssertThrowsAsyncEnumerable(() => sut.GetAllConfigurationsAsync(nonExistentComapnyId));
        }

        [TestMethod]
        public async Task FileSystemJsonConfigurator6_CompanyIdAndFileGuidExist_GetConfigurationPasses()
        {
            var actualFileMetatada = await sut.GetConfigurationAsync(1, Guid.Parse("654bd9c9-cd9a-4663-8772-3bf7dfdbe13f"));
            Assert.AreEqual("Booking", actualFileMetatada.Name);
            Assert.AreEqual("654bd9c9-cd9a-4663-8772-3bf7dfdbe13f", actualFileMetatada.Id.ToString());
            Assert.AreEqual("txt", actualFileMetatada.Extension);
        }

        [TestMethod]
        public async Task FileSystemJsonConfigurator7_CompanyIdExists_GetAllConfigurationPasses()
        {
            var files = await sut.GetAllConfigurationsAsync(3).ToListAsync();   
            Assert.AreEqual(2, files.Count());
        }

        [TestMethod]
        public async Task FileSystemJsonConfigurator8_CompanyIdExistsWithMultipleFiles_RemoveConfigurationPasses()
        {
            var filesPriorDeletion = await sut.GetAllConfigurationsAsync(companyIdToDeleteConfigFrom).ToListAsync();
            Assert.AreEqual(2, filesPriorDeletion.Count());
            await sut.RemoveConfigurationAsync(companyIdToDeleteConfigFrom, guidToDeleteConfigFrom);
            var files = await sut.GetAllConfigurationsAsync(companyIdToDeleteConfigFrom).ToListAsync();
            Assert.AreEqual(1, files.Count());
        }
    }
}