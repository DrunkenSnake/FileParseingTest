﻿using System;
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

        private readonly FileReader _reader;//reader to be used in processor, more functions can be added later

        #endregion Fields

        #region Constructors

        public FileProcessor()
        {
            _reader = new FileReader();
        }

        #endregion Constructors

        #region Methods

        #region Public

        public IEnumerable<int> ProcessFromPath(string filePath)
        {
            try
            {
                var menuToProcess = _reader.GetMenuFromFilePath(filePath); //get menu list from filepath
                var returnValue =
                    menuToProcess.Select(
                            menu => menu.Items.Where(i => !string.IsNullOrEmpty(i?.Label)).ToArray().Sum(x => x.Id))
                        .ToList(); //create list of sums of id's over the list of menus
                return returnValue;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion Public

        #region Private



        #endregion Private

        #endregion Methods
    }
}
