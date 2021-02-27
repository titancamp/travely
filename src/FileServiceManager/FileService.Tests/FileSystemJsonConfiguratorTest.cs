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
            option = Options.Create(new StorageOption {Path = Path.Combine(Directory.GetCurrentDirectory(), "json1").Replace("bin\\Debug\\netcoreapp5.0\\", "")});
            sut = new FileSystemJsonConfigurator(option);

            await sut.AddConfigurationAsync(companyIdToDeleteConfigFrom, new FileMetadata() {Id = guidToDeleteConfigFrom});
        }

        [TestMethod] 
        public async Task Test1_AddConfugration_Should_Pass_If_File_Is_Valid() 
        {
            var id = newConfigurationCompanyID;
            var guid = newConfigurationGuid;
            await sut.AddConfigurationAsync(id, new FileMetadata() {Id = guid, Name = "TestName"});
        }

        [TestMethod]
        public async Task Test2_RemoveConfiguration_Should_Pass_With_Existent_Companyid_Guid() 
        {
            await sut.RemoveConfigurationAsync(newConfigurationCompanyID, newConfigurationGuid);
        }

        [TestMethod]
        public async Task Test3_GetConfiguration_Should_Fail_If_No_Config_Is_Found_Async() 
        {
            await TestUtils.AssertThrowsAsync(() => sut.GetConfigurationAsync(5, Guid.NewGuid()));
        }

        [TestMethod]
        public async Task Test4_GetAllConfigurations_Should_Fail_If_Root_Token_Is_Null_Async()
        {
              var ex = await TestUtils.AssertThrowsAsyncEnumerable(() => sut.GetAllConfigurationsAsync(10));
        }

        [TestMethod]
        public async Task Test5_GetConfigurationAsync_Should_Pass_With_Valid_CompanyId_Guid()
        {
            var actualFileMetatada = await sut.GetConfigurationAsync(1, Guid.Parse("654bd9c9-cd9a-4663-8772-3bf7dfdbe13f"));
            Assert.AreEqual("Booking", actualFileMetatada.Name);
            Assert.AreEqual("654bd9c9-cd9a-4663-8772-3bf7dfdbe13f", actualFileMetatada.Id.ToString());
            Assert.AreEqual("txt", actualFileMetatada.Extension);
        }

        [TestMethod]
        public async Task Test6_GetAllConfigurations_Should_Pass_With_Valid_CompanyId()
        {
            var files = await sut.GetAllConfigurationsAsync(3).ToListAsync();   
            Assert.AreEqual(2, files.Count());
        }

        [TestMethod]
        public async Task Test7_RemoveConfiguration_Shoul_Pass_With_Valid_CompanyId_Guid_From_Multiitem_Files()
        {
            var filesPriorDeletion = await sut.GetAllConfigurationsAsync(companyIdToDeleteConfigFrom).ToListAsync();
            Assert.AreEqual(2, filesPriorDeletion.Count());
            await sut.RemoveConfigurationAsync(companyIdToDeleteConfigFrom, guidToDeleteConfigFrom);
            var files = await sut.GetAllConfigurationsAsync(companyIdToDeleteConfigFrom).ToListAsync();
            Assert.AreEqual(1, files.Count());
        }

        [TestMethod]
        public async Task Test8_AddConfiguration_Should_Fail_If_File_Is_Not_Found()
        {
            var sut = new FileSystemJsonConfigurator(Options.Create(new StorageOption() {Path = "does-not-exist"}));
            TestUtils.AssertThrowsAsync(() => sut.AddConfigurationAsync(80, new FileMetadata()));
        }

    }
}