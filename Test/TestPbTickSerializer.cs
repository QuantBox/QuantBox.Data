using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantBox.Data.Serializer.V2;
using SevenZip;
using PbTickSerializer = QuantBox.Data.Serializer.PbTickSerializer;

namespace Test
{
    [TestClass]
    public class TestPbTickSerializer
    {
        static TestPbTickSerializer()
        {
            SevenZipBase.SetLibraryPath(Environment.Is64BitProcess ? "7z64.dll" : "7z.dll");
        }

        [TestMethod]
        public void TestRead()
        {
            var file = new FileInfo("TickDataV1_1");
            using (var stream = new MemoryStream())
            using (var fileStream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var zip = new SevenZipExtractor(fileStream)) {
                zip.ExtractFile(0, stream);
                stream.Seek(0, SeekOrigin.Begin);
                var serializer = new PbTickSerializer();
                var codec = new PbTickCodec();
                foreach (var tick in serializer.Read(stream)) {
                }
            }
        }
    }
}
