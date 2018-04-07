using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncCode.UnitTest
{
    [TestClass]
    public class FileReaderAsyncTest
    {
        private string _ValidPath = "DummyText.txt";
        private string _InvalidPath = "";
        private FileReaderAsync _fileReaderAsync;

        [TestInitialize]
        public void Init()
        {
            _ValidPath = @"DemoFile/LargeText.txt";
            _InvalidPath = @"DemoFile/DoNotExist.txt";
            _fileReaderAsync = new FileReaderAsync();
        }

        [TestMethod]
        public async Task FileRead_ValidPath_NoErrors()
        {
            var data = await _fileReaderAsync.ReadFileAsync(_ValidPath);
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public async Task FileRead_InvalidPath_FileNotFoundException()
        {
            var data = await _fileReaderAsync.ReadFileAsync(_InvalidPath);
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public async Task FileRead_ConstructorOperationNotValidAndFileNotFoundException_NotFound()
        {
            _fileReaderAsync = new FileReaderAsync(true);
            var data = await _fileReaderAsync.ReadFileAsync(_InvalidPath);
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length > 0);
        }

        [TestMethod]
        public async Task FileRead_ConstructorOperationNotValidAndFileNotFoundException_Found()
        {
            Assert.ThrowsException<InvalidOperationException>(()=>_fileReaderAsync = new FileReaderAsync(true));
            // Reinitialize
            _fileReaderAsync = new FileReaderAsync();
            await Assert.ThrowsExceptionAsync<FileNotFoundException>(async () => await _fileReaderAsync.ReadFileAsync(_InvalidPath));
        }
    }
}
