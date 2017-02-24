using System;
using System.Collections.Generic;
using System.IO;
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
            var filePath = CreateTempFile();//create tempfile from resource
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
            var filePath = CreateTempFile();//create temp file from resource
            var results = _processor.ProcessFromPath(filePath).ToArray();
            var equality = results.Intersect(checkList);//get all results that intersect with checklist
            Assert.AreEqual(checkList.Count(), results.Count());//make sure check list and results list are the same size
            Assert.AreEqual(equality.Count(), checkList.Count);//make sure intersect is the same size
        }

        [Test]
        public void DoesBadFileThrowException()//check if passing a bad file results in thrown exception
        {
            var filePath = CreateTempFile().Replace("t", "r");//corrupt file path will always have a t because is txt
            Assert.Throws<Exception>(delegate {_processor.ProcessFromPath(filePath);}, $"Invalid File found for path {filePath}");
        }

        [Test]
        public void DoesBlankFileThrowException()//check if passing a bad file results in thrown exception
        {
            var filePath = CreateBlankTempFile();//file with no data
            Assert.Throws<Exception>(delegate { _processor.ProcessFromPath(filePath); }, $"Invalid File found for path {filePath}");
        }

        private static string CreateTempFile()
        {
            var resourceData = Properties.Resources.testParseMenu;//get resource content string
            var tempFile = Path.GetTempFileName().Replace("tmp", "txt");//temp file path, saved as txt
            using (var outputFile = new StreamWriter(tempFile))
            {
                outputFile.Write(resourceData);//write tempfile
            }
            return tempFile;//return path
        }
        private static string CreateBlankTempFile()
        {
            var resourceData = "";//get resource content string
            var tempFile = Path.GetTempFileName().Replace("tmp", "txt");//temp file path, saved as txt
            using (var outputFile = new StreamWriter(tempFile))
            {
                outputFile.Write(resourceData);//write tempfile
            }
            return tempFile;//return path
        }
    }
}
