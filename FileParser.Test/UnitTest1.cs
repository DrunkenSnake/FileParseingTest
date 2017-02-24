using FileParser.Domain;
using FileParser.Logic;
using NUnit.Framework;

namespace FileParser.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void SetUp()
        {
            var _processor = new FileProcessor();
            var _reader = new FileReader();
        }
        [Test]
        public void DoesFileParse()
        {
        }
    }
}
