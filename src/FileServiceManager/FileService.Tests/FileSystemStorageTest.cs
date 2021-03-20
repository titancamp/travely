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
    public class FileSystemStorageTest
    {

        static IStorage sut;
        static IOptions<StorageOption> options;
        static Guid testId = Guid.NewGuid();

        [ClassInitializeAttribute]
        public static async Task Setup(TestContext ctx)
        {
            var mockConfigurator = new Mock<IFileSystemConfigurator>();
            mockConfigurator.Setup(it => it.GetConfigurationAsync(10000, It.IsAny<Guid>())).Returns<Task<FileMetadata>>(null);
            mockConfigurator.Setup(it => it.GetConfigurationAsync(30000, It.IsAny<Guid>())).Returns<Task<FileMetadata>>(null);
            mockConfigurator.Setup(it => it.GetConfigurationAsync(20000, testId)).ReturnsAsync(new FileMetadata() {Id = testId, Name = "testMetadata" });
            mockConfigurator.Setup(it => it.GetAllConfigurationsAsync(40000)).Returns(TestUtils.GetTestFiles());
            options = Options.Create(new StorageOption { Path = Directory.GetCurrentDirectory()});
            sut = new FileSystemStorage(options, mockConfigurator.Object);
        }

        [TestMethod]
        public async Task FileSystemStorageTest1_ConfigForCompanyIdFileIdDoesNotExist_GetFileAsyncFails()
        {
            TestUtils.AssertThrowsAsync(() => sut.GetFileAsync(Guid.NewGuid(), 10000));
        }

        [TestMethod]
        public async Task FileSystemStorageTest2_FileForCompanyExists_GetFileAsyncPasses()
        {
            var actualMetadata = await sut.GetFileAsync(testId, 20000);
            Assert.AreEqual(testId, actualMetadata.Id);
            Assert.AreEqual("testMetadata", actualMetadata.Name);
        }

        [TestMethod]
        public async Task FileSystemStorageTest3_FileForCompanyDoesNotExist_RemoveFileAsyncReturnsFalse()
        {
            var result = await sut.RemoveFileAsync(Guid.NewGuid(), 30000);
            Assert.IsFalse(result);
        }

       [TestMethod]
       public async Task FileSystemStorageTest4_CompanyHasFiles_GetAllFilesAsyncPasses()
       {
            var actualFiles = await sut.GetAllFilesAsync(40000).ToListAsync();
            Assert.AreEqual(2, actualFiles.Count());
            Assert.AreEqual("one", actualFiles[0].Name);
            Assert.AreEqual("two", actualFiles[1].Name);
       }
    }
}