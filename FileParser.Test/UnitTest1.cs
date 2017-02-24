using System.Collections.Generic;
using System.Linq;
using FileParser.Domain;
using FileParser.Logic;
using NUnit.Framework;
using System.Reflection;

namespace FileParser.Test
{
    [TestFixture]
    public class UnitTest1
    {
        private FileProcessor _processor;
        private FileReader _reader;
        [SetUp]
        public void SetUp()
        {
            _processor = new FileProcessor();
            _reader = new FileReader();
        }

        [Test]
        public void DoesTextDeserialize()
        {
            const string fileName = "testParseMent.txt";
            var filePath = Assembly.GetExecutingAssembly().GetManifestResourceInfo(fileName)?.ResourceLocation.ToString();
            var results = _reader.GetMenuFromFilePath(filePath).ToArray();
            var isItemNull = false;
            foreach (var result in results)
            {
                if (string.IsNullOrEmpty(result.Header) || !result.Items.Any())//if the header is null or empty or the items are blank it didn't deserialize properly
                {
                    isItemNull = true;
                }
            }
            Assert.IsFalse(isItemNull);
        }
        [Test]
        public void DoesFileParse()
        {
            var checkList = new List<int> { 46, 0, 248 };
            const string fileName = "testParseMent.txt";
            var filePath = Assembly.GetExecutingAssembly().GetManifestResourceInfo(fileName)?.ResourceLocation.ToString();
            var results = _processor.ProcessFromPath(filePath).ToArray();
            var equality = results.Intersect(checkList);//get all results that intersect with checklist
            Assert.AreEqual(checkList.Count(), results.Count());//make sure check list and results list are the same size
            Assert.AreEqual(equality.Count(), checkList.Count);//make sure intersect is the same size
        }
    }
}
