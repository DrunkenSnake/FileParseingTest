using System.Collections.Generic;
using System.IO;
using System.Text;
using FileParser.Domain.Entities;
using Newtonsoft.Json;

namespace FileParser.Domain
{
    public class FileReader
    {
        #region Fields

        private readonly JsonSerializerSettings _settings;

        #endregion Fields

        #region Constructors

        public FileReader()
        {
            _settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        #endregion Constructors

        #region Methods

        #region Public

        public IEnumerable<Menu> GetMenuFromFilePath(string filePath)
        {
            var returnValue = new List<Menu>();
            string fileText;
            using (var reader = new StreamReader(filePath, true))
            {
                fileText = reader.ReadToEnd();
            }
            var menus = JsonConvert.DeserializeObject<Wrap[]>(fileText, _settings);
            foreach (var menu in menus)
            {
                returnValue.Add(menu.Menu);
            }
            return returnValue;
        }

        #endregion Public

        #region Private



        #endregion Private

        #endregion Methods
    }
}
