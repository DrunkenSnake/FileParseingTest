using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileParser.Domain;

namespace FileParser.Logic
{
    public class FileProcessor
    {
        #region Fields

        public FileReader _reader;

        #endregion Fields

        #region Constructors

        public FileProcessor() : this(new FileReader()){ }

        public FileProcessor(FileReader reader)
        {
            _reader = reader;
        }

        #endregion Constructors

        #region Methods

        #region Public

        public IEnumerable<int> ProcessFromPath(string filePath)
        {
            var menuToProcess = _reader.GetMenuFromFilePath(filePath);
            var returnValue = menuToProcess.Select(menu => menu.Items.Where(i => !string.IsNullOrEmpty(i?.Label)).ToArray().Sum(x => x.Id)).ToList();
            return returnValue;
        }

        #endregion Public

        #region Private



        #endregion Private

        #endregion Methods
    }
}
